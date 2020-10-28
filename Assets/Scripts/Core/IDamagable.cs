using System;

public interface IDamagable
{
    event Action<IDamagable, DamageArgs> OnDamageTaken;
    
    void TakeDamage(DamageArgs damageArgs);
}
