using UnityEngine;

namespace DefaultNamespace.Helpers
{
    public interface IPool
    {
        public GameObject GetFromPool(Vector2 position, Transform transform);
        public void LeaveToPool(GameObject obj);
    }
}