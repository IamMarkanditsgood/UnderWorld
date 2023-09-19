using UnityEngine;

namespace Services.ObjectPool
{
    public class PoolDestroyable : MonoBehaviour, IDestroyable
    {
        private PoolObjectSystem.ObjectPool _objectPool;


        public void Init(PoolObjectSystem.ObjectPool objectPool)
        {
            _objectPool = objectPool;
        }

        public void DestroyObject()
        {
            _objectPool.TurnOffObject(gameObject);
        }
    }
}