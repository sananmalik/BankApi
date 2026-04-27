using BankApi.Domain.Interfaces;
using BankApi.Exceptions;
namespace BankApi.Domain.Entities
{
    public class SavingAccount : BankAccount, IWithdrawOnly
    {
        public SavingAccount() : base() { }
        public SavingAccount(string accNo) : base(accNo) { }
        public override void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new InsufficientAmountException("Invalid amount");

            _balance += amount;
            AddTransaction("Deposited", amount);
        }

        public void Withdraw(decimal amount)
        {
            decimal fee = amount * 0.02m;
            decimal total = amount + fee;

            if (total > _balance)
                throw new InsufficientAmountException("Insufficient funds");

            _balance -= total;
            AddTransaction("Withdrawn", amount);
        }

        public override void ApplyInterest()
        {
            decimal interest = _balance * 0.03m;
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
