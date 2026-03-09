import React from 'react';
import Svg, { Path, G, Circle } from 'react-native-svg';

interface EyeOpenIconProps {
  size?: number;
  color?: string;
}

const EyeOpenIcon: React.FC<EyeOpenIconProps> = ({ size = 12, color = '#381230' }) => {
  return (
    <Svg width={size} height={size * 0.83} viewBox="0 0 12 10" fill="none">
      <G>
        <Path
          d="M6 2.24394C4.96975 2.24775 3.90177 2.45659 2.89087 2.85674C2.14029 3.16609 1.40914 3.60282 0.77417 4.14153C0.46232 4.41653 0.06431 4.81471 0 5.23954C0.06431 5.66437 0.46232 6.06255 0.77417 6.33755C1.40914 6.87626 2.14029 7.31299 2.89087 7.62234C3.90177 8.02249 4.96975 8.23133 6 8.23514C7.03025 8.23133 8.09823 8.02249 9.10913 7.62234C9.85971 7.31299 10.5909 6.87626 11.2258 6.33755C11.5377 6.06255 11.9357 5.66437 12 5.23954C11.9357 4.81471 11.5377 4.41653 11.2258 4.14153C10.5909 3.60282 9.85971 3.16609 9.10913 2.85674C8.09823 2.45659 7.03025 2.24775 6 2.24394Z"
          fill={color}
        />
        <Circle cx="6" cy="5.23954" r="1.5" fill="white" />
        <Circle cx="6" cy="5.23954" r="0.75" fill={color} />
      </G>
    </Svg>
  );
};

export default EyeOpenIcon;
