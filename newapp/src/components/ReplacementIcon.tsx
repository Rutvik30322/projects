import React from 'react';
import Svg, { Path } from 'react-native-svg';

interface ReplacementIconProps {
  size?: number;
  color?: string;
}

const ReplacementIcon: React.FC<ReplacementIconProps> = ({ size = 16, color = 'white' }) => {
  return (
    <Svg width={size} height={size} viewBox="0 0 16 16" fill="none">
      <Path
        d="M8 0.5C12.1421 0.5 15.5 3.85786 15.5 8C15.5 12.1421 12.1421 15.5 8 15.5C4.02593 15.5 0.775919 12.4089 0.518555 8.5H1.12012C1.37637 12.0773 4.35743 14.9004 8 14.9004C11.8108 14.9004 14.9004 11.8108 14.9004 8C14.9004 4.18923 11.8108 1.09961 8 1.09961C5.87482 1.09961 3.97393 2.06154 2.70898 3.57129L2.41504 3.92188L2.73828 4.24609L3.59277 5.09961H0.5V2.00684L1.9834 3.49023L2.33496 3.08496C3.7108 1.50063 5.73823 0.5 8 0.5Z"
        fill={color}
        stroke={color}
      />
    </Svg>
  );
};

export default ReplacementIcon;
