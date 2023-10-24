using System.Collections.Generic;
using GamePlay.Character.Skills.Dictionaries;
using GamePlay.Character.Skills.Interface;
using GamePlay.Level;
using UnityEngine;

namespace GamePlay.Character.Skills.CharacterSkills.MainSkills
{
    public class SuperKiller : MonoBehaviour, ISkillUsable
    {
        private ObjectContainer _objectContainer;
        public void UseSkill(GameObject character, SkillDictionaries skillDictionaries, SkillsConfig skillConfig)
        {
            _objectContainer = ObjectContainer.InstanceObjectContainer;
            List<GameObject> enemiesEnabledPool = _objectContainer.Enemies.EnabledPool;
            for (int i = 0; i < enemiesEnabledPool.Count; i++)
            {
                GameObject enemy = enemiesEnabledPool[i];
                //TODO use method from enemy manager to kill it
            }
        }
    }
}
