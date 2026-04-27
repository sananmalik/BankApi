namespace BankApi.Domain.Interfaces
{
    public interface IWithdrawOnly
    {
        void Withdraw(decimal amount);
    }
}