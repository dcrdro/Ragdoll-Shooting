using System;
using System.Collections.Generic;

namespace Core.Fighting
{
     public interface IMultiTargetDamager
     {
          event Action<IEnumerable<IDamagable>> Damaged;
     
          void Damage(IEnumerable<IDamagable> damagables);
     }
}
