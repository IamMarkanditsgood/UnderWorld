using GamePlay.Character.Skills.Interface;

namespace GamePlay.Character.Skills
{
    public class SkillData 
    {
        public SkillConfig SkillConfig { get; set; }
        public SkillTypes SkillTypes{ get; set; }
        public ISkillUsable Skill{ get; set; }

    }
}
