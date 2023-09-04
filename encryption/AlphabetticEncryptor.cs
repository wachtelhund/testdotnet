using System.Collections;
using System.Text;

public class AlphabeticEncryptor : Encryptor
{
    private readonly char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

    public AlphabeticEncryptor(string key) : base(key) {}
    public override string Encrypt()
    {
        var sb = new StringBuilder();
        base.Key.Select((c) => {
            if (c == ' ')
            {
                return ' ';
            }
            var index = Array.IndexOf(alphabet, c);
            if (index == alphabet.Length - 1)
            {
                return alphabet[0];
            }
            return alphabet[index + 1];
        }).ToList().ForEach((c) => sb.Append(c));
        return sb.ToString();
    }

    public override string Decrypt()
    {
        var sb = new StringBuilder();
        base.Key.Select((c) => {
            if (c == ' ')
            {
                return ' ';
            }
            var index = Array.IndexOf(alphabet, c);
            if (index == 0)
            {
                return alphabet[alphabet.Length - 1];
            }
            return alphabet[index - 1];
        }).ToList().ForEach((c) => sb.Append(c));
        return sb.ToString();
    }

    public override bool ValidateKey(string key)
    {
        return key.All((c) => {
            return alphabet.Contains(c) || Char.IsWhiteSpace(c);
        });
    }
}