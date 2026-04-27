using BankApi.Domain.Entities;

namespace BankApi.Domain.Interfaces
{
    public interface IAccountRepository
    {
        void Add(BankAccount acc);
        BankAccount? GetbyAccountNumber(string accountNumber);
        void UpdateBalance(string accountNumber, decimal amount);

        void TransferBalance(string from, string to, decimal amount);
        // List<BankAccount> GetAll();
    }
}
