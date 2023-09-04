using System.Text;

public class ConsonantEncryptor : Encryptor
{
    private readonly string[] consonants = {"b", "c", "d", "f", "g", "h", "j", "k", "l", "m",
                           "n", "p", "q", "r", "s", "t", "v", "w", "x", "y",
                           "z"};

    public ConsonantEncryptor(string key) : base(key) { }
    public override string Encrypt()
    {
        StringBuilder sb = new();
        foreach (var item in base.Key)
        {
            if (consonants.Contains(item.ToString()))
            {
                sb.Append(item + "o" + item);
            }
            else
            {
                sb.Append(item);
            }
        }
        return sb.ToString();
    }

    public override string Decrypt()
    {
        StringBuilder sb = new();
        for (int i = 0; i < base.Key.Length; i++)
        {
            sb.Append(base.Key[i]);
            if (base.Key[i + 2] == base.Key[i] && base.Key[i + 1] == 'o')
            {
                i += 2;
                continue;
            }
        }
        return sb.ToString();
    }

    public override bool ValidateKey(string key)
    {
        return key.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
    }
}