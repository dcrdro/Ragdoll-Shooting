namespace Core.General
{
    public interface IMapper<K, V>
    {
        void Map(K key, V value);
    }
}
