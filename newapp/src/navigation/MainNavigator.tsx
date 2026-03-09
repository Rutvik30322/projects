import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator, TransitionPresets } from '@react-navigation/stack';
import { View, TouchableOpacity, Text, StyleSheet, Dimensions } from 'react-native';
import { useTheme } from '../context/ThemeContext';

import SplashScreen from '../screens/SplashScreen';
import LoginScreen from '../screens/LoginScreen';
import LoginOTPScreen from '../screens/LoginOTPScreen';
import BottomTabNavigator from './BottomTabNavigator';
import ForgotPasswordScreen from '../screens/ForgotPasswordScreen';
import SignUpScreen from '../screens/SignUpScreen';
import ProductDetailScreen from '../screens/ProductDetailScreen';
import ProductDetailScreenNew from '../screens/ProductDetailScreenNew';
import ProductDetailScreenEnhanced from '../screens/ProductDetailScreenEnhanced';
import AllProductsScreen from '../screens/AllProductsScreen';
import CategoryProductsScreen from '../screens/CategoryProductsScreen';
import PaymentScreen from '../screens/PaymentScreen';
import OrderDetailScreen from '../screens/OrderDetailScreen';
import ChangePasswordScreen from '../screens/ChangePasswordScreen';
import CartScreen from '../screens/CartScreen';
import DeliveryAddressScreen from '../screens/DeliveryAddressScreen';
import AddAddressScreen from '../screens/AddAddressScreen';

const Stack = createStackNavigator();

// Optimized transition configuration for ultra-smooth animations
const screenOptions = {
  gestureEnabled: true,
  gestureDirection: 'horizontal' as const,
  gestureResponseDistance: 50,
  cardStyleInterpolator: ({ current, layouts }: any) => {
    return {
      cardStyle: {
        transform: [
          {
            translateX: current.progress.interpolate({
              inputRange: [0, 1],
              outputRange: [layouts.screen.width, 0],
            }),
          },
        ],
        opacity: current.progress.interpolate({
          inputRange: [0, 1],
          outputRange: [0.8, 1],
        }),
      },
      overlayStyle: {
        opacity: current.progress.interpolate({
          inputRange: [0, 1],
          outputRange: [0, 0.2],
        }),
      },
    };
  },
  transitionSpec: {
    open: {
      animation: 'timing' as const,
      config: {
        duration: 200,
      },
    },
    close: {
      animation: 'timing' as const,
      config: {
        duration: 180,
      },
    },
  },
  cardStyle: {
    backgroundColor: 'transparent',
  },
};

const MainNavigator: React.FC = () => {
  const { colors, theme } = useTheme();

  return (
    <NavigationContainer>
      <Stack.Navigator
        initialRouteName="Splash"
        screenOptions={screenOptions}
      >
        <Stack.Screen
          name="Splash"
          component={SplashScreen}
          options={{ headerShown: false }}
        />
        <Stack.Screen
          name="Login"
          component={LoginScreen}
          options={{ headerShown: false }}
        />
        <Stack.Screen
          name="LoginOTP"
          component={LoginOTPScreen}
          options={{ headerShown: false }}
        />
        <Stack.Screen
          name="HomeTabs"
          component={BottomTabNavigator}
          options={{
            headerShown: false,
            gestureEnabled: false, // Disable swipe-back gesture on home so the whole screen does not slide
          }}
        />
        <Stack.Screen
          name="ForgotPassword"
          component={ForgotPasswordScreen}
          options={{ headerShown: false }}
        />
        <Stack.Screen
          name="SignUp"
          component={SignUpScreen}
          options={{ headerShown: false }}
        />
        <Stack.Screen
          name="ProductDetail"
          component={ProductDetailScreen}
          options={{ headerShown: false }}
        />
        <Stack.Screen
          name="ProductDetailNew"
          component={ProductDetailScreenNew}
          options={{
            headerShown: false,
            gestureEnabled: false,
            // No visual animation — use 0ms so back is instant
            transitionSpec: {
              open: { animation: 'timing' as const, config: { duration: 0 } },
              close: { animation: 'timing' as const, config: { duration: 0 } },
            },
            cardStyleInterpolator: ({ current }: any) => {
              return {
                cardStyle: {
                  transform: [{ translateX: current.progress.interpolate({ inputRange: [0, 1], outputRange: [0, 0] }) }],
                  opacity: current.progress.interpolate({ inputRange: [0, 1], outputRange: [1, 1] }),
                },
                overlayStyle: { opacity: 0 },
              };
            },
          }}
        />
        <Stack.Screen
          name="ProductDetailEnhanced"
          component={ProductDetailScreenEnhanced}
          options={{
            headerShown: false,
            gestureEnabled: false,
            // No visual animation — use 0ms so back is instant
            transitionSpec: {
              open: { animation: 'timing' as const, config: { duration: 0 } },
              close: { animation: 'timing' as const, config: { duration: 0 } },
            },
            cardStyleInterpolator: ({ current }: any) => {
              return {
                cardStyle: {
                  transform: [{ translateX: current.progress.interpolate({ inputRange: [0, 1], outputRange: [0, 0] }) }],
                  opacity: current.progress.interpolate({ inputRange: [0, 1], outputRange: [1, 1] }),
                },
                overlayStyle: { opacity: 0 },
              };
            },
          }}
        />
        <Stack.Screen
          name="AllProducts"
          component={AllProductsScreen}
          options={{ headerShown: false }}
        />
        <Stack.Screen
          name="CategoryProducts"
          component={CategoryProductsScreen}
          options={{
            headerShown: false,
            gestureEnabled: false, // Disable gestures to prevent screen sliding when touching brand sidebar
            // No visual animation — use 0ms so back is instant
            transitionSpec: {
              open: { animation: 'timing' as const, config: { duration: 0 } },
              close: { animation: 'timing' as const, config: { duration: 0 } },
            },
            cardStyleInterpolator: ({ current }: any) => {
              return {
                cardStyle: {
                  transform: [{ translateX: current.progress.interpolate({ inputRange: [0, 1], outputRange: [0, 0] }) }],
                  opacity: current.progress.interpolate({ inputRange: [0, 1], outputRange: [1, 1] }),
                },
                overlayStyle: { opacity: 0 },
              };
            },
          }}
        />
        <Stack.Screen
          name="Cart"
          component={CartScreen}
          options={{ headerShown: false }}
        />
        <Stack.Screen
          name="Payment"
          component={PaymentScreen}
          options={{ headerShown: false }}
        />
        <Stack.Screen
          name="OrderDetail"
          component={OrderDetailScreen}
          options={{ headerShown: false }}
        />
        <Stack.Screen
          name="ChangePassword"
          component={ChangePasswordScreen}
          options={{ headerShown: false }}
        />
        <Stack.Screen
          name="DeliveryAddress"
          component={DeliveryAddressScreen}
          options={{ headerShown: false }}
        />
        <Stack.Screen
          name="AddAddress"
          component={AddAddressScreen}
          options={{ headerShown: false }}
        />
      </Stack.Navigator>
    </NavigationContainer>
  );
};

export default MainNavigator;