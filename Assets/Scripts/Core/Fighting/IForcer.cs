using System;

namespace Core.Fighting
{
     public interface IForcer
     {
          event Action<IForcer> Forced;
     
          void Force(IForceable forceable);
     }
}
