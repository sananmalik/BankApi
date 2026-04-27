using BankApi.Domain.Interfaces;
using BankApi.Exceptions;
namespace BankApi.Domain.Entities
{
    public class StudentAccount : BankAccount, IWithdrawOnly
    {
        public StudentAccount() : base() { }
        public StudentAccount(string accNo) : base(accNo) { }
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
            decimal interest = _balance * 0.01m;
            _balance += interest;

            AddTransaction("Interest Added", interest);

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
