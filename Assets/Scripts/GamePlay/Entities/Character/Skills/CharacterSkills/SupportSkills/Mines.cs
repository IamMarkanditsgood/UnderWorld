using GamePlay.Entities.Mines;
using UnityEngine;

namespace GamePlay.Entities.Character.Skills.CharacterSkills.SupportSkills
{
    public class Mines : BaseSkillUsable
    {
        private readonly ISpawner<Mine> _minesSpawner;
        private readonly Transform _spawnPoint;

        public Mines(ISpawner<Mine> minesSpawner, Transform spawnPoint)
        {
            _minesSpawner = minesSpawner;
            _spawnPoint = spawnPoint;
        }
        public override void UseSkill()
        {
            GameObject mine = _minesSpawner.Spawn("Mine", Vector3.zero).gameObject;
            mine.transform.position = _spawnPoint.position;
        }
    }
}
