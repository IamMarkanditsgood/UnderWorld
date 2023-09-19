using GamePlay.Skills;

namespace Skills
{
    public class SkillData 
    {
        public SkillsConfig SkillsConfig { get; set; }

        public SkillTypes SkillTypes{ get; set; }


        public ISkillUsable Skill{ get; set; }

    }
}
