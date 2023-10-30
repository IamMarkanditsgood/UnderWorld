using UnityEngine;
using UnityEngine.AI;

namespace GamePlay.Entities.Enemies.EnemiesBrains
{
    public class PaladinBrain: BaseBrain
    {
        private float _distanceToPlayer;
        
        public PaladinBrain(Transform playerPosition) : base(playerPosition)
        {
        }
        
        public override void CheckDistance(Transform positionOfEnemy, NavMeshAgent navMeshAgent)
        {
            _distanceToPlayer = Vector3.Distance(positionOfEnemy.position, PlayerPosition.position);
            navMeshAgent.SetDestination(PlayerPosition.transform.position);
            navMeshAgent.isStopped = false;
            if (_distanceToPlayer >= CloseAttackDistance && _distanceToPlayer <= FarAttackDistance)
            {
                Debug.Log("Far attack");
            }
            else if (_distanceToPlayer >= CloseAttackDistance && _distanceToPlayer <= WaitDistance)
            {
                Debug.Log("go");
            }
            else if (_distanceToPlayer <= CloseAttackDistance && _distanceToPlayer <= FarAttackDistance)
            {
                Debug.Log("close attack");
                navMeshAgent.isStopped = true;
            }
            else
            {
                navMeshAgent.isStopped = true;
            }
        }

        
    }
}