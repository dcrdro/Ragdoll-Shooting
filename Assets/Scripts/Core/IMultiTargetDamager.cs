using System;
using System.Collections.Generic;

public interface IMultiTargetDamager
{
     event Action<IEnumerable<IDamagable>> OnDamaged;
     
     void Damage(IEnumerable<IDamagable> damagables);
}
