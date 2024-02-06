namespace HæveAutomatenTests
{

    public class BankTests
    {
        private static Konto client1 = new Konto("John", "1234", 14.64M);
        private static Konto client2 = new Konto("Jones", "5678", 12.64M);

        [Theory]
        [InlineData(3, 3)]
        [InlineData(4, 4)]
        public void ShowClientList_ReturnsListOfClients(int amount, int expected)
        {
            // Arrange
            Bank bank = new Bank("John's Bank");
            Konto client = new Konto("John", "1234", 14.65M);

            // Act
            for (int i = 0; i < amount; i++)
            {
                bank.RegisterClient(client);
            }
            List<Konto> clientList = bank.ShowClientList();

            // Assert
            Assert.Equal(expected, clientList.Count);
            //Assert.Equal(client1, clientList[0]);
        }
        [Theory]
        [InlineData("Jones", "Jones")]
        [InlineData("John", "John")]
        [InlineData("Jake", "Jake")]
        public void RegisterClient_AddsClientToClientList(string clientName, string expectedName)
        {
            // Arrange
            Bank bank = new Bank("John's Bank");
            Konto client = new Konto(clientName, "1234", 14.99M);

            // Act
            bank.RegisterClient(client);
            List<Konto> actualList = bank.ShowClientList();

            // Assert
            Assert.Equal(expectedName, actualList[0].Name);
        }
        [Theory]
        [InlineData("John", "1234", 14.65, "Jones", "1234", 4.65, "James", "1234", 6.65, 1)]
        public void UnregisterClient_RemovesClientFromClientList(string name1, string accountNumber1, decimal balance1,
                                                                  string name2, string accountNumber2, decimal balance2,
                                                                  string name3, string accountNumber3, decimal balance3,
                                                                  int indexToRemove)
        {
            // Arrange
            Bank bank = new Bank("John's Bank");
            Konto client1 = new Konto(name1, accountNumber1, balance1);
            Konto client2 = new Konto(name2, accountNumber2, balance2);
            Konto client3 = new Konto(name3, accountNumber3, balance3);

            // Act
            bank.RegisterClient(client1);
            bank.RegisterClient(client2);
            bank.RegisterClient(client3);
            bank.UnregisterClient(indexToRemove);
            List<Konto> clientList = bank.ShowClientList();

            // Assert
            Assert.Equal(2, clientList.Count);
            Assert.Equal(client1, clientList[0]);
            Assert.Equal(client3, clientList[1]);
        }
        [Theory]
        [InlineData("Jones", "Jones")]
        [InlineData("John", "John")]
        [InlineData("Jake", "Jake")]
        public void ClientLogin_WithPin_ReturnClientKonto(string name, string expected)
        {
            Bank bank = new Bank("John's Bank");
            Konto client1 = new Konto(name, "1234", 14.65M);

            // Act
            bank.RegisterClient(client1);
            Konto actualClient = bank.ClientLogin(0, "1234");

            // Assert
            Assert.Equal(expected, actualClient.Name);
        }
    }
}

