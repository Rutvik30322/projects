import { createSlice, createAsyncThunk, PayloadAction } from '@reduxjs/toolkit';
import AsyncStorage from '@react-native-async-storage/async-storage';
import authService, { LoginData, RegisterData } from '../../services/authService';

// Define user interface
export interface User {
  _id: string;
  name: string;
  email: string;
  mobile: string;
  role: string;
  profilePicture?: string;
}

// Define auth state interface
interface AuthState {
  user: User | null;
  token: string | null;
  isLoading: boolean;
  isAuthenticated: boolean;
  error: string | null;
  success: string | null;
}

// Initial state
const initialState: AuthState = {
  user: null,
  token: null,
  isLoading: false,
  isAuthenticated: false,
  error: null,
  success: null,
};

// Async thunks

// Register user
export const register = createAsyncThunk(
  'auth/register',
  async (userData: RegisterData, { rejectWithValue }) => {
    try {
      const response = await authService.register(userData);
      return response.data; // response.data is { user, token } after interceptor
    } catch (error: any) {
      // Error from axios interceptor: error.response.data or error.message
      const errorMessage = error?.message || error?.error || 'Registration failed';
      return rejectWithValue(errorMessage);
    }
  }
);

// Login user
export const login = createAsyncThunk(
  'auth/login',
  async (credentials: LoginData, { rejectWithValue }) => {
    try {
      const response = await authService.login(credentials);
      // Return the actual user and token data
      // response.data is { user, token, requiresOtp } after interceptor
      return response.data;
    } catch (error: any) {
      // Error from axios interceptor: error.response.data or error.message
      const errorMessage = error?.message || error?.error || 'Login failed';
      return rejectWithValue(errorMessage);
    }
  }
);

// Send login OTP
export const sendLoginOtp = createAsyncThunk(
  'auth/sendLoginOtp',
  async (mobile: string, { rejectWithValue }) => {
    try {
      const response = await authService.sendLoginOtp(mobile);
      return response.data;
    } catch (error: any) {
      const errorMessage = error?.message || error?.error || 'Failed to send OTP';
      return rejectWithValue(errorMessage);
    }
  }
);

// Verify login OTP
export const verifyLoginOtp = createAsyncThunk(
  'auth/verifyLoginOtp',
  async (data: { mobile: string; otp: string }, { rejectWithValue }) => {
    try {
      const response = await authService.verifyLoginOtp(data.mobile, data.otp);
      return response.data; // response.data is { user, token } after interceptor
    } catch (error: any) {
      const errorMessage = error?.message || error?.error || 'OTP verification failed';
      return rejectWithValue(errorMessage);
    }
  }
);

// Logout user
export const logout = createAsyncThunk(
  'auth/logout',
  async (_, { rejectWithValue }) => {
    try {
      await authService.logout();
      return null;
    } catch (error: any) {
      return rejectWithValue(error.message || 'Logout failed');
    }
  }
);

// Load user from storage + verify token with server
export const loadUser = createAsyncThunk(
  'auth/loadUser',
  async (_, { rejectWithValue }) => {
    try {
      const token = await authService.getToken();

      if (!token) {
        return rejectWithValue('No token found');
      }

      // Check local expiry first (fast, no network)
      const isExpired = await authService.isTokenExpired();
      if (isExpired) {
        await authService.logout();
        return rejectWithValue('Token expired');
      }

      // Verify token is actually valid on the server (/auth/me)
      const meResponse = await authService.getMe();
      const freshUser = meResponse?.data?.user || meResponse?.data;

      if (!freshUser) {
        await authService.logout();
        return rejectWithValue('Session invalid');
      }

      // Update stored user with fresh data from server
      await AsyncStorage.setItem('user', JSON.stringify(freshUser));

      return { user: freshUser, token };
    } catch (error: any) {
      // Server rejected token (401) or network error → clear session
      await authService.logout();
      return rejectWithValue(error.message || 'Session verification failed');
    }
  }
);

// Update profile
export const updateProfile = createAsyncThunk(
  'auth/updateProfile',
  async (data: { name?: string; email?: string; mobile?: string; profilePicture?: string }, { rejectWithValue }) => {
    try {
      const response = await authService.updateProfile(data);
      return response.data;
    } catch (error: any) {
      return rejectWithValue(error.message || 'Profile update failed');
    }
  }
);

// Auth slice
const authSlice = createSlice({
  name: 'auth',
  initialState,
  reducers: {
    clearError: (state) => {
      state.error = null;
    },
    clearSuccess: (state) => {
      state.success = null;
    },
    resetAuth: (state) => {
      state.user = null;
      state.token = null;
      state.isAuthenticated = false;
      state.error = null;
      state.success = null;
    },
  },
  extraReducers: (builder) => {
    // Register
    builder
      .addCase(register.pending, (state) => {
        state.isLoading = true;
        state.error = null;
        state.success = null;
      })
      .addCase(register.fulfilled, (state, action: PayloadAction<any>) => {
        state.isLoading = false;
        state.isAuthenticated = true;
        state.user = action.payload.user;
        state.token = action.payload.token;
        state.success = 'Registration successful!';
        state.error = null;
      })
      .addCase(register.rejected, (state, action) => {
        state.isLoading = false;
        state.error = action.payload as string;
        state.success = null;
      })

      // Login
      .addCase(login.pending, (state) => {
        state.isLoading = true;
        state.error = null;
        state.success = null;
      })
      .addCase(login.fulfilled, (state, action: PayloadAction<any>) => {
        state.isLoading = false;
        // If requiresOtp is true, don't set authenticated yet
        if (action.payload.requiresOtp) {
          state.isAuthenticated = false;
          state.success = 'OTP sent to your mobile number';
        } else {
          state.isAuthenticated = true;
          state.user = action.payload.user;
          state.token = action.payload.token;
          state.success = 'Login successful!';
        }
        state.error = null;
      })
      .addCase(login.rejected, (state, action) => {
        state.isLoading = false;
        state.error = action.payload as string;
        state.success = null;
      })

      // Send Login OTP
      .addCase(sendLoginOtp.pending, (state) => {
        state.isLoading = true;
        state.error = null;
      })
      .addCase(sendLoginOtp.fulfilled, (state) => {
        state.isLoading = false;
        state.success = 'OTP sent successfully';
      })
      .addCase(sendLoginOtp.rejected, (state, action) => {
        state.isLoading = false;
        state.error = action.payload as string;
      })

      // Verify Login OTP
      .addCase(verifyLoginOtp.pending, (state) => {
        state.isLoading = true;
        state.error = null;
        state.success = null;
      })
      .addCase(verifyLoginOtp.fulfilled, (state, action: PayloadAction<any>) => {
        state.isLoading = false;
        state.isAuthenticated = true;
        state.user = action.payload.user;
        state.token = action.payload.token;
        state.success = 'Login successful!';
        state.error = null;
      })
      .addCase(verifyLoginOtp.rejected, (state, action) => {
        state.isLoading = false;
        state.error = action.payload as string;
        state.success = null;
      })

      // Logout
      .addCase(logout.pending, (state) => {
        state.isLoading = true;
      })
      .addCase(logout.fulfilled, (state) => {
        state.isLoading = false;
        state.isAuthenticated = false;
        state.user = null;
        state.token = null;
        state.error = null;
        state.success = 'Logged out successfully!';
      })
      .addCase(logout.rejected, (state, action) => {
        state.isLoading = false;
        state.error = action.payload as string;
      })

      // Load user
      .addCase(loadUser.pending, (state) => {
        state.isLoading = true;
      })
      .addCase(loadUser.fulfilled, (state, action: PayloadAction<any>) => {
        state.isLoading = false;
        state.isAuthenticated = true;
        state.user = action.payload.user;
        state.token = action.payload.token;
      })
      .addCase(loadUser.rejected, (state) => {
        state.isLoading = false;
        state.isAuthenticated = false;
        state.user = null;
        state.token = null;
      })

      // Update profile
      .addCase(updateProfile.pending, (state) => {
        state.isLoading = true;
        state.error = null;
      })
      .addCase(updateProfile.fulfilled, (state, action: PayloadAction<any>) => {
        state.isLoading = false;
        state.user = action.payload.user;
        state.success = 'Profile updated successfully!';
      })
      .addCase(updateProfile.rejected, (state, action) => {
        state.isLoading = false;
        state.error = action.payload as string;
      });
  },
});

export const { clearError, clearSuccess, resetAuth } = authSlice.actions;
export default authSlice.reducer;
