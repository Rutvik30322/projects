import React from 'react';
import { View, Text, TouchableOpacity, StyleSheet } from 'react-native';
import { useTheme } from '../context/ThemeContext';
import BackArrowIcon from './BackArrowIcon';
import SearchLineIcon from './SearchLineIcon';

interface ProductHeaderProps {
  title?: string;
  onBackPress: () => void;
  onSearchPress?: () => void;
}

const ProductHeader: React.FC<ProductHeaderProps> = ({ 
  title,
  onBackPress, 
  onSearchPress 
}) => {
  const { colors } = useTheme();

  return (
    <View style={[styles.header, { 
      backgroundColor: colors.surface, 
      borderBottomColor: '#C4C4C4' 
    }]}>
      <TouchableOpacity 
        style={styles.backButton}
        onPress={onBackPress}
        activeOpacity={0.7}
      >
        <BackArrowIcon size={40} />
      </TouchableOpacity>
      {title && (
        <Text style={[styles.headerTitle, { color: colors.text }]}>{title}</Text>
      )}
      <View style={styles.headerSpacer} />
      <TouchableOpacity 
        onPress={onSearchPress}
        style={styles.searchButton}
        activeOpacity={0.7}
      >
        <SearchLineIcon size={28} color={colors.text} />
      </TouchableOpacity>
    </View>
  );
};

const styles = StyleSheet.create({
  header: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'space-between',
    paddingVertical: 15,
    paddingHorizontal: 10,
    marginBottom: 0,
    borderBottomWidth: 1,
  },
  backButton: {
    padding: 5,
    minWidth: 40,
    alignItems: 'center',
    justifyContent: 'center',
  },
  headerTitle: {
    fontSize: 20,
    fontWeight: 'bold',
    fontFamily: 'Alexandria-Bold',
    marginLeft: 10,
  },
  headerSpacer: {
    flex: 1,
  },
  searchButton: {
    padding: 10,
    minWidth: 40,
    alignItems: 'center',
    justifyContent: 'center',
  },
});

export default ProductHeader;
