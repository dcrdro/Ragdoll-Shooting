using System.Collections.Generic;
using Core.General;
using UnityEngine;

namespace Core.Scriptable
{
    public abstract class ScriptableMapperBase<K, V> : ScriptableObject, IMapper<K, V>
    {
        [SerializeField] private K[] mapperKeys;
        [SerializeField] private V[] mapperValues;

        void OnValidate()
        {
            map.Clear();
            for (int i = 0, len = mapperKeys.Length; i < len; i++)
            {
                Map(mapperKeys[i], mapperValues[i]);
            }
        }
    
        protected Dictionary<K, V> map = new Dictionary<K, V>();

        public void Map(K key, V value) => map[key] = value;

        public V this[K key] => map[key];
    }
}
