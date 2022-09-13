
OutputEncoding = Encoding.UTF8;

Sauna sauna = new(21.7);
bool ShowInFahrenheit = true;

WriteLine();
WriteLine();
WriteLine();
WriteLine("SAUNA MENU");
WriteLine();
WriteLine("SPACE - Add a coal brick");
WriteLine("C/F - Toggle Celsius/Fahrenheit");
WriteLine("ESC - Shut down");

int stateLabelCol = WriteAtPosition(9, 0, "Sauna state: ");
int temperatureLabelCol = WriteAtPosition(10, 0, "Sauna Temperature: ");
int coleLabelCol = WriteAtPosition(11, 0, "Coal bricks burning: ");

bool keepRunning = true;
do
{
    double temperatureCelsius = sauna.CalculateTemperature();
    
    string tempString;
    if (ShowInFahrenheit)
        tempString = $"{CelsiusToFahrenheit(temperatureCelsius):F1} \u02DAF  ";
    else
        tempString = $"{temperatureCelsius:F1} \u02DAC  ";

    WriteAtPosition(9, stateLabelCol, temperatureCelsius < 73.0 ? "too cold     " : temperatureCelsius > 77.0 ? "too hot     " : "ready to use");
    WriteAtPosition(10, temperatureLabelCol, tempString);
    WriteAtPosition(11, coleLabelCol, sauna.LevelOfCole.ToString() + "  ");
    SetCursorPosition(0,13);

    Thread.Sleep(100);
    if(KeyAvailable)
    {
        var charInfo = ReadKey(true);
        switch (charInfo.Key)
        {
            case ConsoleKey.Spacebar:
                sauna.AddCole(1);
                break;
            case ConsoleKey.F:
                ShowInFahrenheit = true;
                break;
            case ConsoleKey.C:
                ShowInFahrenheit = false;
                break;
            case ConsoleKey.Escape:
                keepRunning = false;
                break;
        }
    }
} while (keepRunning);


double CelsiusToFahrenheit(double temperatureCelsius)
{
    return 32 + temperatureCelsius * 1.8;
}

int WriteAtPosition(int row, int col, string str)
{
    SetCursorPosition(col, row);
    Write(str);
    return col + str.Length;
}
