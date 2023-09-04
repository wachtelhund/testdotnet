public class App
{
  public static async Task Main(string[] args)
  {
   
    Console.WriteLine("Enter a phrase to encrypt: ");
    var input = Console.ReadLine();
    ConsonantEncryptor encryptor;
    string encrypted;
    if (input is not null) {
      encryptor = new ConsonantEncryptor(input);
    } 
    else 
    {
      encryptor = new ConsonantEncryptor("The car is red");
    } 
    encrypted = encryptor.Encrypt();
    Console.WriteLine(encrypted);

    Console.WriteLine("Enter a phrase to encrypt: ");
    var input2 = Console.ReadLine();
    AlphabeticEncryptor encryptor2;
    string encrypted2;
    if (input2 is not null) {
      encryptor2 = new AlphabeticEncryptor(input2);
    } 
    else 
    {
      encryptor2 = new AlphabeticEncryptor("The car is red");
    }
    encrypted2 = encryptor2.Encrypt();
    Console.WriteLine(encrypted2);

    var http = new HttpService();
    var res = await http.GetAsync("https://icanhazdadjoke.com/", "text/plain");
    Console.WriteLine(res);
  }
}
