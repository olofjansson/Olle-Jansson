using System;

namespace DCMotorCalculator
{
    /// <summary>
    /// Representerar indata för en DC-motor
    /// </summary>
    public class DCMotorInput
    {
        /// <summary>
        /// Spänning (V)
        /// </summary>
        public double Voltage { get; set; }

        /// <summary>
        /// No load speed (rpm)
        /// </summary>
        public double NoLoadSpeed { get; set; }

        /// <summary>
        /// Moment (Nm)
        /// </summary>
        public double Torque { get; set; }

        /// <summary>
        /// Verkningsgrad (%)
        /// </summary>
        public double Efficiency { get; set; }

        /// <summary>
        /// Induktans (H)
        /// </summary>
        public double Inductance { get; set; }

        /// <summary>
        /// Motstånd (Ω)
        /// </summary>
        public double Resistance { get; set; }

        /// <summary>
        /// Eddy Current Losses (W)
        /// </summary>
        public double EddyCurrentLosses { get; set; }

        /// <summary>
        /// Tröghetsmoment (kg·m²)
        /// </summary>
        public double MomentOfInertia { get; set; }

        /// <summary>
        /// Viskös friktionskoefficient (Nm·s/rad)
        /// </summary>
        public double ViscousFrictionCoefficient { get; set; }
    }

    /// <summary>
    /// Representerar utdata från DC-motor beräkningar
    /// </summary>
    public class DCMotorOutput
    {
        /// <summary>
        /// Ström (A)
        /// </summary>
        public double Current { get; set; }

        /// <summary>
        /// Output rpm
        /// </summary>
        public double OutputRpm { get; set; }

        /// <summary>
        /// Mekanisk effekt (W)
        /// </summary>
        public double MechanicalPower { get; set; }

        /// <summary>
        /// Elektrisk effekt (W)
        /// </summary>
        public double ElectricalPower { get; set; }

        /// <summary>
        /// Kt - Torque constant (Nm/A)
        /// </summary>
        public double Kt { get; set; }

        /// <summary>
        /// Ke - Back EMF constant (V/(rad/s))
        /// </summary>
        public double Ke { get; set; }

        /// <summary>
        /// Kv - Speed constant (rpm/V)
        /// </summary>
        public double Kv { get; set; }
    }

    /// <summary>
    /// DC-motor beräkningsmodell
    /// </summary>
    public class DCMotorCalculator
    {
        /// <summary>
        /// Beräknar motorns utdata baserat på indata
        /// </summary>
        /// <param name="input">Motor indata</param>
        /// <returns>Motor utdata</returns>
        public static DCMotorOutput Calculate(DCMotorInput input)
        {
            var output = new DCMotorOutput();

            // 1. Beräkna Kv (Speed constant)
            output.Kv = input.NoLoadSpeed / input.Voltage;

            // 2. Beräkna Ke (Back EMF constant)
            // Ke = 60 / (2π × Kv)
            output.Ke = 60.0 / (2.0 * Math.PI * output.Kv);

            // 3. Beräkna Kt (Torque constant)
            // För en DC-motor gäller att Kt = Ke (i SI-enheter)
            output.Kt = output.Ke;

            // 4. Beräkna Ström (Current)
            // I = T / Kt
            output.Current = input.Torque / output.Kt;

            // 5. Beräkna Output rpm
            // V = Ke × ω + I × R
            // ω = (V - I × R) / Ke
            double angularVelocity = (input.Voltage - output.Current * input.Resistance) / output.Ke;
            output.OutputRpm = angularVelocity * 60.0 / (2.0 * Math.PI);

            // 6. Beräkna Mekanisk effekt
            // P_mek = T × ω
            output.MechanicalPower = input.Torque * angularVelocity;

            // 7. Beräkna Elektrisk effekt
            // P_el = V × I
            output.ElectricalPower = input.Voltage * output.Current;

            return output;
        }

        /// <summary>
        /// Skriver ut indata på ett formaterat sätt
        /// </summary>
        public static void PrintInput(DCMotorInput input)
        {
            Console.WriteLine("=== INDATA ===");
            Console.WriteLine($"Spänning (V):                      {input.Voltage} V");
            Console.WriteLine($"No load speed:                     {input.NoLoadSpeed} rpm");
            Console.WriteLine($"Moment (Nm):                       {input.Torque} Nm");
            Console.WriteLine($"Verkningsgrad (η):                 {input.Efficiency} %");
            Console.WriteLine($"Induktans (L):                     {input.Inductance} H");
            Console.WriteLine($"Motstånd (R):                      {input.Resistance} Ω");
            Console.WriteLine($"Eddy Current Losses:               {input.EddyCurrentLosses} W");
            Console.WriteLine($"Tröghetsmoment (J):                {input.MomentOfInertia} kg·m²");
            Console.WriteLine($"Viskös friktionskoefficient (B):   {input.ViscousFrictionCoefficient} Nm·s/rad");
            Console.WriteLine();
        }

        /// <summary>
        /// Skriver ut utdata på ett formaterat sätt
        /// </summary>
        public static void PrintOutput(DCMotorOutput output)
        {
            Console.WriteLine("=== UTDATA ===");
            Console.WriteLine($"Ström (I):                         {output.Current:F3} A");
            Console.WriteLine($"Output rpm:                        {output.OutputRpm:F0} rpm");
            Console.WriteLine($"Mekanisk effekt:                   {output.MechanicalPower:F3} W");
            Console.WriteLine($"Elektrisk effekt:                  {output.ElectricalPower:F3} W");
            Console.WriteLine($"Kt:                                {output.Kt:F5} Nm/A");
            Console.WriteLine($"Ke:                                {output.Ke:F5} V/(rad/s)");
            Console.WriteLine($"Kv:                                {output.Kv:F1} rpm/V");
            Console.WriteLine();
            
            // Beräkna verklig verkningsgrad
            double actualEfficiency = (output.MechanicalPower / output.ElectricalPower) * 100.0;
            Console.WriteLine($"Beräknad verkningsgrad:            {actualEfficiency:F2} %");
        }
    }
}
