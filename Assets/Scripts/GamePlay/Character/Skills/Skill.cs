using GamePlay.Character.Skills.Dictionaries;
using GamePlay.Character.Skills.Interface;
using UnityEngine;

namespace GamePlay.Character.Skills
{
    public class Skill
    {
        public SkillData SkillData { get; } = new();

        public Skill(ISkillUsable skillScript, SkillConfig skillConfig)
        {
            SkillData.SkillTypes = skillConfig.SkillTypes;
            SkillData.SkillConfig = skillConfig;
            SkillData.Skill = skillScript;
        }

        public void UseSkill(GameObject character)
        {
            SkillData.Skill.UseSkill(character, new SkillDictionaries(), SkillData.SkillConfig);
        }
    }
}