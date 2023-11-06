using System;
using GamePlay.Entities.Bullets;
using GamePlay.Entities.Bullets.Movers;
using GamePlay.Entities.Enemies.EnemySkills;
using GamePlay.Entities.Enemies.ScriptableObject;
using GamePlay.Entities.Mines;
using GamePlay.Entities.Turrets;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace GamePlay.Entities.Enemies
{
    public class EnemyControl : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private Transform _shootingSkillPosition;
        private BaseBrain _enemyBrain;
        

        public void Initialize(BaseBrain enemyBrain)
        {
            _enemyBrain = enemyBrain;
            _enemyBrain.Initialize(_enemyConfig, _navMeshAgent,_shootingSkillPosition);
        }

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private  void Update()
        {
            _enemyBrain.CheckDistance(gameObject.transform);
        }
    }
}