using GamePlay.Entities.Character.Skills.Interface;
using GamePlay.Entities.Turrets;
using UnityEngine;

namespace GamePlay.Entities.Character.Skills.CharacterSkills.SupportSkills
{
    public class Turrets : BaseSkillUsable
    {
        private readonly ISpawner<Turret> _turretsSpawner;
        private readonly Transform _spawnPoint;

        public Turrets(ISpawner<Turret> turretsSpawner, Transform spawnPoint)
        {
            _turretsSpawner = turretsSpawner;
            _spawnPoint = spawnPoint;
        }
        public override void UseSkill()
        {
            GameObject turret = _turretsSpawner.Spawn("Turret", Vector3.zero).gameObject;
            turret.transform.position = _spawnPoint.position;
        }
        
    }
}
