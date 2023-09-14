using ConsoleApp1;
using RedLineLibrary;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
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
            ObjectCollection ser = JsonSerializer.Deserialize<ObjectCollection>(str);
            Paquet<CarteQuestion> listQuestions = new Paquet<CarteQuestion>(new());
            Paquet<CarteReponse> listReponses = new Paquet<CarteReponse>(new());

            ser.questions.ForEach(d => listQuestions.AjouterCarte(new CarteQuestion(d.texte)));
            ser.reponses.ForEach(d => listReponses.AjouterCarte(new CarteReponse(d.texte)));
            Manager manager = new Manager();
            new Plateau(manager, listQuestions, listReponses);
            Partie p = new Partie(manager);
            int nJoueur = 0;
            while (nJoueur < 3)
            {
                string nomJoueur = Console.ReadLine();
                new Joueur(manager, nomJoueur);
                nJoueur++;
            }
            manager.Event_OnPlayerChange += (j => Program.playerChange(j));
            if (manager.Demarrer())
            {
                Console.WriteLine("La partie a demarrer");
                Console.WriteLine("Le juge est " + manager.Juge.Pseudo);
               
            }
        }

        public static void playerChange(Joueur j)
        {
            Console.WriteLine("C'est au tour de " + j.Pseudo);
        }
    }
}