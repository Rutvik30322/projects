import React, { useEffect, useRef, useState } from 'react';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import { View, TouchableOpacity, Text, StyleSheet, Dimensions, Animated } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import Svg, { Path } from 'react-native-svg';
import { useTheme } from '../context/ThemeContext';
import { useCart } from '../context/CartContext';
import HomeIcon from '../components/HomeIcon';
import CartIcon from '../components/CartIcon';
import OrdersIcon from '../components/OrdersIcon';
import SettingsIcon from '../components/SettingsIcon';
import ChatBotIcon from '../components/ChatBotIcon';
import ChatbotModal from '../components/ChatbotModal';

import HomeScreen from '../screens/HomeScreen';
import CartScreen from '../screens/CartScreen';
import OrdersScreen from '../screens/OrdersScreen';
import SettingsStackNavigator from './SettingsStackNavigator';

const Tab = createBottomTabNavigator();
const screenWidth = Dimensions.get('window').width;

// Animated Tab Button Component
const AnimatedTabButton: React.FC<{
  route: any;
  options: any;
  isFocused: boolean;
  iconColor: string;
  iconSize: number;
  icon: React.ReactNode;
  label: string | undefined;
  onPress: () => void;
  onLongPress: () => void;
  colors: any;
}> = ({ isFocused, iconColor, icon, label, onPress, onLongPress, options }) => {
  const scaleAnim = useRef(new Animated.Value(isFocused ? 1.1 : 1)).current;
  
  useEffect(() => {
    Animated.spring(scaleAnim, {
      toValue: isFocused ? 1.1 : 1,
      useNativeDriver: true,
      tension: 300,
      friction: 10,
    }).start();
  }, [isFocused, scaleAnim]);

  return (
    <TouchableOpacity
      accessibilityRole="button"
      accessibilityState={isFocused ? { selected: true } : {}}
      accessibilityLabel={options.tabBarAccessibilityLabel}
      testID={options.tabBarTestID}
      onPress={onPress}
      onLongPress={onLongPress}
      style={styles.tabButton}
      activeOpacity={0.6}
    >
      <Animated.View 
        style={[
          styles.tabIconContainer,
          { transform: [{ scale: scaleAnim }] }
        ]}>
        {icon}
      </Animated.View>
      {label && (
        <Animated.Text style={[
          styles.tabLabel,
          { color: iconColor },
          isFocused && styles.tabLabelFocused
        ]}>
          {label}
        </Animated.Text>
      )}
    </TouchableOpacity>
  );
};

const BottomTabNavigator: React.FC<{ navigation: any }> = ({ navigation }) => {
  const { colors, theme } = useTheme();
  const { getTotalItems } = useCart();
  const [chatbotVisible, setChatbotVisible] = useState(false);

  return (
    <>
      <Tab.Navigator
        tabBar={(props) => (
          <CustomTabBar 
            {...props} 
            colors={colors} 
            theme={theme} 
            getTotalItems={getTotalItems}
            onChatbotPress={() => setChatbotVisible(true)}
          />
        )}
        screenOptions={{
          headerShown: false,
          lazy: true,
          tabBarHideOnKeyboard: true,
        }}
      >
        <Tab.Screen
          name="Home"
          component={HomeScreen}
          options={{
            tabBarLabel: 'Home',
          }}
        />
        <Tab.Screen
          name="Cart"
          component={CartScreen}
          options={{
            tabBarLabel: 'Cart',
          }}
        />
        <Tab.Screen
          name="Orders"
          component={OrdersScreen}
          options={{
            tabBarLabel: 'Orders',
          }}
        />
        <Tab.Screen
          name="Settings"
          component={SettingsStackNavigator}
          options={{
            tabBarLabel: 'Settings',
          }}
        />
      </Tab.Navigator>
      <ChatbotModal 
        visible={chatbotVisible} 
        onClose={() => setChatbotVisible(false)} 
      />
    </>
  );
};

const CustomTabBar = ({ state, descriptors, navigation, colors, theme, getTotalItems, onChatbotPress }: any) => {
  const insets = useSafeAreaInsets();
  const bottomPadding = Math.max(insets.bottom, 8); // Ensure minimum 8px padding, or use safe area inset if larger
  
  return (
      <View style={[
        styles.tabBarContainer, 
        { 
          backgroundColor: colors.surface,
          paddingBottom: bottomPadding,
        }
      ]}>
      {/* Top border for classic design */}
      <View style={[styles.topBorder, { borderTopColor: colors.textSecondary + (theme === 'dark' ? '30' : '20') }]} />
      
      <View style={styles.tabBarContent}>
        {/* Left side tabs */}
        <View style={styles.leftTabs}>
          {state.routes.slice(0, 2).map((route: any, index: number) => {
            // Skip if this is the chatbot route (shouldn't happen, but just in case)
            if (route.name === 'Chatbot') return null;
            const { options } = descriptors[route.key];
            const label = options.tabBarLabel !== undefined
              ? options.tabBarLabel
              : options.title !== undefined
              ? options.title
              : route.name;

            const isFocused = state.index === index;
            const iconColor = isFocused ? colors.primary : colors.textSecondary;
            const iconSize = 24;

            const onPress = () => {
              const event = navigation.emit({
                type: 'tabPress',
                target: route.key,
                canPreventDefault: true,
              });

              if (!isFocused && !event.defaultPrevented) {
                navigation.navigate(route.name);
              }
            };

            const onLongPress = () => {
              navigation.emit({
                type: 'tabLongPress',
                target: route.key,
              });
            };

            let icon;
            switch (route.name) {
              case 'Home':
                icon = <HomeIcon size={iconSize} focused={isFocused} color={iconColor} />;
                break;
              case 'Cart':
                icon = (
                  <View style={{ position: 'relative' }}>
                    <CartIcon size={iconSize} focused={isFocused} color={iconColor} />
                    {getTotalItems() > 0 && (
                      <View style={[styles.badge, { backgroundColor: colors.error || 'red' }]}>
                        <Text style={styles.badgeText}>{getTotalItems()}</Text>
                      </View>
                    )}
                  </View>
                );
                break;
              default:
                icon = null;
            }

            return (
              <TouchableOpacity
                key={route.key}
                accessibilityRole="button"
                accessibilityState={isFocused ? { selected: true } : {}}
                accessibilityLabel={options.tabBarAccessibilityLabel}
                testID={options.tabBarTestID}
                onPress={onPress}
                onLongPress={onLongPress}
                style={styles.tabButton}
                activeOpacity={0.6}
              >
                <View style={styles.tabIconContainer}>
                  {icon}
                </View>
                {label && (
                  <Text style={[
                    styles.tabLabel,
                    { color: iconColor },
                    isFocused && styles.tabLabelFocused
                  ]}>
                    {label}
                  </Text>
                )}
              </TouchableOpacity>
            );
          })}
        </View>

        {/* Center Chatbot Button */}
        {(() => {
          const isFocused = false; // Chatbot is always a modal, not a tab

          const onPress = () => {
            onChatbotPress?.();
          };

          const onLongPress = () => {
            // Long press can also open chatbot
            onChatbotPress?.();
          };

          return (
            <View style={styles.chatbotContainer}>
              <TouchableOpacity
                accessibilityRole="button"
                accessibilityLabel="Open Chatbot"
                testID="chatbot-button"
                onPress={onPress}
                onLongPress={onLongPress}
                style={styles.chatbotButton}
                activeOpacity={0.6}
              >
                {/* Main circular background */}
                <View style={[styles.chatbotCircleBackground, { 
                  backgroundColor: '#381230',
                }]}>
                  <ChatBotIcon size={24} color="#FFFFFF" />
                  
                  {/* White half circle line at the top */}
                  <Svg 
                    width={60} 
                    height={15} 
                    style={styles.chatbotTopArc}
                    viewBox="0 0 60 15"
                  >
                    <Path
                      d="M 0 15 A 30 30 0 0 1 60 15"
                      stroke="#FFFFFF"
                      strokeWidth="2.5"
                      fill="none"
                      strokeLinecap="round"
                    />
                  </Svg>
                </View>
              </TouchableOpacity>
            </View>
          );
        })()}

        {/* Right side tabs */}
        <View style={styles.rightTabs}>
          {state.routes.slice(2).map((route: any, index: number) => {
            const actualIndex = index + 2;
            const { options } = descriptors[route.key];
            const label = options.tabBarLabel !== undefined
              ? options.tabBarLabel
              : options.title !== undefined
              ? options.title
              : route.name;

            const isFocused = state.index === actualIndex;
            const iconColor = isFocused ? colors.primary : colors.textSecondary;
            const iconSize = 24;

            const onPress = () => {
              const event = navigation.emit({
                type: 'tabPress',
                target: route.key,
                canPreventDefault: true,
              });

              if (!isFocused && !event.defaultPrevented) {
                navigation.navigate(route.name);
              }
            };

            const onLongPress = () => {
              navigation.emit({
                type: 'tabLongPress',
                target: route.key,
              });
            };

            let icon;
            switch (route.name) {
              case 'Orders':
                icon = <OrdersIcon size={iconSize} focused={isFocused} color={iconColor} />;
                break;
              case 'Settings':
                icon = <SettingsIcon size={iconSize} focused={isFocused} color={iconColor} />;
                break;
              default:
                icon = null;
            }

            return (
              <AnimatedTabButton
                key={route.key}
                route={route}
                options={options}
                isFocused={isFocused}
                iconColor={iconColor}
                iconSize={iconSize}
                icon={icon}
                label={label}
                onPress={onPress}
                onLongPress={onLongPress}
                colors={colors}
              />
            );
          })}
        </View>
      </View>
    </View>
  );
};

const styles = StyleSheet.create({
  tabBarContainer: {
    position: 'absolute',
    bottom: 0,
    left: 0,
    right: 0,
    minHeight: 75,
    elevation: 20,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: -3 },
    shadowOpacity: 0.15,
    shadowRadius: 8,
  },
  topBorder: {
    height: 1,
    borderTopWidth: 1,
    width: '100%',
  },
  tabBarContent: {
    flexDirection: 'row',
    height: '100%',
    alignItems: 'center',
    justifyContent: 'space-between',
    paddingHorizontal: 10,
    paddingBottom: 8,
    paddingTop: 5,
    position: 'relative',
  },
  leftTabs: {
    flexDirection: 'row',
    flex: 1,
    justifyContent: 'flex-start',
    alignItems: 'center',
    gap: 20,
  },
  rightTabs: {
    flexDirection: 'row',
    flex: 1,
    justifyContent: 'flex-end',
    alignItems: 'center',
    gap: 20,
  },
  tabButton: {
    alignItems: 'center',
    justifyContent: 'center',
    paddingVertical: 5,
    minWidth: 60,
  },
  tabIconContainer: {
    marginBottom: 4,
  },
  tabLabel: {
    fontSize: 11,
    fontWeight: '500',
    marginTop: 2,
  },
  tabLabelFocused: {
    fontWeight: '700',
  },
  chatbotContainer: {
    position: 'absolute',
    bottom: 8,
    left: screenWidth / 2 - 35,
    width: 70,
    height: 70,
    alignItems: 'center',
    justifyContent: 'center',
    zIndex: 10,
  },
  chatbotButton: {
    width: 70,
    height: 70,
    alignItems: 'center',
    justifyContent: 'center',
    position: 'relative',
  },
  chatbotCircleBackground: {
    width: 60,
    height: 60,
    borderRadius: 30,
    alignItems: 'center',
    justifyContent: 'center',
    elevation: 8,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 4 },
    shadowOpacity: 0.3,
    shadowRadius: 6,
    marginTop: -8, // Extend slightly upward
    position: 'relative',
    overflow: 'visible',
  },
  chatbotTopArc: {
    position: 'absolute',
    top: -1,
    left: 0,
  },
  badge: {
    position: 'absolute',
    top: -6,
    right: -15,
    borderRadius: 10,
    minWidth: 25,
    height: 25,
    justifyContent: 'center',
    alignItems: 'center',
    paddingHorizontal: 4,
    borderWidth: 2,
    borderColor: '#fff',
  },
  badgeText: {
    color: 'white',
    fontSize: 10,
    fontWeight: 'bold',
  },
});

export default BottomTabNavigator;
