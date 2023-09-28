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
            manager.Event_OnPlayerChange += (joueur =>
            {
                if (joueur.Role != EnumRole.Participant)
                    return;
                Console.Clear();
                // ON DEMANDE SAISIE REPONSE
                
                do
                {
                    int nbCarteRep = 0;
                    do
                    {
                        playerChange(joueur);
                        Console.WriteLine("Quelle carte pour repondre a");
                        Console.WriteLine(manager.Question);
                        for (int i = 0; i < joueur.Main.Count(); i++)
                        {
                            Console.WriteLine((i + 1) + ":" + joueur.Main[i]);
                        }
                        int idSelectionne = Convert.ToInt32(Console.ReadLine()) - 1;
                        while (!joueur.SelectionnerCarte(idSelectionne))
                        {
                            Console.WriteLine("Mauvais id");
                            idSelectionne = Convert.ToInt32(Console.ReadLine()) - 1;
                        }
                        Console.WriteLine("OK");
                        nbCarteRep++;
                        //
                    } while (nbCarteRep < manager.Question.NombreDeTrous());
                } while (!joueur.DonnerReponseAuMediateur());
                // LA REPONSE DOIT ETRE BONNE POUR QUITTER LA BOUCLE
                Console.ReadKey();
                manager.ChangerJoueur();

            });

            manager.Event_OnJudgeTurnEvent += (joueur =>
            {
                Console.Clear();
                Console.WriteLine("Le juge " + joueur.Pseudo + " va juger les reponses");
                if (manager.RendreVisibleLesReponses(joueur))
                    Console.WriteLine("Retournons les reponses");
                Console.WriteLine(manager.Question);
                for (int i = 0; i < manager.Reponses.Count(); i++)
                {
                    Console.WriteLine("reponse " + (i+1));
                    Paquet<CarteReponse> reponse = manager.Reponses[i].ObtenirReponse(joueur);
                    if (reponse != null)
                    {
                        CarteReponse[] look = reponse.Regarder(joueur);
                        foreach(CarteReponse c in look)
                        {
                            Console.WriteLine(c);
                        }
                    }
                   
                   
                }
                // DEMANDE DE CHOIX DU GAGNANT
                int idSelectionne = Convert.ToInt32(Console.ReadLine()) - 1;
                bool exception = false;
                do
                {
                    try
                    {
                        manager.VoterReponse(joueur, idSelectionne);                        
                    }
                    catch (Exception e)
                    {
                        exception = true;
                    }
                } while (exception);
            });

            manager.Event_OnPlayerWinPointEvent += j =>
            {
                Console.Clear();
                Console.WriteLine(j.Pseudo + " a gagné un point");
                Console.ReadKey();
            };

            
            manager.Event_OnWin += (j =>
            {
                Console.WriteLine(j.Pseudo + " a Gagné");
            });
            manager.Demarrer();

        }

        public static void playerChange(Joueur j)
        {
            Console.WriteLine("C'est au tour de " + j.Pseudo);
        }
    }
}