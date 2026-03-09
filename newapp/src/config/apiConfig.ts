/**
 * API Configuration
 * 
 * Update these values for production builds:
 * - PRODUCTION_API_URL: Your production server URL
 * - For HTTPS: Use 'https://your-domain.com/api'
 * - For HTTP: Make sure it's added to network_security_config.xml
 */

// // Production API URL - Update this with your production server
// export const PRODUCTION_API_URL = 'http://180.179.21.98:5000/api';

// // Development API URL - For local testing
// export const DEVELOPMENT_API_URL = 'http://180.179.21.98:5000/api';
// Production API URL - Update this with your production server
export const PRODUCTION_API_URL = 'http://180.179.21.98:5000/api';

// Development API URL - For local testing
export const DEVELOPMENT_API_URL = 'http://180.179.21.98:5000/api';

// Get API URL based on environment
export const getApiUrl = (): string => {
  // In production builds, __DEV__ will be false
  if (__DEV__) {
    return DEVELOPMENT_API_URL;
  }
  return PRODUCTION_API_URL;
};

// Export the current API URL
export const API_BASE_URL = getApiUrl();
