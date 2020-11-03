using System;
using Core.Fighting.Args;

namespace Core.Fighting
{
    public interface IHealth : IDamagable, IHealable
    {
        float HealthAmount { get; }
        float MaxHealthAmount { get; }
        bool IsDead { get; }

        event Action<DeathArgs> Died;
    }
}
