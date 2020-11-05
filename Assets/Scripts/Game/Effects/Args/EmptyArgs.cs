using Core.Effects;

namespace Game.Effects
{
    public struct EmptyArgs : IEffectArgs
    {
        public static EmptyArgs Empty => new EmptyArgs();
    }
}