using GamePlay.Entities.Character.Skills;
using GamePlay.Entities.Skills.CharacterSkills;

namespace GamePlay.Entities.Enemies.EnemySkills
{
    public abstract class EnemyBaseSkill
    {
        protected SkillConfig SkillConfig;
        
        public void Init( SkillConfig skillConfig)
        {
            SkillConfig = skillConfig;
        }
        public abstract void UseSkill();
    }
}