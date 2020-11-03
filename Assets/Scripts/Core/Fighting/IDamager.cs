using System;

namespace Core.Fighting
{
     public interface IDamager
     {
          event Action<IDamagable> Damaged;
     
          void Damage(IDamagable damagable);
     }
}
