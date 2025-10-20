using System;
using Xunit;

namespace DCMotorCalculator.Tests
{
    public class DCMotorCalculatorTests
    {
        [Fact]
        public void Calculate_WithGivenInputValues_ReturnsExpectedOutput()
        {
            // Arrange
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

            // Act
            var output = DCMotorCalculator.Calculate(input);

            // Assert - Kv
            Assert.Equal(500.0, output.Kv, 1);

            // Assert - Ke and Kt
            Assert.Equal(0.01909, output.Ke, 4);
            Assert.Equal(0.01909, output.Kt, 4);

            // Assert - Current
            Assert.Equal(1.047, output.Current, 2);

            // Assert - Output RPM
            Assert.Equal(2858, output.OutputRpm, 0);

            // Assert - Mechanical Power
            Assert.Equal(5.987, output.MechanicalPower, 2);

            // Assert - Electrical Power
            Assert.Equal(12.566, output.ElectricalPower, 2);
        }

        [Fact]
        public void Calculate_KvFormula_IsCorrect()
        {
            // Arrange
            var input = new DCMotorInput
            {
                Voltage = 24.0,
                NoLoadSpeed = 12000.0,
                Torque = 0.01,
                Resistance = 3.0
            };

            // Act
            var output = DCMotorCalculator.Calculate(input);

            // Assert
            // Kv = NoLoadSpeed / Voltage
            Assert.Equal(input.NoLoadSpeed / input.Voltage, output.Kv);
        }

        [Fact]
        public void Calculate_KeKtRelationship_IsCorrect()
        {
            // Arrange
            var input = new DCMotorInput
            {
                Voltage = 12.0,
                NoLoadSpeed = 6000.0,
                Torque = 0.02,
                Resistance = 6.0
            };

            // Act
            var output = DCMotorCalculator.Calculate(input);

            // Assert
            // För en DC-motor gäller att Kt = Ke (i SI-enheter)
            Assert.Equal(output.Ke, output.Kt);
        }

        [Fact]
        public void Calculate_CurrentFormula_IsCorrect()
        {
            // Arrange
            var input = new DCMotorInput
            {
                Voltage = 12.0,
                NoLoadSpeed = 6000.0,
                Torque = 0.03,
                Resistance = 6.0
            };

            // Act
            var output = DCMotorCalculator.Calculate(input);

            // Assert
            // I = T / Kt
            Assert.Equal(input.Torque / output.Kt, output.Current, 6);
        }

        [Fact]
        public void Calculate_ElectricalPowerFormula_IsCorrect()
        {
            // Arrange
            var input = new DCMotorInput
            {
                Voltage = 12.0,
                NoLoadSpeed = 6000.0,
                Torque = 0.02,
                Resistance = 6.0
            };

            // Act
            var output = DCMotorCalculator.Calculate(input);

            // Assert
            // P_el = V × I
            Assert.Equal(input.Voltage * output.Current, output.ElectricalPower, 6);
        }
    }
}
