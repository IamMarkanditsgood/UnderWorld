using UnityEngine;

namespace Services.PoolObject
{
    public class PoolDestroyable : MonoBehaviour, IDestroyable
    {
        private ObjectPool _objectPool;


        public void Init(PoolObject.ObjectPool objectPool)
        {
            _objectPool = objectPool;
        }

        public void DestroyObject()
        {
            _objectPool.TurnOffObject(gameObject);
        }
    }
}