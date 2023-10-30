using System;
using GamePlay.Entities.Bullets.Movers;
using GamePlay.Entities.Enemies.ScriptableObject;
using UnityEngine;
using UnityEngine.AI;

namespace GamePlay.Entities.Enemies
{
    public class EnemyControl : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private EnemyConfig _enemyConfig;
        private BaseBrain _enemyBrain;

        public void Initialize(BaseBrain enemyBrain)
        {
            _enemyBrain = enemyBrain;
            _enemyBrain.Initialize(_enemyConfig.CloseAttackDistance,_enemyConfig.FarAttackDistance,_enemyConfig.WaitDistance);

        }

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private  void Update()
        {
            _enemyBrain.CheckDistance(gameObject.transform, _navMeshAgent);
        }
    }
}