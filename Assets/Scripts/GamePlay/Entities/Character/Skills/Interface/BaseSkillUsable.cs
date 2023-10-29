using GamePlay.Entities.Character.Skills.Dictionaries;

namespace GamePlay.Entities.Character.Skills.Interface
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
