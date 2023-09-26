using System;
using GamePlay.Character.Skills.Dictionaries;
using UnityEngine;

namespace GamePlay.Character.Skills
{
    [Serializable]
    public class SkillsManager
    {
        [SerializeField] private SkillsConfig _mainSkillScriptableObject;
        [SerializeField] private SkillsConfig _shootSkillScriptableObject;
        [SerializeField] private SkillsConfig _supportSkillScriptableObject;
        
        private SkillData _shootskillData = new SkillData();
        private SkillData _supportkillData = new SkillData();
        private SkillData _mainSkillData = new SkillData();
        private SkillDictionaries _skillDictionaries = new SkillDictionaries();

        public SkillData ShootskillData => _shootskillData;
        public SkillData SupportkillData => _supportkillData;
        public SkillData MainSkillData => _mainSkillData;
        public SkillDictionaries SkillDictionaries => _skillDictionaries;
        
        public void SetInitialSkillsData(SkillTypes initialMainSkill,SkillTypes initialShootSkill,SkillTypes initialSupportSkill, ISkillUsable mainSkillScript, ISkillUsable shootSkillScript,ISkillUsable supportSkillScript)
        {
            _mainSkillData.SkillTypes = initialMainSkill;
            _mainSkillData.Skill = mainSkillScript;
            _mainSkillData.SkillsConfig = _mainSkillScriptableObject;
            
            _shootskillData.SkillTypes = initialShootSkill;
            _shootskillData.Skill = shootSkillScript;
            _shootskillData.SkillsConfig = _shootSkillScriptableObject;
            
            _supportkillData.SkillTypes = initialSupportSkill;
            _supportkillData.Skill = supportSkillScript;
            _supportkillData.SkillsConfig = _supportSkillScriptableObject;
        }
        public void UseSkill(ISkillUsable skill)
        {
            skill.UseSkill();
        }
    }
}
