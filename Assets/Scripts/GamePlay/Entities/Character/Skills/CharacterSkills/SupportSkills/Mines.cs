using GamePlay.Character.Skills;
using GamePlay.Character.Skills.Dictionaries;
using GamePlay.Character.Skills.Interface;
using GamePlay.Entities.Mines;
using GamePlay.Level;
using UnityEngine;
using Zenject;

namespace GamePlay.Entities.Character.Skills.CharacterSkills.SupportSkills
{
    public class Mines : ISkillUsable
    {
        private ISpawner<Mine> _mine;

        public void UseSkill(GameObject character,SkillDictionaries skillDictionaries, SkillConfig skillConfig)
        {
            GameObject mine = _mine.Spawn("Mine", Vector3.zero).gameObject;
            mine.transform.position = character.transform.position;
        }
        [Inject]
        private void Constract(ISpawner<Mine> mine)
        {
            _mine = mine;
        }

    }
}
