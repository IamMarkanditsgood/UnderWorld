using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Entities
{
    public interface ISpawner<T> where T : MonoBehaviour
    {
        List<T> AllObject { get; }
        T Spawn(string key, Vector3 position);
    }
}