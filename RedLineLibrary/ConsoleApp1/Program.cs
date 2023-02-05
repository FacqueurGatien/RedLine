namespace RedLineTesteUnitaire
{
    internal class Program
    {
        static void Main(string[] args)
        {
            test osef = new test();
            Console.WriteLine(osef.testdico[Test.CarteQuestion]);
            Console.WriteLine(osef.testdico[Test.CarteReponse]);
            Console.WriteLine(osef.testdico[Test.Defausse]);
        }
    }
}