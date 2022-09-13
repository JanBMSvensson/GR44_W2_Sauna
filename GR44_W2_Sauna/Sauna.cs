
namespace GR44_W2_Sauna
{
    internal class Sauna
    {

        double Temperature;
        SaunaEnvironment Outside;
        List<Coal> BagOfBurningCoal;

        public Sauna(double outsideCelsiusTemp)
        {
            Outside = new(outsideCelsiusTemp);
            Temperature = outsideCelsiusTemp;
            BagOfBurningCoal = new();
        }

        public int LevelOfCole { get { return BagOfBurningCoal.Count; } }

        public void AddCole(int count = 1)
        {
            for (int i = 0; i < count; i++)
                BagOfBurningCoal.Add(new Coal());
        }

        public double CalculateTemperature()
        {
            for(int i = BagOfBurningCoal.Count -1; i >= 0; i--)
            {
                Temperature += BagOfBurningCoal[i].CurrentHeatAddition; // Add cole-generated heat

                if (BagOfBurningCoal[i].BurnenUp)
                    BagOfBurningCoal.Remove(BagOfBurningCoal[i]);
            }

            Temperature += Outside.GetHeatAddition(Temperature); // Add environment-generated heat (should only be negative)

            return Temperature;
        }

    }
}
