public abstract class Encryptor {
    private char[]? _key;

    /// <summary>
    /// The key used to encrypt and decrypt the message
    /// valid keys are strings and depend on the subclasses implementation of ValidateKey
    /// </summary>
    public string Key {
        get => new(_key);
        set {
            if (value is not null && this.ValidateKey(value))
            {
                _key = value.ToCharArray();
            }
            else
            {
                throw new ArgumentException("Invalid key");
            }
        }
    }

    public Encryptor(string key) {
        this.Key = key;
    }

    public abstract bool ValidateKey(string key);
    public abstract string Encrypt();
    public abstract string Decrypt();
}