using System;
using System.Collections.Generic;
using System.Linq;
using GamePlay.Entities.Character.Skills.Dictionaries;
using GamePlay.Entities.Character.Skills.Enums;
using UnityEngine;

namespace GamePlay.Entities.Character.Skills
{
    [Serializable]
    public class SkillsManager
    {
        [SerializeField] private SkillCollection _skillCollection;

        public Dictionary<InputSkillVariable, Skill> Skills { get; } = new();

        public SkillDictionaries SkillDictionaries { get; private set; } = new();

        public void SetSkill(InputSkillVariable inputSkillVariable, SkillTypes skillTypes, BaseSkillUsable baseSkillUsable)
        {
            SkillConfig skillConfig = _skillCollection.Skills.FirstOrDefault(config => config.SkillTypes == skillTypes);

            if (Skills.ContainsKey(inputSkillVariable))
            {
                Skills[inputSkillVariable] = new Skill(baseSkillUsable, skillConfig, SkillDictionaries);
            }
            else
            {
                Skills.Add(inputSkillVariable, new Skill(baseSkillUsable, skillConfig, SkillDictionaries));
            }
        }
    }
}