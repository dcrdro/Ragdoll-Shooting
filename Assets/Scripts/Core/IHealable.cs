using System;

public interface IHealable
{
    event Action<IHealable, HealArgs> HealTaken;
    
    void TakeHeal(HealArgs healArgs);
}
