using GamePlay.Entities.Character.Skills;
using GamePlay.Entities.Character.Skills.Enums;
using GamePlay.Entities.Skills.CharacterSkills;

namespace GamePlay.Entities.Skills
{
    public class SkillFinder
    {
        public SkillConfig GetSkillConfig(SkillCollection skills, SkillTypes type)
        {
            for (int i = 0; i < skills.Skills.Length;i++)
            {
                if (skills.Skills[i].SkillTypes == type)
                {
                    return skills.Skills[i];
                }
            }
            return null;
        }
    }
}