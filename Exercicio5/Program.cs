Console.WriteLine("Digite uma string:");
string input = Console.ReadLine();

char[] charArray = input.ToCharArray();

Array.Reverse(charArray);

Console.WriteLine("String invertida: " + new string(charArray));