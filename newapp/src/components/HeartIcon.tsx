import React from 'react';
import Svg, { Path } from 'react-native-svg';

interface HeartIconProps {
  size?: number;
  color?: string;
  filled?: boolean;
}

const HeartIcon: React.FC<HeartIconProps> = ({ size = 16, color = '#381230', filled = false }) => {
  const aspectRatio = 17 / 15;
  const height = size / aspectRatio;
  
  return (
    <Svg width={size} height={height} viewBox="0 0 17 15" fill="none">
      <Path
        d="M8.50069 1.23484C10.4973 -0.46856 13.5827 -0.412009 15.5059 1.41971C17.4292 3.25142 17.4952 6.16964 15.7065 8.07297L8.49975 14.9333L1.29315 8.07297C-0.4955 6.16964 -0.42864 3.24681 1.49373 1.41971C3.41827 -0.409464 6.49829 -0.471088 8.50069 1.23484Z"
        fill={filled ? color : 'none'}
        stroke={filled ? color : color}
        strokeWidth={filled ? 0 : 1.2}
      />
    </Svg>
  );
};

export default HeartIcon;
