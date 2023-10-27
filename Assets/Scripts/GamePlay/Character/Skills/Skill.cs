using GamePlay.Character.Skills.Dictionaries;
using GamePlay.Character.Skills.Interface;
using UnityEngine;

namespace GamePlay.Character.Skills
{
    public class Skill
    {
        private readonly SkillDictionaries _skillDictionaries;
        public SkillData SkillData { get; } = new();
        

        public Skill(ISkillUsable skillScript, SkillConfig skillConfig,SkillDictionaries skillDictionaries)
        {
            SkillData.SkillTypes = skillConfig.SkillTypes;
            SkillData.SkillConfig = skillConfig;
            SkillData.Skill = skillScript;
            _skillDictionaries = skillDictionaries;
        }

        public void UseSkill(GameObject character)
        {
            SkillData.Skill.UseSkill(character, _skillDictionaries, SkillData.SkillConfig);
        }
    }
}