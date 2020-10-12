using System;

public interface IDamagable
{
    event Action<IDamagable, float> OnDamageTaken;
    
    void TakeDamage(float damage);
}
