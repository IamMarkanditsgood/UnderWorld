using GamePlay.Entities.Bullets;
using GamePlay.Entities.Enemies.EnemySkills;
using GamePlay.Entities.Enemies.ScriptableObject;
using UnityEngine;
using UnityEngine.AI;

namespace GamePlay.Entities.Enemies
{
    public abstract class BaseBrain
    {
        protected float CloseAttackDistance;
        protected float FarAttackDistance;
        protected float WaitDistance;
        protected Transform ShootingSkillPosition;
        protected readonly ISpawner<BulletObject> BulletSpawner;
        protected readonly Transform PlayerPosition;
        protected EnemyConfig EnemyConfig;
        
        protected NavMeshAgent NavMeshAgent;
        public BaseBrain(Transform playerPosition,ISpawner<BulletObject> bulletSpawner)
        {
            PlayerPosition = playerPosition;
            BulletSpawner = bulletSpawner;
            
        }
        public abstract void CheckDistance(Transform positionOfEnemy);
        
        public virtual void Initialize(EnemyConfig enemyConfig, NavMeshAgent navMeshAgent, Transform shootingSkillPosition)
        {
            EnemyConfig = enemyConfig;
            CloseAttackDistance = enemyConfig.CloseAttackDistance;
            FarAttackDistance = enemyConfig.FarAttackDistance;
            WaitDistance = enemyConfig.WaitDistance;
            
            NavMeshAgent = navMeshAgent;
            ShootingSkillPosition = shootingSkillPosition;
            InitializeSkills();
        }
        
        public abstract void InitializeSkills();
        public virtual void SetDestination()
        {
            NavMeshAgent.SetDestination(PlayerPosition.transform.position);
        }
        public virtual void Move()
        {
            NavMeshAgent.isStopped = false;
        }
        public virtual void Stop()
        {
            NavMeshAgent.isStopped = true;
            
        }
        public virtual void Attack(EnemyBaseSkill enemyBaseSkill)
        {
            enemyBaseSkill.UseSkill();
        }
    }
}