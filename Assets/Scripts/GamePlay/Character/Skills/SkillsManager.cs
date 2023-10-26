using System;
using System.Collections.Generic;
using System.Linq;
using GamePlay.Character.Skills.Dictionaries;
using GamePlay.Character.Skills.Interface;
using UnityEngine;

namespace GamePlay.Character.Skills
{
    [Serializable]
    public class SkillsManager
    {
        [SerializeField] private SkillCollection _skillCollection;

        public Dictionary<InputSkillVariable, Skill> Skills { get; } = new();

        public SkillDictionaries SkillDictionaries { get; private set; } = new();

        public void SetSkill(InputSkillVariable inputSkillVariable, SkillTypes skillTypes, ISkillUsable skillUsable)
        {
            SkillConfig skillConfig =
                _skillCollection.MainSkills.FirstOrDefault(config => config.SkillTypes == skillTypes);
            
            if (Skills.ContainsKey(inputSkillVariable))
            {
                Skills[inputSkillVariable] = new Skill(skillUsable, skillConfig);
            }
            else
            {
                Skills.Add(inputSkillVariable, new Skill(skillUsable, skillConfig));
            }
        }
    }
}