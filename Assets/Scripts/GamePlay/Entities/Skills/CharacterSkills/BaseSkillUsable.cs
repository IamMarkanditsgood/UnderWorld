using GamePlay.Entities.Character.Skills.Dictionaries;
using GamePlay.Entities.Skills.CharacterSkills;

namespace GamePlay.Entities.Character.Skills
{
    public abstract class BaseSkillUsable
    {
        protected SkillDictionaries SkillDictionaries;
        protected SkillConfig SkillConfig;

        public void Init( SkillDictionaries skillDictionaries, SkillConfig skillConfig)
        {
            SkillDictionaries = skillDictionaries;
            SkillConfig = skillConfig;
        }

        public abstract void UseSkill();
    }
}
