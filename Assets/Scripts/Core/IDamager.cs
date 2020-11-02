using System;

public interface IDamager
{
     event Action<IDamagable> OnDamaged;
     
     void Damage(IDamagable damagable);
}
