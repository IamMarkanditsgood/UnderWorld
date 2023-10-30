using System.Collections.Generic;
using GamePlay.Entities.Enemies;
using GamePlay.Level;
using UnityEngine;

namespace GamePlay.Entities.Character.Skills.CharacterSkills.MainSkills
{
    public class SuperKiller : BaseSkillUsable
    {
        private readonly ISpawner<EnemyControl> _enemySpawner;

        public SuperKiller(ISpawner<EnemyControl> enemySpawner)
        {
            _enemySpawner = enemySpawner;
        }
        public override void UseSkill()
        {
            /*GameObject obj = _enemy.Spawn("Standart", transform.forward).gameObject;
            obj.GetComponent<PoolDestroyable>().DestroyObject();*/
            List<EnemyControl> enemiesEnabledPool = _enemySpawner.AllObject;
            foreach (EnemyControl enemyControl in enemiesEnabledPool)
            {
                GameObject enemy = enemyControl.gameObject;
                //TODO use method from enemy manager to kill it
            }
        }
    }
}
