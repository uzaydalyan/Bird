using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Helpers
{
    public class Pool : IPool
    {
        private Stack<GameObject> _pool;
        private GameObject _prefab;

        public Pool(GameObject prefab)
        {
            _prefab = prefab;
            _pool = new Stack<GameObject>();
        }
            
        public GameObject GetFromPool(Vector2 position, Transform transform)
        {
            if (_pool.Count > 0)
            {
                GameObject obj = _pool.Pop();
                obj.transform.position = position;
                obj.SetActive(true);
                return obj;
            } else
            {
                return MonoBehaviour.Instantiate(_prefab, position, Quaternion.identity, transform);
            }
        }

        public void LeaveToPool(GameObject obj)
        {
            obj.SetActive(false);
            _pool.Push(obj);
        }
    }
}