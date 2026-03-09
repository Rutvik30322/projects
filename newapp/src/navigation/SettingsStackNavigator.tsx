import React from 'react';
import { createStackNavigator } from '@react-navigation/stack';
import SettingsScreen from '../screens/SettingsScreen';
import ProfileScreen from '../screens/ProfileScreen';
import NotificationsScreen from '../screens/NotificationsScreen';
import PaymentMethodsScreen from '../screens/PaymentMethodsScreen';
import DeliveryAddressScreen from '../screens/DeliveryAddressScreen';
import AddAddressScreen from '../screens/AddAddressScreen';
import HelpSupportScreen from '../screens/HelpSupportScreen';
import AboutScreen from '../screens/AboutScreen';
import ThemeSettingsScreen from '../screens/ThemeSettingsScreen';

const Stack = createStackNavigator();

// Smooth animation configuration for settings stack
const settingsScreenOptions = {
  gestureEnabled: true,
  gestureDirection: 'horizontal' as const,
  gestureResponseDistance: 50,
  cardStyleInterpolator: ({ current, next, layouts }: any) => {
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
          inputRange: [0, 0.3, 0.7, 1],
          outputRange: [0, 0.5, 0.9, 1],
        }),
      },
      overlayStyle: {
        opacity: current.progress.interpolate({
          inputRange: [0, 1],
          outputRange: [0, 0.3],
        }),
      },
    };
  },
  transitionSpec: {
    open: {
      animation: 'timing' as const,
      config: {
        duration: 300,
      },
    },
    close: {
      animation: 'timing' as const,
      config: {
        duration: 250,
      },
    },
  },
  cardStyle: {
    backgroundColor: 'transparent',
  },
};

const SettingsStackNavigator: React.FC = () => {
  return (
    <Stack.Navigator 
      initialRouteName="Settings"
      screenOptions={settingsScreenOptions}
    >
      <Stack.Screen 
        name="Settings" 
        component={SettingsScreen} 
        options={{ headerShown: false }} 
      />
      <Stack.Screen 
        name="Profile" 
        component={ProfileScreen} 
        options={{ headerShown: false }} 
      />
      <Stack.Screen 
        name="Notifications" 
        component={NotificationsScreen} 
        options={{ headerShown: false }} 
      />
      <Stack.Screen 
        name="PaymentMethods" 
        component={PaymentMethodsScreen} 
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
      <Stack.Screen 
        name="HelpSupport" 
        component={HelpSupportScreen} 
        options={{ headerShown: false }} 
      />
      <Stack.Screen 
        name="About" 
        component={AboutScreen} 
        options={{ headerShown: false }} 
      />
      <Stack.Screen 
        name="ThemeSettings" 
        component={ThemeSettingsScreen} 
        options={{ headerShown: false }} 
      />
    </Stack.Navigator>
  );
};

export default SettingsStackNavigator;