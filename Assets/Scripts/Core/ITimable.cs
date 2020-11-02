using System;

public interface ITimable
{
    float Capacity { get; }
    float Current { get; }
    
    event Action OnEnded;
}
