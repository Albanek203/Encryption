namespace Encryption {
    public static class Scytale {
        public static string Encrypt(string text, int diameter) {
            var k           = text.Length % diameter;
            if (k > 0) text += new string(' ', diameter - k);

            var column = text.Length / diameter;
            var result = "";

            for (var i = 0; i < column; i++)
                for (var j = 0; j < diameter; j++)
                    result += text[i + column * j].ToString();

            return result;
        }
        public static string Decrypt(string text, int diameter) {
            var column  = text.Length / diameter;
            var symbols = new char[text.Length];
            var index   = 0;
            for (var i = 0; i < column; i++)
                for (var j = 0; j < diameter; j++, index++)
                    symbols[i + column * j] = text[index];

            return string.Join("", symbols);
        }
    }
}