using System;
using Core.Fighting.Args;

namespace Core.Fighting
{
    public interface IDamagable
    {
        event Action<IDamagable, DamageArgs> DamageTaken;
    
        void TakeDamage(DamageArgs damageArgs);
    }
}
