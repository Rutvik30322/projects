import React from 'react';
import Svg, { Path } from 'react-native-svg';
import { useTheme } from '../context/ThemeContext';

interface HomeIconProps {
  size?: number;
  focused?: boolean;
  color?: string;
}

const HomeIcon: React.FC<HomeIconProps> = ({ size = 24, focused = false, color }) => {
  const { colors, theme } = useTheme();
  
  // Use provided color or theme-based color
  const iconColor = color || (theme === 'light' ? '#381230' : '#FFFFFF');
  
  if (focused) {
    // Use home-2.svg (filled icon) when on home screen
    return (
      <Svg width={size} height={size * (26 / 24)} viewBox="0 0 24 26" fill="none">
        <Path
          d="M20.04 7.35478L14.28 3.0087C12.71 1.82243 10.3 1.88714 8.78999 3.1489L3.77999 7.36557C2.77999 8.20674 1.98999 9.93223 1.98999 11.2911V18.7322C1.98999 21.4822 4.05999 23.7254 6.60999 23.7254H17.39C19.94 23.7254 22.01 21.493 22.01 18.743V11.4313C22.01 9.97537 21.14 8.18517 20.04 7.35478ZM12.75 19.4116C12.75 19.8538 12.41 20.2205 12 20.2205C11.59 20.2205 11.25 19.8538 11.25 19.4116V16.1764C11.25 15.7342 11.59 15.3675 12 15.3675C12.41 15.3675 12.75 15.7342 12.75 16.1764V19.4116Z"
          fill={iconColor}
        />
      </Svg>
    );
  } else {
    // Use home.svg (outline icon) when not on home screen
    return (
      <Svg width={size} height={size} viewBox="0 0 24 24" fill="none">
        <Path
          d="M9.02 2.83992L3.63 7.03992C2.73 7.73992 2 9.22992 2 10.3599V17.7699C2 20.0899 3.89 21.9899 6.21 21.9899H17.79C20.11 21.9899 22 20.0899 22 17.7799V10.4999C22 9.28992 21.19 7.73992 20.2 7.04992L14.02 2.71992C12.62 1.73992 10.37 1.78992 9.02 2.83992Z"
          stroke={iconColor}
          strokeWidth="1.5"
          strokeLinecap="round"
          strokeLinejoin="round"
        />
        <Path
          d="M12 17.99V14.99"
          stroke={iconColor}
          strokeWidth="1.5"
          strokeLinecap="round"
          strokeLinejoin="round"
        />
      </Svg>
    );
  }
};

export default HomeIcon;
