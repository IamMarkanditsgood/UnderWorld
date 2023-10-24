using System.Collections.Generic;
using GamePlay.Bullets;
using GamePlay.Character.Skills.Dictionaries;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Level.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/InitialSkillsScriptableObject", order = 1)]
    public class InitialSkillsConfig : SerializedScriptableObject
    {
        [SerializeField] private Dictionary<SkillTypes, float> _skillsDamage;
        [SerializeField] private Dictionary<SkillTypes, float> _skillsReloadTimer;
        [SerializeField] private Dictionary<SkillTypes, IBulletMovable> _bulletMover;
        [SerializeField] private Dictionary<SkillTypes, SkillObjectConfig> _bulletConfigs;

        public Dictionary<SkillTypes, float> SkillsDamage => _skillsDamage;
        public Dictionary<SkillTypes, float> SkillsReloadTimer => _skillsDamage;
        public Dictionary<SkillTypes, IBulletMovable> BulletMover => _bulletMover;
        public Dictionary<SkillTypes, SkillObjectConfig> BulletConfigs => _bulletConfigs;
    }
}