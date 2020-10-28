using System;

public interface IHealable
{
    event Action<IHealable, float> OnHealTaken;
    
    void TakeHeal(float heal);
}
