
namespace GR44_W2_Sauna
{
    internal class Sauna
    {

        double Temperature;
        SaunaEnvironment Outside;
        List<Cole> BagOfColeBurning;

        public Sauna(double outsideCelsiusTemp)
        {
            Outside = new(outsideCelsiusTemp);
            Temperature = outsideCelsiusTemp;
            BagOfColeBurning = new();
        }

        public int LevelOfCole { get { return BagOfColeBurning.Count; } }

        public void AddCole(int count = 1)
        {
            for (int i = 0; i < count; i++)
                BagOfColeBurning.Add(new Cole());
        }

        public double CalculateTemperature()
        {
            for(int i = BagOfColeBurning.Count -1; i >= 0; i--)
            {
                Temperature += BagOfColeBurning[i].CurrentHeatAddition; // Add cole-generated heat

                if (BagOfColeBurning[i].BurnenUp)
                    BagOfColeBurning.Remove(BagOfColeBurning[i]);
            }

            Temperature += Outside.GetHeatAddition(Temperature); // Add environment-generated heat (should only be negative)

            return Temperature;
        }

    }
}
