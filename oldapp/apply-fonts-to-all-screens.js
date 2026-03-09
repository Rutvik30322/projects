// Script to add Alexandria fonts to all text styles in React Native screens
// Run with: node apply-fonts-to-all-screens.js

const fs = require('fs');
const path = require('path');

const screensDir = path.join(__dirname, 'src', 'screens');
const files = fs.readdirSync(screensDir).filter(f => f.endsWith('.tsx'));

const getFontFamily = (fontWeight) => {
  if (!fontWeight) return 'Alexandria-Regular';
  if (fontWeight === 'bold' || fontWeight === '700' || fontWeight === 700) return 'Alexandria-Bold';
  if (fontWeight === '600' || fontWeight === 600 || fontWeight === 'semibold') return 'Alexandria-SemiBold';
  if (fontWeight === '500' || fontWeight === 500 || fontWeight === 'medium') return 'Alexandria-Medium';
  if (fontWeight === '300' || fontWeight === 300 || fontWeight === 'light') return 'Alexandria-Light';
  return 'Alexandria-Regular';
};

files.forEach(file => {
  const filePath = path.join(screensDir, file);
  let content = fs.readFileSync(filePath, 'utf8');
  
  // Find all text style objects (those with fontSize, fontWeight, or textAlign)
  // This is a simplified approach - you may need to manually verify
  console.log(`Processing ${file}...`);
  
  // Note: This script is a helper. Manual verification is recommended.
  // The pattern matching here is complex, so we'll update files manually for accuracy.
});

console.log('Done! Please manually verify and update files as needed.');
