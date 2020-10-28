using System;

public interface IHealable
{
    event Action<IHealable, HealArgs> OnHealTaken;
    
    void TakeHeal(HealArgs healArgs);
}
