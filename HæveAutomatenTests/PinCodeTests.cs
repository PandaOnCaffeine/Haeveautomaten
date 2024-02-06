namespace HæveAutomatenTests
{
    public class PinCodeTests
    {
        [Theory]
        [InlineData("1234", "1234")]
        [InlineData("5678", "5678")]
        public void ShowPin_ReturnCorrectPin(string pin, string expected)
        {
            // Arrange
            PinCode pinCode = new PinCode(pin);

            // Act
            string actuel = pinCode.Pin;

            // Assert
            Xunit.Assert.Equal(expected, actuel);
        }
        [Theory]
        [InlineData("1234", "1234", true)]
        [InlineData("1234", "5678", false)]
        public void CheckPinInput_IsValid(string myPin, string inputPin, bool expected)
        {
            // Arrange
            PinCode pinCode = new PinCode(myPin);

            // Act
            bool actual = pinCode.CheckPinInput(inputPin);

            // Assert
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("1234", "5678", "5678")]
        [InlineData("5678", "5228", "5228")]
        public void ChangePin_ChangedToNewPin(string pin, string newPin, string expected)
        {
            // Arrange
            PinCode pinCode = new PinCode(pin);

            // Act
            pinCode.ChangePin(newPin);
            string actual = pinCode.Pin;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
