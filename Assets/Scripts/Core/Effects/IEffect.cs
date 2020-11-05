namespace Core.Effects
{
    public interface IEffect<T> where T : struct, IEffectArgs
    {
        void Play(in T args);
    }
}
