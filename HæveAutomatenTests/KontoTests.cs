namespace HæveAutomatenTests
{
    public class KontoTests
    {
        [Theory]
        [InlineData(14.31, 14.31)]
        public void Balance_VaildGet(decimal start, decimal expected)
        {
            // Arrange
            Konto account = new Konto("John", "1234", start);

            // Act
            decimal actual = account.Balance;

            // Assert
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(12.45, 4.99, "1234", "1234", 7.46)]
        [InlineData(12.45, 2.45, "6789", "6789", 10)]
        public void Withdraw_WithValidAmount_WithCorrectPin(decimal balance, decimal withdrawl, string pin, string inputPin, decimal expected)
        {
            // Arrange
            Konto account = new Konto("John", pin, balance);

            // Act
            account.Withdraw(withdrawl, inputPin);
            decimal actual = account.Balance;


            // Assert
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(12.45, 4.99, "1234", "1234", 17.44)]
        [InlineData(4.99, 4.99, "1234", "1234", 9.98)]
        public void Deposit_WithValidAmount_WithCorrectPin(decimal balance, decimal deposit, string pin, string inputPin, decimal expected)
        {
            // Arrange
            Konto account = new Konto("John", pin, balance);

            // Act
            account.Deposit(deposit, inputPin);
            decimal actual = account.Balance;


            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(14.73, 7.41, 3.12, 11.61, 10.53)]
        public void Transfer_WithValidAmount(decimal bal1, decimal bal2, decimal transfer, decimal exp1, decimal exp2)
        {
            // Arrange
            Konto acc1 = new Konto("John", "1234", bal1);
            Konto acc2 = new Konto("Jones", "1234", bal2);

            // Act
            acc1.Transfer(transfer, "1234", acc2);
            decimal actual1 = acc1.Balance;
            decimal actual2 = acc2.Balance;


            // Assert
            Assert.Equal(exp1, actual1);
            Assert.Equal(exp2, actual2);
        }
        [Theory]
        [InlineData(7.41, 3.12, 10.53)]
        public void TransferAccept_WithValidAmount(decimal bal, decimal transfer, decimal expected)
        {
            // Arrange
            Konto acc = new Konto("John", "1234", bal);

            // Act
            acc.TransferAccept(transfer);
            decimal actual = acc.Balance;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}