using GamePlay.Entities.Character.Skills;
using GamePlay.Entities.Enemies.EnemySkills;
using GamePlay.Entities.Skills.CharacterSkills;
using UnityEngine;

namespace GamePlay.Entities.Enemies.ScriptableObject
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy", order = 1)]
    
    public class EnemyConfig : UnityEngine.ScriptableObject
    {
        [SerializeField] private float _closeAttackDistance;
        [SerializeField] private float _farAttackDistance;
        [SerializeField] private float _waitDistance;
        [SerializeField] private SkillCollection _enemySkills;

        public float CloseAttackDistance => _closeAttackDistance;
        public float FarAttackDistance => _farAttackDistance;
        public float WaitDistance => _waitDistance;
        public SkillCollection EnemySkills=> _enemySkills;
    }
}