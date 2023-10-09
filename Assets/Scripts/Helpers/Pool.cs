using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Helpers
{
    public class Pool : IPool
    {
        private readonly Stack<GameObject> _pool;
        private readonly GameObject _prefab;

        public Pool(GameObject prefab)
        {
            _prefab = prefab;
            _pool = new Stack<GameObject>();
        }

        public GameObject GetFromPool(Vector2 position, Transform transform)
        {
            if (_pool.Count > 0)
            {
                var obj = _pool.Pop();
                obj.transform.position = position;
                obj.SetActive(true);
                return obj;
            }

            return Object.Instantiate(_prefab, position, Quaternion.identity, transform);
        }

        public void LeaveToPool(GameObject obj)
        {
            obj.SetActive(false);
            _pool.Push(obj);
        }
    }
}