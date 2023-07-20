using RedLineLibrary;

namespace RedLineTesteUnitaire
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarteQuestion cq = new CarteQuestion("Je n'ai jamais compris {0} avant de voir {1}");
            Console.WriteLine(cq.ToString());
        }
    }
}