import React from 'react';
import Svg, { Path } from 'react-native-svg';

interface BrandSelectionIndicatorProps {
  width?: number;
  height?: number;
  color?: string;
}

const BrandSelectionIndicator: React.FC<BrandSelectionIndicatorProps> = ({ 
  width = 5, 
  height = 44, 
  color = '#381230' 
}) => {
  return (
    <Svg width={width} height={height} viewBox="0 0 5 44" fill="none">
      <Path
        d="M0 5C0 2.23858 2.23858 0 5 0V44C2.23858 44 0 41.7614 0 39V5Z"
        fill={color}
      />
    </Svg>
  );
};

export default BrandSelectionIndicator;
