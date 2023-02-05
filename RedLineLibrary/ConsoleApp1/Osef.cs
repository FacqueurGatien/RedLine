namespace RedLineTesteUnitaire
{
    public abstract class Carte
    {

    }
    public class CarteReponse : Carte
    {

    }
    public class CarteQuestion : Carte
    {

    }

    public class Paquet<T> where T : Carte
    {
        public Paquet() { }
    }
    public enum Test
    {
        Defausse,
        CarteReponse,
        CarteQuestion
    }
    public class test
    {
        public Dictionary<Test, Paquet<Carte>> testdico;
        public test()
        {
            testdico = new Dictionary<Test, Paquet<Carte>>();
            testdico.Add(Test.CarteQuestion, new Paquet<Carte>());
            testdico.Add(Test.CarteReponse, new Paquet<Carte>());
            testdico.Add(Test.Defausse, new Paquet<Carte>());

        }
    }
}