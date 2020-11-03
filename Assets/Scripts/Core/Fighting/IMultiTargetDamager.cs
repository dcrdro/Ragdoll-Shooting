using System;
using System.Collections.Generic;

public interface IMultiTargetDamager
{
     event Action<IEnumerable<IDamagable>> Damaged;
     
     void Damage(IEnumerable<IDamagable> damagables);
}
