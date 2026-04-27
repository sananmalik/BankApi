using BankApi.Domain.Interfaces;
using BankApi.Exceptions;
namespace BankApi.Domain.Entities

{
    public class CurrentAccount : BankAccount, IWithdrawOnly
    {
        public CurrentAccount() : base() { }
        public CurrentAccount(string accNo) : base(accNo) { }
        public override void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new InvalidAmountException("Invalid amount");

            _balance += amount;
            AddTransaction("Deposited", amount);
        }

        public void Withdraw(decimal amount)
        {
            if (amount > _balance)
                throw new InsufficientAmountException("Insufficient funds");

            _balance -= amount;
            AddTransaction("Withdrawn", amount);
        }

        public override void ApplyInterest()
        {
            Console.WriteLine("No interest for current account");
        }

        public override void ShowBalance()
        {
            Console.WriteLine($"{AccountNumber} Balance: {_balance}");
        }

        public override void ShowTransactions()
        {
            foreach (var t in GetTransactions())
            {
                Console.WriteLine($"{t.type} - {t.Amount} - {t.dateandtime}");
            }
        }
    }
}
