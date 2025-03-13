Console.Write("Informe um número: ");
int numero = int.Parse(Console.ReadLine());

if (PertenceFibonacci(numero))
{
    Console.WriteLine($"{numero} pertence a sequencia de Fibonacci.");
}
else
{
    Console.WriteLine($"{numero} nao pertence a sequencia de Fibonacci.");
}

static bool PertenceFibonacci(int num)
{
    int a = 0, b = 1;

    if (num == 0 || num == 1)
    {
        return true;
    }

    while (b < num)
    {
        int temp = a + b;
        a = b;
        b = temp;
    }

    return b == num; 
}