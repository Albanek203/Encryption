namespace Encryption {
    public class Vigenere {
        private const    string DefaultAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly string _alphabet;
        public Vigenere(string alphabet = null!) {
            _alphabet = string.IsNullOrEmpty(alphabet) ? DefaultAlphabet : alphabet;
        }
        private static string GetRepeatKey(string str, int n) {
            var rep = str;
            while (rep.Length < n) { rep += rep; }
            return rep[..n];
        }
        private string Cipher(string text, string password, bool encrypting = true) {
            var retValue = "";
            var gamma = GetRepeatKey(password, text.Length);
            var aLen  = _alphabet.Length;

            for (var i = 0; i < text.Length; i++) {
                var letterIndex = _alphabet.IndexOf(text[i]);
                var codeIndex   = _alphabet.IndexOf(gamma[i]);
                if (letterIndex < 0) {
                    retValue += text[i].ToString();
                }
                else {
                    retValue += _alphabet[(aLen + letterIndex + ((encrypting ? 1 : -1) * codeIndex)) % aLen].ToString();
                }
            }
            return retValue;
        }
        public string Encrypt(string text, string password) => Cipher(text.ToUpper(), password.ToUpper());
        public string Decrypt(string text, string password) => Cipher(text, password, false);
    }
}