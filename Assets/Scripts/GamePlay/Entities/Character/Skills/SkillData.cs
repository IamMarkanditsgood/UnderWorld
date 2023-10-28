using GamePlay.Entities.Character.Skills.Enums;
using GamePlay.Entities.Character.Skills.Interface;

namespace GamePlay.Entities.Character.Skills
{
    public class SkillData 
    {
        public SkillConfig SkillConfig { get; set; }
        public SkillTypes SkillTypes{ get; set; }
        public BaseSkillUsable BaseSkill{ get; set; }

    }
}
