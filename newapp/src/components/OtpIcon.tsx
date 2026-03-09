import React from 'react';
import Svg, { Path, Rect, Circle } from 'react-native-svg';

interface OtpIconProps {
  size?: number;
  color?: string;
}

const OtpIcon: React.FC<OtpIconProps> = ({ size = 16, color = '#381230' }) => {
  return (
    <Svg width={size} height={size} viewBox="0 0 16 16" fill="none">
      <Rect x="2" y="6" width="12" height="8" rx="1" stroke={color} strokeWidth="1.5" fill="none" />
      <Path d="M6 6V4C6 2.89543 6.89543 2 8 2C9.10457 2 10 2.89543 10 4V6" stroke={color} strokeWidth="1.5" fill="none" />
      <Path d="M8 9V11" stroke={color} strokeWidth="1.5" strokeLinecap="round" />
      <Circle cx="8" cy="9" r="0.5" fill={color} />
    </Svg>
  );
};

export default OtpIcon;
