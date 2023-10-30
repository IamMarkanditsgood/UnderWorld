using UnityEngine;

namespace GamePlay.Level.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PrefabsScriptableObject", order = 1)]
    public class PrefabsConfig : ScriptableObject
    {
        [SerializeField] private GameObject _zombieEnemyPrefab;
        [SerializeField] private GameObject _bullet;
        [SerializeField] private GameObject _mines;
        [SerializeField] private GameObject _turrets;
        public GameObject ZombieEnemyPrefab => _zombieEnemyPrefab;
        public GameObject Bullet => _bullet;
        public GameObject Mines => _mines;
        public GameObject Turrets => _turrets;
    }
}
