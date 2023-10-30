using GamePlay.Entities.Character.Skills.Dictionaries;

namespace GamePlay.Entities.Character.Skills
{
    public class Skill
    {
        private readonly SkillDictionaries _skillDictionaries;
        public SkillData SkillData { get; } = new();


        public Skill(BaseSkillUsable baseSkillScript, SkillConfig skillConfig, SkillDictionaries skillDictionaries)
        {
            baseSkillScript.Init(skillDictionaries,skillConfig);
            
            SkillData.SkillTypes = skillConfig.SkillTypes;
            SkillData.SkillConfig = skillConfig;
            SkillData.BaseSkill = baseSkillScript;
            _skillDictionaries = skillDictionaries;
        }

        public void UseSkill()
        {
            SkillData.BaseSkill.UseSkill();
        }
    }
}