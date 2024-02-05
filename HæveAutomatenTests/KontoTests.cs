namespace HæveAutomatenTests
{
    [TestClass]
    public class KontoTests
    {
        [TestMethod]
        public void Balance_VaildGet()
        {
            // Arrange
            decimal startingBalance = 14.31M;
            decimal expected = 14.31M;

            Konto account = new Konto("John", "1234", startingBalance);

            // Act
            decimal actual = account.Balance;

            // Assert
            Assert.AreEqual(expected, actual, 0.001M, "Account not correct balance");
        }

        [TestMethod]
        public void CheckPin_WithValidPin()
        {
            // Arrange
            string pin = "1234";
            string testPin = "1234";
            Konto account = new Konto("john", pin, 15);

            // Act
            bool condition = account.CheckPin(testPin);

            // Assert
            Assert.IsTrue(condition, "Not correct Pin");
        }
        [TestMethod]
        public void Withdraw_WithValidAmount_WithCorrectPin()
        {
            // Arrange
            string testPin = "1234";

            decimal startBalance = 12.45M;
            decimal withdrawAmount = 4.99M;
            decimal expected = 7.46M;

            Konto account = new Konto("John", testPin, startBalance);

            // Act
            account.Withdraw(withdrawAmount, "1234");


            // Assert
            decimal actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001M, "Account not Withdrawn correctly");
        }
        [TestMethod]
        public void Deposit_WithValidAmount_WithCorrectPin()
        {
            // Arrange
            string testPin = "1234";

            decimal startBalance = 12.45M;
            decimal depositAmount = 4.99M;
            decimal expected = 17.44M;

            Konto account = new Konto("John", testPin, startBalance);

            // Act
            account.Deposit(depositAmount, "1234");


            // Assert
            decimal actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001M, "Account not deposited correctly");
        }

        [TestMethod]
        public void Transfer_WithValidAmount()
        {
            // Arrange
            decimal acc1Bal = 14.73M;
            decimal acc2Bal = 7.41M;
            decimal transferAmount = 3.12M;

            decimal acc1Expected = 11.61M;
            decimal acc2Expected = 10.53M;

            Konto acc1 = new Konto("John", "1234", acc1Bal);
            Konto acc2 = new Konto("Jones", "1234", acc2Bal);

            // Act
            acc1.Transfer(transferAmount, "1234", acc2);


            // Assert
            decimal acc1Actual = acc1.Balance;
            decimal acc2Actual = acc2.Balance;

            Assert.AreEqual(acc1Expected, acc1Actual, 0.001M, "Account not Transfered correctly");
            Assert.AreEqual(acc2Expected, acc2Actual, 0.001M, "Account not Transfered correctly");
        }
        [TestMethod]
        public void TransferAccept_WithValidAmount()
        {
            // Arrange
            decimal accBal = 7.41M;
            decimal transferAmount = 3.12M;

            decimal accExpected = 10.53M;

            Konto acc = new Konto("John", "1234", accBal);

            // Act
            acc.TransferAccept(transferAmount);


            // Assert
            decimal accActual = acc.Balance;

            Assert.AreEqual(accExpected, accActual, 0.001M, "Account not TransferAccepted correctly");
        }
    }
}