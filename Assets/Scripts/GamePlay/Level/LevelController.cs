using GamePlay.Level.ScriptableObjects;
using UnityEngine;

namespace GamePlay.Level
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private PrefabsConfig _prefabContainer;
        [SerializeField] private ObjectContainer _objectContainer;
        [SerializeField] private Transform _enemyContainer;

        public PrefabsConfig PrefabContainer => _prefabContainer;
        public ObjectContainer ObjectContainer => _objectContainer;
        public Transform EnemyContainer => _enemyContainer;
    }
}
