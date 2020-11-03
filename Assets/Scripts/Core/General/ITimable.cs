using System;

namespace Core.General
{
    public interface ITimable
    {
        float Capacity { get; }
        float Current { get; }
    
        event Action Ended;
    }
}
