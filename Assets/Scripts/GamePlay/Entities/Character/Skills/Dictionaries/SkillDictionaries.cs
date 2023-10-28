using System.Collections.Generic;
using GamePlay.Entities.Character.Skills.Enums;

namespace GamePlay.Entities.Character.Skills.Dictionaries
{
    public class SkillDictionaries
    {
        public Dictionary<SkillTypes, float> SkillsDamage { get; set; } = new Dictionary<SkillTypes, float>();

        public Dictionary<SkillTypes, float> SkillsReloadTimer { get; set; } = new Dictionary<SkillTypes, float>();
    }
}
