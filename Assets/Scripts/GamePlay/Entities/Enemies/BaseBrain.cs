using UnityEngine;
using UnityEngine.AI;

namespace GamePlay.Entities.Enemies
{
    public abstract class BaseBrain
    {
        protected float CloseAttackDistance;
        protected float FarAttackDistance;
        protected float WaitDistance;
        protected readonly Transform PlayerPosition;


        public BaseBrain(Transform playerPosition)
        {
            PlayerPosition = playerPosition;
        }
        public abstract void CheckDistance(Transform positionOfEnemy, NavMeshAgent navMeshAgent);
        
        public virtual void Initialize(float closeAttackDistance, float farAttackDistance, float waitDistance)
        {
            CloseAttackDistance = closeAttackDistance;
            FarAttackDistance = farAttackDistance;
            WaitDistance = waitDistance;
        }
        public virtual void Move()
        {
            Debug.Log("MOve");
        }

        public virtual void Attack()
        {
            Debug.Log("Attack");
        }
    }
}