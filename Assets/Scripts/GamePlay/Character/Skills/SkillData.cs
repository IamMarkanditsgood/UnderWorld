using GamePlay.Character.Skills.Interface;

namespace GamePlay.Character.Skills
{
    public class SkillData 
    {
        public SkillsConfig SkillsConfig { get; set; }
        public SkillTypes SkillTypes{ get; set; }
        public ISkillUsable Skill{ get; set; }

    }
}
