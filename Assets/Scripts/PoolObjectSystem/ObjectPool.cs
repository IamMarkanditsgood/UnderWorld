using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    public GameObject GetObjectFromPool(List<GameObject> freeList, List<GameObject> inUseList, GameObject prefab)
    {
        GameObject obj;
        if (freeList.Count <= 0)
        {
            CreateObjectForPool(freeList, prefab);
        }
        obj = freeList[^1];
        inUseList.Add(obj);
        freeList.Remove(obj);
        return obj;
    }

    public void CreateObjectForPool(List<GameObject> list, GameObject prefab)
    {
        GameObject obj = Object.Instantiate(prefab);
        obj.SetActive(false);
        list.Add(obj);
    }
}
