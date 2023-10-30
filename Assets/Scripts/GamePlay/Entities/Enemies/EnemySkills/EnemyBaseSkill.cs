namespace GamePlay.Entities.Enemies.EnemySkills
{
    public abstract class EnemyBaseSkill
    {

        protected EnemySkillsConfig SkillConfig;

        public void Init( EnemySkillsConfig skillConfig)
        {
            SkillConfig = skillConfig;
        }

        public abstract void UseSkill();
    }
}