using System;
using GamePlay.Character.Skills.Dictionaries;
using GamePlay.Character.Skills.Interface;
using TMPro;
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
        
        public void SetInitSkillsData(SkillTypes initialMainSkill,SkillTypes initialShootSkill,SkillTypes initialSupportSkill, ISkillUsable mainSkillScript, ISkillUsable shootSkillScript,ISkillUsable supportSkillScript)
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
        public void UseMainSkill(GameObject character)
        {
            _mainSkillData.Skill.UseSkill(character, _skillDictionaries, _mainSkillScriptableObject);
        }
        public void UseShootSkill(GameObject character)
        {
            _shootskillData.Skill.UseSkill(character, _skillDictionaries, _shootSkillScriptableObject);
        }
        public void UseSupportSkill(GameObject character)
        {
            _supportkillData.Skill.UseSkill(character, _skillDictionaries, _supportSkillScriptableObject);
        }
        
    }
}
