using ConsoleApp1;
using RedLineLibrary;
using System.Reflection;
using System.Text.Json;

namespace RedLineTesteUnitaire
{
    internal class Program
    {
        static void Main(string[] args)
        {

            StreamReader fs = new StreamReader("dataList.json");
            string str = "";
            while (fs.Peek() != -1)
            {
                str += fs.ReadLine();
            }
            var ser = JsonSerializer.Deserialize<ObjectCollection>(str);
        }
    }
}