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

            // Skapa indata enligt specifikationen
            var input = new DCMotorInput
            {
                Voltage = 12.0,
                NoLoadSpeed = 6000.0,
                Torque = 0.02,
                Efficiency = 85.0,
                Inductance = 0.013,
                Resistance = 6.0,
                EddyCurrentLosses = 0.0,
                MomentOfInertia = 0.0,
                ViscousFrictionCoefficient = 0.0
            };

            // Skriv ut indata
            DCMotorCalculator.PrintInput(input);

            // Beräkna utdata
            var output = DCMotorCalculator.Calculate(input);

            // Skriv ut utdata
            DCMotorCalculator.PrintOutput(output);

            Console.WriteLine("\nTryck på valfri tangent för att avsluta...");
            Console.ReadKey();
        }
    }
}
