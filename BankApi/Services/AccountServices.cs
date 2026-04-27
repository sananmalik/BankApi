using BankApi.Domain.Entities;
using BankApi.Domain.Interfaces;
using BankApi.Exceptions;
using Microsoft.Data.SqlClient;

namespace BankApi.Services
{
    public class AccountServices
    {
        private IAccountRepository repo;

        public AccountServices(IAccountRepository repo)
        {
            this.repo = repo;
        }

        public void Deposit(string accountNo, decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidAmountException("Invalid Amount");
            }
            BankAccount acc = repo.GetbyAccountNumber(accountNo);

            if (acc == null)
            {
                throw new AccountNotFoundException("Account not found");
            }

            acc.Deposit(amount);
            repo.UpdateBalance(accountNo, acc.Balance);
        }

        public void Transfer(string from, string to, decimal amount)
        {
            if (amount <= 0)
                throw new InvalidAmountException("Invalid amount");

            var fromAcc = repo.GetbyAccountNumber(from);
            var toAcc = repo.GetbyAccountNumber(to);

            if (fromAcc == null || toAcc == null)
                throw new AccountNotFoundException("Account not found");

            if (fromAcc.Balance < amount)
                throw new InsufficientAmountException("Insufficient balance");

            repo.TransferBalance(from, to, amount);
        }
        public void Withdraw(string accountNo, decimal amount)
        {
            if (amount <= 0)
                throw new InvalidAmountException("Invalid amount");

            var acc = repo.GetbyAccountNumber(accountNo);

            if (acc == null)
                throw new AccountNotFoundException("Account not found");

            // Check if account supports withdraw
            if (acc is IWithdrawOnly withdrawAccount)
            {
                withdrawAccount.Withdraw(amount);
                repo.UpdateBalance(accountNo, acc.Balance);
            }
            else
            {
                throw new Exception("Withdraw not supported for this account");
            }
        }
        public BankAccount GetAccount(string accountNo)
        {
            var acc = repo.GetbyAccountNumber(accountNo);

            if (acc == null)
                throw new Exception("Account not found");

            return acc;
        }

        public void ShowBalance(string accountNo)
        {
            BankAccount acc = repo.GetbyAccountNumber(accountNo);

            if (acc != null)
            {
                acc.ShowBalance();
            }
        }
    }
}
