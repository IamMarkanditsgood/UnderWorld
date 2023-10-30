using System.Collections.Generic;
using GamePlay.Entities.Character.Skills.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Level.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/InitialSkillsScriptableObject", order = 1)]
    public class InitialSkillsConfig : SerializedScriptableObject
    {
        [SerializeField] private Dictionary<SkillTypes, float> _skillsDamage;
        [SerializeField] private Dictionary<SkillTypes, float> _skillsReloadTimer;

        public Dictionary<SkillTypes, float> SkillsDamage => _skillsDamage;
        public Dictionary<SkillTypes, float> SkillsReloadTimer => _skillsDamage;
    }
}