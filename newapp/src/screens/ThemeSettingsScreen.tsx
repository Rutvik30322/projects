import React from 'react';
import { View, Text, StyleSheet, TouchableOpacity, ScrollView } from 'react-native';
import { useTheme } from '../context/ThemeContext';
import ThemedLayout from '../components/ThemedLayout';
import Logo from '../components/Logo';
import SunIcon from '../components/SunIcon';
import MoonIcon from '../components/MoonIcon';

const ThemeSettingsScreen: React.FC<{ navigation?: any }> = ({ navigation }) => {
  const { colors, theme, toggleTheme } = useTheme();

  const themeOptions = [
    {
      id: 'light',
      title: 'Light Theme',
      description: 'Bright and clean interface',
      icon: SunIcon,
      colors: {
        primary: '#663056',
        secondary: '#381230',
        background: '#FFFFFF',
        surface: '#FFFFFF',
        text: '#381230',
      },
    },
    {
      id: 'dark',
      title: 'Dark Theme',
      description: 'Easy on the eyes',
      icon: MoonIcon,
      colors: {
        primary: '#8B5CF6',
        secondary: '#FBBF24',
        background: '#111827',
        surface: '#1F2937',
        text: '#F9FAFB',
      },
    },
  ];

  const handleThemeSelect = (themeId: 'light' | 'dark') => {
    if (theme !== themeId) {
      toggleTheme();
    }
  };

  return (
    <ThemedLayout edges={['top']}>
      <View style={[styles.container, { backgroundColor: colors.background }]}>
        {/* Header */}
        <View style={[styles.header, { backgroundColor: colors.surface }]}>
          <TouchableOpacity 
            style={styles.backButton}
            onPress={() => navigation?.goBack()}
          >
            <Text style={[styles.backButtonText, { color: colors.text }]}>←</Text>
          </TouchableOpacity>
          <View style={styles.headerTitleContainer}>
            <Logo size={50} style={styles.headerLogo} />
            <Text style={[styles.headerTitle, { color: colors.text }]}>Theme Settings</Text>
          </View>
          <View style={styles.headerSpacer} />
        </View>

        <ScrollView style={styles.content} showsVerticalScrollIndicator={false}>
          <Text style={[styles.sectionTitle, { color: colors.text }]}>
            Choose Your Theme
          </Text>
          <Text style={[styles.sectionDescription, { color: colors.textSecondary }]}>
            Select a theme that suits your preference. The app will remember your choice.
          </Text>

          <View style={styles.themeOptionsContainer}>
            {themeOptions.map((option) => {
              const IconComponent = option.icon;
              const isSelected = theme === option.id;

              return (
                <TouchableOpacity
                  key={option.id}
                  style={[
                    styles.themeCard,
                    {
                      backgroundColor: colors.surface,
                      borderColor: isSelected ? colors.primary : colors.textSecondary + '30',
                      borderWidth: isSelected ? 2 : 1,
                    },
                  ]}
                  onPress={() => handleThemeSelect(option.id as 'light' | 'dark')}
                  activeOpacity={0.7}
                >
                  <View style={styles.themeCardHeader}>
                    <View
                      style={[
                        styles.iconContainer,
                        {
                          backgroundColor: option.colors.primary + '20',
                        },
                      ]}
                    >
                      <IconComponent size={32} color={option.colors.primary} />
                    </View>
                    <View style={styles.themeCardTitleContainer}>
                      <Text style={[styles.themeCardTitle, { color: colors.text }]}>
                        {option.title}
                      </Text>
                      <Text style={[styles.themeCardDescription, { color: colors.textSecondary }]}>
                        {option.description}
                      </Text>
                    </View>
                    {isSelected && (
                      <View
                        style={[
                          styles.selectedIndicator,
                          { backgroundColor: colors.primary },
                        ]}
                      >
                        <Text style={[styles.selectedCheck, { color: colors.onPrimary }]}>✓</Text>
                      </View>
                    )}
                  </View>

                  {/* Color Preview */}
                  <View style={styles.colorPreviewContainer}>
                    <View style={styles.colorPreviewRow}>
                      <View style={styles.colorPreviewItem}>
                        <View
                          style={[
                            styles.colorPreviewBox,
                            { backgroundColor: option.colors.primary },
                          ]}
                        />
                        <Text style={[styles.colorPreviewLabel, { color: colors.textSecondary }]}>
                          Primary
                        </Text>
                      </View>
                      <View style={styles.colorPreviewItem}>
                        <View
                          style={[
                            styles.colorPreviewBox,
                            { backgroundColor: option.colors.secondary },
                          ]}
                        />
                        <Text style={[styles.colorPreviewLabel, { color: colors.textSecondary }]}>
                          Secondary
                        </Text>
                      </View>
                      <View style={styles.colorPreviewItem}>
                        <View
                          style={[
                            styles.colorPreviewBox,
                            { backgroundColor: option.colors.background },
                            { borderWidth: 1, borderColor: colors.textSecondary + '30' },
                          ]}
                        />
                        <Text style={[styles.colorPreviewLabel, { color: colors.textSecondary }]}>
                          Background
                        </Text>
                      </View>
                      <View style={styles.colorPreviewItem}>
                        <View
                          style={[
                            styles.colorPreviewBox,
                            { backgroundColor: option.colors.surface },
                            { borderWidth: 1, borderColor: colors.textSecondary + '30' },
                          ]}
                        />
                        <Text style={[styles.colorPreviewLabel, { color: colors.textSecondary }]}>
                          Surface
                        </Text>
                      </View>
                    </View>
                  </View>
                </TouchableOpacity>
              );
            })}
          </View>

          {/* Info Section */}
          <View style={[styles.infoCard, { backgroundColor: colors.surface }]}>
            <Text style={[styles.infoTitle, { color: colors.text }]}>
              💡 Theme Information
            </Text>
            <Text style={[styles.infoText, { color: colors.textSecondary }]}>
              Your theme preference is saved automatically. The app will use your selected theme
              across all screens and will remember your choice for future sessions.
            </Text>
          </View>
        </ScrollView>
      </View>
    </ThemedLayout>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  header: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    padding: 20,
    elevation: 2,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 1 },
    shadowOpacity: 0.1,
    shadowRadius: 2,
  },
  headerTitleContainer: {
    flexDirection: 'row',
    alignItems: 'center',
    flex: 1,
    justifyContent: 'center',
  },
  headerLogo: {
    marginRight: 8,
  },
  headerTitle: {
    fontSize: 20,
    fontWeight: 'bold',
    flex: 1,
    textAlign: 'center',
  },
  headerSpacer: {
    width: 40,
  },
  backButton: {
    padding: 5,
    zIndex: 1,
  },
  backButtonText: {
    fontSize: 18,
    fontWeight: 'bold',
  },
  content: {
    flex: 1,
    padding: 20,
  },
  sectionTitle: {
    fontSize: 24,
    fontWeight: 'bold',
    marginBottom: 8,
  },
  sectionDescription: {
    fontSize: 14,
    marginBottom: 24,
    lineHeight: 20,
  },
  themeOptionsContainer: {
    gap: 16,
    marginBottom: 24,
  },
  themeCard: {
    borderRadius: 16,
    padding: 20,
    marginBottom: 4,
    elevation: 2,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 2 },
    shadowOpacity: 0.1,
    shadowRadius: 4,
  },
  themeCardHeader: {
    flexDirection: 'row',
    alignItems: 'center',
    marginBottom: 16,
  },
  iconContainer: {
    width: 56,
    height: 56,
    borderRadius: 28,
    justifyContent: 'center',
    alignItems: 'center',
    marginRight: 16,
  },
  themeCardTitleContainer: {
    flex: 1,
  },
  themeCardTitle: {
    fontSize: 18,
    fontWeight: 'bold',
    marginBottom: 4,
  },
  themeCardDescription: {
    fontSize: 14,
  },
  selectedIndicator: {
    width: 32,
    height: 32,
    borderRadius: 16,
    justifyContent: 'center',
    alignItems: 'center',
  },
  selectedCheck: {
    fontSize: 18,
    fontWeight: 'bold',
  },
  colorPreviewContainer: {
    marginTop: 8,
  },
  colorPreviewRow: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    gap: 8,
  },
  colorPreviewItem: {
    flex: 1,
    alignItems: 'center',
  },
  colorPreviewBox: {
    width: 40,
    height: 40,
    borderRadius: 8,
    marginBottom: 6,
  },
  colorPreviewLabel: {
    fontSize: 10,
    textAlign: 'center',
  },
  infoCard: {
    borderRadius: 12,
    padding: 16,
    marginTop: 8,
    marginBottom: 20,
  },
  infoTitle: {
    fontSize: 16,
    fontWeight: 'bold',
    marginBottom: 8,
  },
  infoText: {
    fontSize: 13,
    lineHeight: 18,
  },
});

export default ThemeSettingsScreen;
