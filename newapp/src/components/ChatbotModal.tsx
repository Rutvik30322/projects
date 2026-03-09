import React, { useState, useRef, useEffect } from 'react';
import { 
  View, 
  Text, 
  StyleSheet, 
  TextInput, 
  TouchableOpacity, 
  ScrollView, 
  ActivityIndicator, 
  KeyboardAvoidingView, 
  Platform, 
  Keyboard,
  Modal,
  Dimensions
} from 'react-native';
import { useTheme } from '../context/ThemeContext';
import Lottie from 'lottie-react-native';
import Logo from './Logo';
import chatbotService from '../services/chatbotService';
import Toast from 'react-native-toast-message';
import { useSafeAreaInsets } from 'react-native-safe-area-context';

interface Message {
  id: string;
  text: string;
  sender: 'user' | 'bot';
}

interface ChatbotModalProps {
  visible: boolean;
  onClose: () => void;
}

const ChatbotModal: React.FC<ChatbotModalProps> = ({ visible, onClose }) => {
  const { colors, theme } = useTheme();
  const insets = useSafeAreaInsets();
  const [messages, setMessages] = useState<Message[]>([
    { id: '1', text: 'Hello! I\'m your chocolate shopping assistant. How can I help you today?', sender: 'bot' },
  ]);
  const [inputText, setInputText] = useState('');
  const [loading, setLoading] = useState(false);
  const [keyboardVisible, setKeyboardVisible] = useState(false);
  const scrollViewRef = useRef<ScrollView>(null);
  const screenHeight = Dimensions.get('window').height;

  // Auto-scroll to bottom when new message arrives
  useEffect(() => {
    if (visible) {
      scrollViewRef.current?.scrollToEnd({ animated: true });
    }
  }, [messages, visible]);

  // Handle keyboard show/hide
  useEffect(() => {
    const keyboardDidShowListener = Keyboard.addListener(
      Platform.OS === 'ios' ? 'keyboardWillShow' : 'keyboardDidShow',
      () => {
        setKeyboardVisible(true);
        setTimeout(() => {
          scrollViewRef.current?.scrollToEnd({ animated: true });
        }, 100);
      }
    );
    const keyboardDidHideListener = Keyboard.addListener(
      Platform.OS === 'ios' ? 'keyboardWillHide' : 'keyboardDidHide',
      () => {
        setKeyboardVisible(false);
      }
    );

    return () => {
      keyboardDidShowListener.remove();
      keyboardDidHideListener.remove();
    };
  }, []);

  // Dismiss keyboard when modal closes
  useEffect(() => {
    if (!visible) {
      Keyboard.dismiss();
    }
  }, [visible]);

  const handleSend = async () => {
    if (inputText.trim() === '' || loading) return;
    
    const userMessage = inputText.trim();
    
    // Add user message
    const newUserMessage: Message = {
      id: Date.now().toString(),
      text: userMessage,
      sender: 'user',
    };
    
    setMessages(prev => [...prev, newUserMessage]);
    setInputText('');
    setLoading(true);
    
    try {
      // Build conversation history for context
      const conversationHistory = messages
        .filter(msg => msg.id !== '1') // Exclude initial greeting
        .map(msg => ({
          role: msg.sender === 'user' ? 'user' as const : 'assistant' as const,
          content: msg.text,
        }));

      // Get AI response
      const botResponseText = await chatbotService.sendMessage(userMessage, conversationHistory);
      
      const botResponse: Message = {
        id: (Date.now() + 1).toString(),
        text: botResponseText,
        sender: 'bot',
      };
      
      setMessages(prev => [...prev, botResponse]);
    } catch (error: any) {
      console.error('Chatbot error:', error);
      Toast.show({
        type: 'error',
        text1: 'Error',
        text2: 'Failed to get response. Please try again.',
        visibilityTime: 2000,
      });
      
      // Add error message
      const errorResponse: Message = {
        id: (Date.now() + 1).toString(),
        text: 'Sorry, I encountered an error. Please try again or contact support.',
        sender: 'bot',
      };
      setMessages(prev => [...prev, errorResponse]);
    } finally {
      setLoading(false);
    }
  };

  return (
    <Modal
      visible={visible}
      transparent={true}
      animationType="slide"
      onRequestClose={onClose}
      statusBarTranslucent={true}
      presentationStyle="overFullScreen"
    >
      <View style={styles.modalOverlay}>
        <View style={[
          styles.modalContainer,
          { 
            backgroundColor: colors.surface,
            paddingTop: insets.top + 10,
            paddingBottom: Math.max(insets.bottom, 20),
          }
        ]}>
          {/* Header */}
          <View style={[styles.headerContainer, { backgroundColor: colors.surface }]}>
            <View style={styles.headerContent}>
              <Logo size={50} style={styles.headerLogo} />
              <Lottie
                source={require('../assets/hello animation.json')}
                autoPlay
                loop
                style={styles.animation}
              />
              <Text style={[styles.headerTitleText, { color: colors.text }]}>Chocolate Assistant</Text>
            </View>
            <TouchableOpacity 
              style={styles.closeButton}
              onPress={onClose}
            >
              <Text style={[styles.closeButtonText, { color: colors.text }]}>✕</Text>
            </TouchableOpacity>
          </View>
          
          <View style={styles.contentWrapper}>
            <ScrollView 
              ref={scrollViewRef}
              style={styles.messagesContainer}
              contentContainerStyle={[
                styles.messagesContent,
                { paddingBottom: keyboardVisible ? 150 : 20 }
              ]}
              showsVerticalScrollIndicator={true}
              keyboardShouldPersistTaps="handled"
              keyboardDismissMode="none"
              onContentSizeChange={() => {
                if (keyboardVisible) {
                  setTimeout(() => {
                    scrollViewRef.current?.scrollToEnd({ animated: true });
                  }, 100);
                }
              }}
            >
              {messages.map((message) => (
                <View 
                  key={message.id} 
                  style={[
                    styles.messageBubble, 
                    message.sender === 'user' 
                      ? [styles.userMessage, { backgroundColor: colors.primary }] 
                      : [styles.botMessage, { backgroundColor: colors.background, borderColor: colors.textSecondary }]
                  ]}
                >
                  <Text style={[styles.messageText, { color: message.sender === 'user' ? colors.onPrimary : colors.text }]}>
                    {message.text}
                  </Text>
                </View>
              ))}
              {loading && (
                <View style={[styles.botMessage, { backgroundColor: colors.background, borderColor: colors.textSecondary }]}>
                  <ActivityIndicator size="small" color={colors.primary} />
                </View>
              )}
            </ScrollView>
            
            <KeyboardAvoidingView 
              behavior={Platform.OS === 'ios' ? 'padding' : 'height'}
              keyboardVerticalOffset={Platform.OS === 'ios' ? 0 : 0}
            >
              <View style={[styles.inputContainer, { backgroundColor: colors.surface, borderTopColor: colors.textSecondary + '30' }]}>
                <TextInput
                  style={[styles.textInput, { 
                    backgroundColor: colors.background, 
                    color: colors.text,
                    borderColor: colors.textSecondary + '40'
                  }]}
                  placeholder="Ask about products, orders, payments..."
                  placeholderTextColor={colors.textSecondary}
                  value={inputText}
                  onChangeText={setInputText}
                  onSubmitEditing={handleSend}
                  multiline
                  maxLength={500}
                  editable={!loading}
                  onFocus={() => {
                    setTimeout(() => {
                      scrollViewRef.current?.scrollToEnd({ animated: true });
                    }, 100);
                  }}
                />
                <TouchableOpacity 
                  style={[styles.sendButton, { backgroundColor: colors.primary }]} 
                  onPress={handleSend}
                  disabled={loading || inputText.trim() === ''}
                >
                  {loading ? (
                    <ActivityIndicator size="small" color={colors.onPrimary} />
                  ) : (
                    <Text style={[styles.sendButtonText, { color: colors.onPrimary }]}>Send</Text>
                  )}
                </TouchableOpacity>
              </View>
            </KeyboardAvoidingView>
          </View>
        </View>
      </View>
    </Modal>
  );
};

const styles = StyleSheet.create({
  modalOverlay: {
    flex: 1,
    backgroundColor: 'rgba(0, 0, 0, 0.5)',
    justifyContent: 'flex-end',
  },
  modalContainer: {
    borderTopLeftRadius: 20,
    borderTopRightRadius: 20,
    overflow: 'hidden',
    elevation: 10,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: -3 },
    shadowOpacity: 0.3,
    shadowRadius: 10,
    height: '85%',
    minHeight: 400,
    width: '100%',
    zIndex: 10000,
  },
  headerContainer: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'space-between',
    paddingVertical: 15,
    paddingHorizontal: 20,
    borderBottomWidth: 1,
    borderBottomColor: 'rgba(0, 0, 0, 0.1)',
  },
  headerContent: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: 8,
    flex: 1,
  },
  headerLogo: {
    marginRight: 4,
  },
  headerTitleText: {
    fontSize: 16,
    fontWeight: 'bold',
  },
  closeButton: {
    padding: 8,
    minWidth: 40,
    minHeight: 40,
    justifyContent: 'center',
    alignItems: 'center',
  },
  closeButtonText: {
    fontSize: 24,
    fontWeight: 'bold',
  },
  animation: {
    width: 40,
    height: 40,
  },
  contentWrapper: {
    flex: 1,
    minHeight: 0,
  },
  messagesContainer: {
    flex: 1,
    minHeight: 0,
  },
  messagesContent: {
    padding: 15,
    paddingBottom: 20,
    flexGrow: 1,
  },
  messageBubble: {
    maxWidth: '80%',
    padding: 12,
    marginVertical: 5,
    borderRadius: 15,
  },
  messageText: {
    fontSize: 15,
    lineHeight: 20,
  },
  userMessage: {
    alignSelf: 'flex-end',
    borderBottomRightRadius: 5,
  },
  botMessage: {
    alignSelf: 'flex-start',
    borderBottomLeftRadius: 5,
    borderWidth: 1,
  },
  inputContainer: {
    flexDirection: 'row',
    padding: 15,
    paddingBottom: Platform.OS === 'ios' ? 15 : 15,
    alignItems: 'center',
    borderTopWidth: 1,
  },
  textInput: {
    flex: 1,
    borderWidth: 1,
    borderRadius: 20,
    paddingVertical: 10,
    paddingHorizontal: 15,
    marginRight: 10,
    fontSize: 16,
    maxHeight: 100,
  },
  sendButton: {
    paddingVertical: 10,
    paddingHorizontal: 20,
    borderRadius: 20,
  },
  sendButtonText: {
    fontWeight: 'bold',
  },
});

export default ChatbotModal;
