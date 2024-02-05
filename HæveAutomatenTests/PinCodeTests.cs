namespace HæveAutomatenTests
{
    [TestClass]
    public class PinCodeTests
    {
        [TestMethod]
        public void ShowPin_ReturnCorrectPin()
        {
            // Arrange
            string expectedPin = "1234";
            PinCode pin = new PinCode(expectedPin);

            // Act
            string actuel = pin.Pin;

            // Assert
            Assert.AreEqual(expectedPin, actuel, "Not Correct Pin");
        }
        [TestMethod]
        public void CheckPinInput_IsValid()
        {
            // Arrange
            string pin = "1234";
            string inputPin = "1234";
            PinCode pinCode = new PinCode(pin);

            // Act
            bool condition = pinCode.CheckPinInput(inputPin);

            // Assert
            Assert.IsTrue(condition, "Wrong Pin");
        }
        [TestMethod]
        public void ChangePin_ChangedToNewPin()
        {
            // Arrange
            string startingPin = "1234";
            string changedPin = "5678";
            PinCode pin = new PinCode(startingPin);

            string expectedPin = "5678";

            // Act
            pin.ChangePin(changedPin);
            string actualPin = pin.Pin;

            // Assert
            Assert.AreEqual(expectedPin, actualPin, "Not Changed Correctly");
        }
    }
}
