using UnityEngine;

namespace GamePlay.Entities.Enemies.EnemySkills
{
    [CreateAssetMenu(fileName = "EnemySkill", menuName = "ScriptableObjects/EnemySkill", order = 1)]
    public class EnemySkillsConfig : UnityEngine.ScriptableObject
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _recharge;

        public float Damage => _damage;
        public float Recharge => _recharge;
    }
}