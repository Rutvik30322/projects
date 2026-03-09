import React from 'react';
import Svg, { Path } from 'react-native-svg';

interface UserIconProps {
  size?: number;
  color?: string;
}

const UserIcon: React.FC<UserIconProps> = ({ size = 16, color = '#381230' }) => {
  return (
    <Svg width={size} height={size} viewBox="0 0 16 16" fill="none">
      <Path
        d="M7.99967 1.83337C9.56437 1.83337 10.8335 3.10172 10.8337 4.66638C10.8337 6.23119 9.56448 7.50037 7.99967 7.50037C6.43501 7.50019 5.16666 6.23108 5.16666 4.66638C5.16684 3.10183 6.43512 1.83355 7.99967 1.83337Z"
        fill={color}
        stroke={color}
      />
      <Path
        d="M7.99957 10.1666C11.0844 10.1666 13.4469 12.1719 13.5552 14.4996H2.44489C2.55327 12.172 4.91494 10.1668 7.99957 10.1666Z"
        fill={color}
        stroke={color}
      />
    </Svg>
  );
};

export default UserIcon;
