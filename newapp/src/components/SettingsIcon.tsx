import React from 'react';
import Svg, { Path } from 'react-native-svg';
import { useTheme } from '../context/ThemeContext';

interface SettingsIconProps {
  size?: number;
  focused?: boolean;
  color?: string;
}

const SettingsIcon: React.FC<SettingsIconProps> = ({ size = 24, focused = false, color }) => {
  const { colors, theme } = useTheme();
  
  // Use provided color or theme-based color
  const iconColor = color || (theme === 'light' ? '#381230' : '#FFFFFF');

  return (
    <Svg width={size} height={size} viewBox="0 0 24 24" fill="none">
      <Path
        d="M12 12.0002C14.7614 12.0002 17 9.76167 17 7.00024C17 4.23882 14.7614 2.00024 12 2.00024C9.23858 2.00024 7 4.23882 7 7.00024C7 9.76167 9.23858 12.0002 12 12.0002Z"
        stroke={iconColor}
        strokeWidth="1.5"
        strokeLinecap="round"
        strokeLinejoin="round"
      />
      <Path
        d="M20.59 22C20.59 18.13 16.74 15 12 15C7.26003 15 3.41003 18.13 3.41003 22"
        stroke={iconColor}
        strokeWidth="1.5"
        strokeLinecap="round"
        strokeLinejoin="round"
      />
    </Svg>
  );
};

export default SettingsIcon;
