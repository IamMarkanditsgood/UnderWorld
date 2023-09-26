using UnityEngine;

namespace GamePlay.Level.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PrefabsScriptableObject", order = 1)]
    public class PrefabsConfig : ScriptableObject
    {
        [SerializeField] private GameObject _zombieEnemyPrefab;

        public GameObject ZombieEnemyPrefab => _zombieEnemyPrefab;
    }
}
