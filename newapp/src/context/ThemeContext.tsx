import React, { createContext, useContext, useEffect, useState } from 'react';
import { Appearance, ColorSchemeName, StatusBar, Platform } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';

interface ThemeContextType {
  theme: 'light' | 'dark';
  toggleTheme: () => void;
  colors: {
    primary: string;
    secondary: string;
    background: string;
    surface: string;
    text: string;
    textSecondary: string;
    error: string;
    onPrimary: string;
    onSecondary: string;
    onBackground: string;
    onSurface: string;
  };
  fonts: {
    regular: string;
    medium: string;
    bold: string;
  };
}

const lightColors = {
  primary: '#663056', // Medium purple/plum - softer primary
  secondary: '#381230', // Dark purple - for emphasis and important elements
  background: '#FFFFFF', // Very light pink tinted white background
  surface: '#FFFFFF', // Pure white for cards and surfaces
  text: '#381230', // Dark purple for main text
  textSecondary: '#663056', // Medium purple for secondary text
  error: '#db8286', // Muted rose for errors
  onPrimary: '#FFFFFF', // White text on primary
  onSecondary: '#FFFFFF', // White text on secondary
  onBackground: '#381230', // Dark purple text on background
  onSurface: '#381230', // Dark purple text on surface
};

const darkColors = {
  primary: '#8B5CF6', // Lighter purple
  secondary: '#FBBF24', // Lighter amber
  background: '#111827', // Dark
  surface: '#1F2937', // Darker gray
  text: '#F9FAFB', // Light
  textSecondary: '#D1D5DB', // Lighter gray
  error: '#F87171', // Light red
  onPrimary: '#FFFFFF',
  onSecondary: '#FFFFFF',
  onBackground: '#F9FAFB',
  onSurface: '#F9FAFB',
};

const ThemeContext = createContext<ThemeContextType | undefined>(undefined);
const THEME_STORAGE_KEY = '@app_theme';

export const ThemeProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
  const [theme, setTheme] = useState<'light' | 'dark'>('light');
  const [isThemeLoaded, setIsThemeLoaded] = useState(false);
  
  // Load saved theme preference on mount
  useEffect(() => {
    const loadTheme = async () => {
      try {
        const savedTheme = await AsyncStorage.getItem(THEME_STORAGE_KEY);
        if (savedTheme === 'light' || savedTheme === 'dark') {
          setTheme(savedTheme);
        } else {
          // If no saved theme, use system preference
          const colorScheme = Appearance.getColorScheme();
          setTheme((colorScheme === 'dark' || colorScheme === 'light') ? colorScheme : 'light');
        }
      } catch (error) {
        console.error('Failed to load theme preference:', error);
        // Fallback to system preference
        const colorScheme = Appearance.getColorScheme();
        setTheme((colorScheme === 'dark' || colorScheme === 'light') ? colorScheme : 'light');
      } finally {
        setIsThemeLoaded(true);
      }
    };
    
    loadTheme();
  }, []);

  // Save theme preference when it changes
  useEffect(() => {
    if (isThemeLoaded) {
      const saveTheme = async () => {
        try {
          await AsyncStorage.setItem(THEME_STORAGE_KEY, theme);
        } catch (error) {
          console.error('Failed to save theme preference:', error);
        }
      };
      saveTheme();
    }
  }, [theme, isThemeLoaded]);

  const toggleTheme = () => {
    setTheme(prev => prev === 'light' ? 'dark' : 'light');
  };

  const colors = theme === 'light' ? lightColors : darkColors;

  // Update status bar based on theme
  useEffect(() => {
    if (Platform.OS === 'android') {
      StatusBar.setBackgroundColor(colors.surface);
      StatusBar.setBarStyle(theme === 'light' ? 'dark-content' : 'light-content');
    } else {
      StatusBar.setBarStyle(theme === 'light' ? 'dark-content' : 'light-content');
    }
    
    // Set status bar translucent and hidden for iOS if needed
    StatusBar.setTranslucent(false);
  }, [theme, colors]);

  const fonts = {
    regular: 'Alexandria-Regular',
    medium: 'Alexandria-Medium',
    bold: 'Alexandria-Bold',
  };

  const contextValue: ThemeContextType = {
    theme,
    toggleTheme,
    colors,
    fonts,
  };

  return (
    <ThemeContext.Provider value={contextValue}>
      {children}
    </ThemeContext.Provider>
  );
};

export const useTheme = (): ThemeContextType => {
  const context = useContext(ThemeContext);
  if (!context) {
    throw new Error('useTheme must be used within a ThemeProvider');
  }
  return context;
};