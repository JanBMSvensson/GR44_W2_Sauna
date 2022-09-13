
namespace GR44_W2_Sauna
{
    internal class SaunaEnvironment
    {
        public double TempCelcius { get; init; }

        public SaunaEnvironment(double celciusOutside)
        {
            TempCelcius = celciusOutside;
        }

        public double GetHeatAddition(double saunaTempCelcius)
        {
            return (TempCelcius - saunaTempCelcius) / 1000.0;
        }

    }
}
