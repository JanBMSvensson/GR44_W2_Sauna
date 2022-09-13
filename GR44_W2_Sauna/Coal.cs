
namespace GR44_W2_Sauna
{
    internal class Coal
    {
        double MaxCelciusPerStep = 0.1;
        int BurnTimeInSteps = 100;
        int StepsCounter = 0;

        public bool BurnenUp
        {
            get { return _BurnedUp; }
        }
        private bool _BurnedUp = false;

        public double CurrentHeatAddition
        {
            get
            {
                StepsCounter++;

                if (StepsCounter < BurnTimeInSteps / 2)
                {
                    var t = Sqrt(Pow(MaxCelciusPerStep, 2) - Pow(MaxCelciusPerStep * (BurnTimeInSteps - StepsCounter) / BurnTimeInSteps, 2));
                    return t;
                }
                else if (StepsCounter < BurnTimeInSteps) {
                    var t = Sqrt(Pow(MaxCelciusPerStep, 2) - Pow(MaxCelciusPerStep * StepsCounter / BurnTimeInSteps, 2));
                    return t;
                }

                _BurnedUp = true;
                return 0.0;
            }
        }

    }
}
