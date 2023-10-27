using System.Collections.Generic;
using GamePlay.Character.Skills;
using GamePlay.Character.Skills.Dictionaries;
using GamePlay.Character.Skills.Interface;
using GamePlay.Level;
using Services.PoolObject;
using UnityEngine;
using Zenject;

namespace GamePlay.Entities.Character.Skills.CharacterSkills.MainSkills
{
    public class SuperKiller : MonoBehaviour, ISkillUsable
    {
        private ObjectContainer _objectContainer;
        private ISpawner<Enemy.Enemy> _enemy;

        public void UseSkill(GameObject character, SkillDictionaries skillDictionaries, SkillConfig skillConfig)
        {
            /*GameObject obj = _enemy.Spawn("Standart", transform.forward).gameObject;
            obj.GetComponent<PoolDestroyable>().DestroyObject();*/
            List<Enemy.Enemy> enemiesEnabledPool = _enemy.AllObject;
            for (int i = 0; i < enemiesEnabledPool.Count; i++)
            {
                GameObject enemy = enemiesEnabledPool[i].gameObject;
                //TODO use method from enemy manager to kill it
            }
        }

        [Inject]
        private void Constract(ISpawner<Enemy.Enemy> enemy)
        {
            _enemy = enemy;
        }
    }
}
