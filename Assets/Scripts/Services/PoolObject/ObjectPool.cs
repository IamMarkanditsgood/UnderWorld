using System.Collections.Generic;
using UnityEngine;

namespace Services.PoolObject
{
    public class ObjectPool
    {
        private GameObject Prefab { get; }
        private Transform Container { get; }
        
        public List<GameObject> DisabledPool { get; private set; }
        public List<GameObject> EnabledPool { get; private set; }

        public ObjectPool(GameObject prefab, int count, Transform container)
        {
            Prefab = prefab;
            Container = container;

            CreatePool(count);
        }

        private void CreatePool(int count)
        {
            DisabledPool = new List<GameObject>();
            EnabledPool = new List<GameObject>();
            for (int i = 0; i < count; i++)
            {
                CreateObject();
            }
        }

        private GameObject CreateObject(bool isActiveByDefault = false)
        {
            GameObject createObject = Object.Instantiate(Prefab, Container);

            createObject.gameObject.SetActive(isActiveByDefault);
            var destroyables = createObject.gameObject.GetComponents<PoolDestroyable>();
            if (destroyables is { Length: > 0 })
            {
                foreach (PoolDestroyable poolDestroyable in destroyables)
                {
                    poolDestroyable.Init(this);
                }
            }
            else
            {
                createObject.AddComponent<PoolDestroyable>().Init(this);
            }


            if (isActiveByDefault)
            {
                EnabledPool.Add(createObject);
            }
            else
            {
                DisabledPool.Add(createObject);
            }

            return createObject;
        }

        private bool HasFreeElement(out GameObject element)
        {
            if (DisabledPool.Count > 0)
            {
                GameObject mono = DisabledPool[0];
                element = mono;
                mono.gameObject.SetActive(true);
                EnabledPool.Add(mono);
                DisabledPool.Remove(mono);
                return true;
            }

            element = null;
            return element;
        }

        public void TurnOffObject(GameObject @object)
        {
            @object.gameObject.SetActive(false);
            EnabledPool.Remove(@object);
            DisabledPool.Add(@object);
        }

        public GameObject GetFreeElement()
        {
            return HasFreeElement(out GameObject element) ? element : CreateObject(true);
        }
    }
}