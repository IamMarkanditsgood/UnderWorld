using GamePlay.Entities.Bullets;
using GamePlay.Entities.Character.Skills.Enums;
using UnityEngine;

namespace GamePlay.Entities.Character.Skills
{
    [CreateAssetMenu(fileName = "SkillData", menuName = "ScriptableObjects/Skills/Skill", order = 1)]
    public class SkillConfig : ScriptableObject
    {
        [SerializeField] private SkillTypes _skillTypes;
        [SerializeField] private GameObject _skillSound;
        [SerializeField] private SkillObjectConfig _skillObjectConfig;
        
        public SkillTypes SkillTypes => _skillTypes;
        public GameObject SkillSound => _skillSound;
        public SkillObjectConfig SkillObjectConfig => _skillObjectConfig;
    }
}
