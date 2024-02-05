namespace HæveAutomatenTests
{
    [TestClass]
    public class BankTests
    {
        [TestMethod]
        public void ShowClientList_ReturnsListOfClients()
        {
            // Arrange
            Bank bank = new Bank("John's Bank");
            Konto client1 = new Konto("John", "1234", 14.65M);
            Konto client2 = new Konto("Jones", "1234", 4.65M);

            // Act
            bank.RegisterClient(client1);
            bank.RegisterClient(client2);
            List<Konto> clientList = bank.ShowClientList();

            // Assert
            Assert.AreEqual(2, clientList.Count, "ClientList not correct");
            Assert.AreEqual(client1, clientList[0], "Not Correct Client");
            Assert.AreEqual(client2, clientList[1], "Not Correct Client");
        }
        [TestMethod]
        public void RegisterClient_AddsClientToClientList()
        {
            // Arrange
            Bank bank = new Bank("John's Bank");
            Konto client = new Konto("John", "1234", 14.65M);

            // Act
            bank.RegisterClient(client);
            List<Konto> actualList = bank.ShowClientList();

            // Assert
            Assert.AreEqual(1, actualList.Count, "Not Regestered Correctly");
            Assert.AreEqual(client, actualList[0], "Client not correct");
        }
        [TestMethod]
        public void UnregisterClient_RemovesClientFromClientList()
        {
            // Arrange
            Bank bank = new Bank("John's Bank");
            Konto client1 = new Konto("John", "1234", 14.65M);
            Konto client2 = new Konto("Jones", "1234", 4.65M);
            Konto client3 = new Konto("James", "1234", 6.65M);

            // Act
            bank.RegisterClient(client1);
            bank.RegisterClient(client2);
            bank.RegisterClient(client3);
            bank.UnregisterClient(1);
            List<Konto> clientList = bank.ShowClientList();

            // Assert
            Assert.AreEqual(2, clientList.Count, "Not Removed Correctly");
            Assert.AreEqual(client1, clientList[0],"Not Correct Client");
            Assert.AreEqual(client3, clientList[1],"Not Correct Client");
        }
        [TestMethod]
        public void ClientLogin_WithPin_ReturnClientKonto()
        {
            Bank bank = new Bank("John's Bank");
            Konto client1 = new Konto("John", "1234", 14.65M);

            // Act
            bank.RegisterClient(client1);
            Konto actualClient = bank.ClientLogin(0, "1234");

            // Assert
            Assert.AreEqual(client1, actualClient, "Not Correct Client");
        }
    }
}

