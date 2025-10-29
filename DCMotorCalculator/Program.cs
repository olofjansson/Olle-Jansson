using System;

namespace DCMotorCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DC Motor Beräkningsmodell");
            Console.WriteLine("========================");
            Console.WriteLine();

            // Skapa indata från användarens input
            var input = ReadInputFromUser();

            Console.WriteLine();
            
            // Skriv ut indata
            DCMotorCalculator.PrintInput(input);

            // Beräkna utdata
            var output = DCMotorCalculator.Calculate(input);

            // Skriv ut utdata
            DCMotorCalculator.PrintOutput(output);

            Console.WriteLine("\nTryck på valfri tangent för att avsluta...");
            Console.ReadKey();
        }

        /// <summary>
        /// Läser in motorparametrar från användaren
        /// </summary>
        static DCMotorInput ReadInputFromUser()
        {
            var input = new DCMotorInput();

            Console.WriteLine("Ange motorparametrar:");
            Console.WriteLine();

            input.Voltage = ReadDouble("Spänning (V)", 12.0);
            input.NoLoadSpeed = ReadDouble("No load speed (rpm)", 6000.0);
            input.Torque = ReadDouble("Moment (Nm)", 0.02);
            input.Efficiency = ReadDouble("Verkningsgrad (%)", 85.0);
            input.Inductance = ReadDouble("Induktans (H)", 0.013);
            input.Resistance = ReadDouble("Motstånd (Ω)", 6.0);
            input.EddyCurrentLosses = ReadDouble("Eddy Current Losses (W)", 0.0);
            input.MomentOfInertia = ReadDouble("Tröghetsmoment (kg·m²)", 0.0);
            input.ViscousFrictionCoefficient = ReadDouble("Viskös friktionskoefficient (Nm·s/rad)", 0.0);

            return input;
        }

        /// <summary>
        /// Läser ett decimalvärde från användaren med standardvärde
        /// </summary>
        /// <param name="prompt">Texten som visas för användaren</param>
        /// <param name="defaultValue">Standardvärde om användaren inte anger något</param>
        /// <returns>Det angivna värdet eller standardvärdet</returns>
        static double ReadDouble(string prompt, double defaultValue)
        {
            while (true)
            {
                Console.Write($"{prompt} [{defaultValue}]: ");
                string? input = Console.ReadLine();

                // Om användaren trycker enter utan att skriva något, använd standardvärdet
                if (string.IsNullOrWhiteSpace(input))
                {
                    return defaultValue;
                }

                // Försök konvertera inmatningen till ett decimaltal
                // Acceptera både punkt och komma som decimaltecken
                input = input.Replace(',', '.');
                if (double.TryParse(input, System.Globalization.NumberStyles.Float, 
                    System.Globalization.CultureInfo.InvariantCulture, out double value))
                {
                    return value;
                }

                Console.WriteLine("Ogiltigt värde. Ange ett numeriskt värde.");
            }
        }
    }
}
