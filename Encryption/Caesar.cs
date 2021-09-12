namespace Encryption {
    public class Caesar {
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
        private static string CodeEncode(string text, int k) {
            var fullAbc   = Alphabet + Alphabet.ToUpper();
            var letterQty = fullAbc.Length;
            var retVal    = "";
            foreach (var c in text) {
                var index = fullAbc.IndexOf(c);
                if (index < 0) { retVal += c.ToString(); }
                else {
                    var codeIndex = (letterQty + index + k) % letterQty;
                    retVal += fullAbc[codeIndex];
                }
            }
            return retVal;
        }
        public static string Encrypt(string plainMessage,     int key) => CodeEncode(plainMessage,     key);
        public static string Decrypt(string encryptedMessage, int key) => CodeEncode(encryptedMessage, -key);
    }
}