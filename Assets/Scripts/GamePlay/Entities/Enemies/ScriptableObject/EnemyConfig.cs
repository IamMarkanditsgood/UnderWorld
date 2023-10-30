using UnityEngine;

namespace GamePlay.Entities.Enemies.ScriptableObject
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy", order = 1)]
    
    public class EnemyConfig : UnityEngine.ScriptableObject
    {
        [SerializeField] private float _closeAttackDistance;
        [SerializeField] private float _farAttackDistance;
        [SerializeField] private float _waitDistance;

        public float CloseAttackDistance => _closeAttackDistance;
        public float FarAttackDistance => _farAttackDistance;
        public float WaitDistance => _waitDistance;
    }
}