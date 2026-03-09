# Privacy Policy Setup Guide

## Overview
This guide helps you set up and publish your privacy policy for Play Store submission.

## Files Created

1. **PRIVACY_POLICY.md** - Markdown version (for documentation)
2. **PRIVACY_POLICY_HTML.html** - HTML version (for website hosting)

## Steps to Publish Privacy Policy

### Step 1: Customize the Privacy Policy

Before publishing, update the following placeholders in both files:

- `[Date]` - Replace with current date
- `[Your Contact Email]` - Your support email address
- `[Your Business Address]` - Your business physical address
- `[Your Contact Phone Number]` - Your support phone number

### Step 2: Host the Privacy Policy

You have two options:

#### Option A: Host on Your Website (Recommended)
1. Upload `PRIVACY_POLICY_HTML.html` to your website
2. Accessible URL example: `https://yourwebsite.com/privacy-policy`
3. Make sure the page is publicly accessible (no login required)

#### Option B: Use a Free Hosting Service
1. **GitHub Pages**: 
   - Create a repository
   - Upload the HTML file
   - Enable GitHub Pages
   - URL: `https://yourusername.github.io/privacy-policy`

2. **Google Sites**:
   - Create a new Google Site
   - Copy HTML content
   - Publish and get URL

3. **Privacy Policy Generators**:
   - Use services like Termly, iubenda, or PrivacyPolicies.com
   - They provide hosted privacy policies

### Step 3: Add to Play Console

1. Go to [Google Play Console](https://play.google.com/console)
2. Select your app
3. Navigate to: **Policy** → **App content** → **Privacy Policy**
4. Enter your privacy policy URL
5. Click **Save**

### Step 4: Add to App (Optional but Recommended)

You can also link to the privacy policy from your app's About screen:

1. Open `app/src/screens/AboutScreen.tsx`
2. Update the `handlePrivacyPolicy` function:

```typescript
const handlePrivacyPolicy = () => {
  Linking.openURL('https://yourwebsite.com/privacy-policy');
};
```

## Data Safety Section in Play Console

When filling the Data Safety section, reference this privacy policy. Declare:

### Data Collected:
- ✅ **Personal info** (name, email, phone)
- ✅ **Location** (delivery addresses)
- ✅ **Photos** (profile pictures)
- ✅ **App activity** (order history, cart)

### Data Shared:
- ✅ **Cloudinary** (for image storage)
- ❌ **Payment processors** (currently none - COD only)

### Security Practices:
- ✅ Data encrypted in transit
- ✅ Data encrypted at rest
- ✅ Users can request data deletion

## Quick Checklist

- [ ] Replace all placeholders in privacy policy
- [ ] Host privacy policy on website or free hosting
- [ ] Test privacy policy URL is accessible
- [ ] Add URL to Play Console
- [ ] (Optional) Add link in app's About screen
- [ ] Review privacy policy for accuracy
- [ ] Update privacy policy if app features change

## Important Notes

1. **Keep Updated**: Update privacy policy when you:
   - Add new features
   - Change data collection practices
   - Add new third-party services
   - Change data retention policies

2. **Legal Compliance**: 
   - This is a template - consider legal review
   - May need adjustments based on your jurisdiction
   - GDPR compliance if serving EU users

3. **Transparency**: 
   - Be clear about what data you collect
   - Explain why you collect it
   - Describe how users can control their data

## Example Privacy Policy URLs

- Simple: `https://yourwebsite.com/privacy`
- App-specific: `https://yourwebsite.com/dabbo/privacy-policy`
- GitHub Pages: `https://yourusername.github.io/dabbo-privacy-policy`

## Support

If you need help:
1. Review Google Play's privacy policy requirements
2. Check GDPR guidelines if serving EU users
3. Consider consulting with a privacy lawyer for complex cases

---

**Status**: ✅ Privacy Policy templates created and ready for customization
**Next Step**: Customize placeholders and host the privacy policy
