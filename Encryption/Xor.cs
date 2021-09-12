namespace Encryption {
    public static class Xor {
        private static string GetRepeatKey(string str, int n) {
            var rep = str;
            while (rep.Length < n) { rep += rep; }
            return rep[..n];
        }
        private static string Cipher(string text, string secretKey) {
            var currentKey = GetRepeatKey(secretKey, text.Length); 
            var res = string.Empty;
            for (var i = 0; i < text.Length; i++) res += ((char)(text[i] ^ currentKey[i])).ToString();
            return res;
        }
        public static string Encrypt(string text, string password) => Cipher(text, password);
        public static string Decrypt(string text, string password) => Cipher(text, password);
    }
}