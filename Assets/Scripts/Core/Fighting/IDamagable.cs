using System;

public interface IDamagable
{
    event Action<IDamagable, DamageArgs> DamageTaken;
    
    void TakeDamage(DamageArgs damageArgs);
}
