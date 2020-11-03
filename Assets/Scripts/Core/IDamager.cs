using System;

public interface IDamager
{
     event Action<IDamagable> Damaged;
     
     void Damage(IDamagable damagable);
}
