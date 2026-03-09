import React from 'react';
import Svg, { Path, Circle, G } from 'react-native-svg';

interface BackArrowIconProps {
  size?: number;
  arrowColor?: string;
  circleColor?: string;
}

const BackArrowIcon: React.FC<BackArrowIconProps> = ({ 
  size = 40, 
  arrowColor = '#381230',
  circleColor = '#E5E5E5'
}) => {
  // Transform the arrow from 20x12 viewBox to fit in 40x40 circle
  // Scale factor: scale to fit ~24px width (60% of 40)
  const scale = 1.2; // Scale from 20 to 24
  const translateX = (40 - 20 * scale) / 2; // Center horizontally
  const translateY = (40 - 12 * scale) / 2; // Center vertically
  
  return (
    <Svg width={size} height={size} viewBox="0 0 40 40" fill="none">
      {/* Light gray circle background */}
      <Circle cx="20" cy="20" r="20" fill={circleColor} />
      {/* Arrow from airo.svg - transformed to fit in circle */}
      <G transform={`translate(${translateX}, ${translateY}) scale(${scale})`}>
        <Path
          d="M19.2932 6.70803C19.5694 6.70803 19.7932 6.48419 19.7932 6.20805L19.7933 5.20815C19.7933 4.932 19.5694 4.70813 19.2933 4.70813H6.70712C6.43098 4.70813 6.20712 4.48427 6.20712 4.20813V0.501047C6.20712 0.0555951 5.66855 -0.167487 5.35357 0.147494L0.146463 5.35457C-0.0487999 5.54983 -0.0488002 5.86642 0.146463 6.06168L5.35356 11.2688C5.66855 11.5838 6.20712 11.3607 6.20712 10.9152V7.20812C6.20712 6.93198 6.43097 6.70812 6.70711 6.70812L19.2932 6.70803Z"
          fill={arrowColor}
        />
      </G>
    </Svg>
  );
};

export default BackArrowIcon;
