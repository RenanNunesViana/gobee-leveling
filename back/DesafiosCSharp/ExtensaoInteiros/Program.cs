using Armstrong;
internal class Program
{
    private static void Main(string[] args)
    {
        List<int> armstrongNumbersList = [];
        for (int i = 1; i <= 10000; i++)
        {
            if (i.IsArmstrong())
            {
                armstrongNumbersList.Add(i);
            }
        }

        Console.WriteLine("Números de Armstrong de 1 a 10000:");
        foreach (var n in armstrongNumbersList)
        {
            Console.WriteLine(n);
        }
    }
}