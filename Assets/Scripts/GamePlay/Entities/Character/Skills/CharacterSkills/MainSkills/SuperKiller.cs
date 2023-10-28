using System.Collections.Generic;
using GamePlay.Entities.Character.Skills.Interface;
using GamePlay.Entities.Enemies;
using GamePlay.Level;
using UnityEngine;

namespace GamePlay.Entities.Character.Skills.CharacterSkills.MainSkills
{
    public class SuperKiller : BaseSkillUsable
    {
        private ObjectContainer _objectContainer;
        private readonly ISpawner<EnemyControl> _enemySpawnerSpawner;

        public SuperKiller(ISpawner<EnemyControl> enemySpawner)
        {
            _enemySpawnerSpawner = enemySpawner;
        }
        public override void UseSkill()
        {
            /*GameObject obj = _enemy.Spawn("Standart", transform.forward).gameObject;
            obj.GetComponent<PoolDestroyable>().DestroyObject();*/
            List<EnemyControl> enemiesEnabledPool = _enemySpawnerSpawner.AllObject;
            foreach (EnemyControl enemyControl in enemiesEnabledPool)
            {
                GameObject enemy = enemyControl.gameObject;
                //TODO use method from enemy manager to kill it
            }
        }
    }
}
