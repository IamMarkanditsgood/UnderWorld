using TMPro;
using UnityEngine;
using UnityEngine.AI;

namespace GamePlay.Entities.Enemies.EnemiesBrains
{
    public class MagBrain: BaseBrain
    {
        private float _distanceToPlayer;

        public MagBrain(Transform playerPosition) : base(playerPosition)
        {
        }
        
        public override void CheckDistance(Transform positionOfEnemy, NavMeshAgent navMeshAgent)
        {
            _distanceToPlayer = Vector3.Distance(positionOfEnemy.position, PlayerPosition.position);
            if (_distanceToPlayer >= WaitDistance)
            {
                
            }
            else if (_distanceToPlayer <= FarAttackDistance)
            {
                
            }
            else
            {
                
            }
        }

        
    }
}