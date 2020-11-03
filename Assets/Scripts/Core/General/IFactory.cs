public interface IFactory<TID, TProduct>
{
    TProduct Produce(TID id);
    
    int Size { get; }
}
