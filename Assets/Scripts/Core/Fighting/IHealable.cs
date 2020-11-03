using System;
using Core.Fighting.Args;

namespace Core.Fighting
{
    public interface IHealable
    {
        event Action<IHealable, HealArgs> HealTaken;
    
        void TakeHeal(HealArgs healArgs);
    }
}
