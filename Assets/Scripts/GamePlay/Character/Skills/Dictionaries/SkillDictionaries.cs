using System.Collections.Generic;
using GamePlay.Bullets;

namespace GamePlay.Character.Skills.Dictionaries
{
    public class SkillDictionaries
    {
        public Dictionary<SkillTypes, float> SkillsDamage { get; set; } = new Dictionary<SkillTypes, float>();

        public Dictionary<SkillTypes, float> SkillsReloadTimer { get; set; } = new Dictionary<SkillTypes, float>();
    }
}
