using System.Linq;

namespace Encryption {
    public static class Atbash {
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
        private static string Reverse(string inputText) =>
            inputText.Aggregate(string.Empty, (current, symbol) => symbol + current);
        private static string Cipher(string text, string symbols, string cipher) {
            text = text.ToLower();
            return text.Select(t => symbols.IndexOf(t)).Where(index => index >= 0)
                .Aggregate(string.Empty, (current, index) => current + cipher[index]);
        }
        public static string Encrypt(string plainText)     => Cipher(plainText,     Alphabet, Reverse(Alphabet));
        public static string Decrypt(string encryptedText) => Cipher(encryptedText, Reverse(Alphabet), Alphabet);
    }
}