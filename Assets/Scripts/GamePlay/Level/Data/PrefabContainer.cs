using UnityEngine;

namespace GamePlay.Level.Data
{
    public class PrefabContainer : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;

        public GameObject EnemyPrefab => _enemyPrefab;
    }
}
