namespace BankApi.Domain.Entities
{
    public abstract class BankAccount
    {
        protected decimal _balance;

        private List<Transactions> transactions = new List<Transactions>();
        public decimal Balance => _balance;

        public string AccountNumber { get; private set; }

        public void SetAccountNumber(string accNo)
        {
            AccountNumber = accNo;
        }

        private static int accountCounter = 1000;

        public BankAccount()
        {
            accountCounter++;
            AccountNumber = "ACC" + accountCounter;
        }
        public void SetBalance(decimal amount)
        {
            _balance = amount;
        }
        public BankAccount(string accNo)
        {
            AccountNumber = accNo;
        }

        public abstract void Deposit(decimal amount);

        public abstract void ApplyInterest();
        public abstract void ShowBalance();
        public abstract void ShowTransactions();

        protected void AddTransaction(string typee, decimal amount)
        {
            transactions.Add(new Transactions
            {
                type = typee,
                Amount = amount,
                dateandtime = DateTime.Now

            });

        }
        public List<Transactions> GetTransactions()
        {
            return transactions;
        }


    }
    public class Transactions
    {
        public string type { get; set; }
        public decimal Amount { get; set; }
        public DateTime dateandtime { get; set; }


    }
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public void Print()
        {
            Console.WriteLine($"Success : {Success}");
            Console.WriteLine($"Message : {Message}");
        }
    }
    public static class Logger
    {
        public static void Log(string message, string methodname)
        {
            string path = "log.txt";
            string logmessage = $"[{DateTime.Now}]  [ERROR] [{methodname}] {message} ";
            File.AppendAllText(path, logmessage + "\n");

            Console.WriteLine(logmessage);
        }
    }
}
