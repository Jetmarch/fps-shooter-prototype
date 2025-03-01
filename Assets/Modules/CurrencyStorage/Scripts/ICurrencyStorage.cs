using System;

namespace FPSShooter.Modules.CurrencyStorage
{
    public interface ICurrencyStorage
    {
        void Get(int amount);
        int Amount { get; }
        event Action OnAmountChanged;
    }
}