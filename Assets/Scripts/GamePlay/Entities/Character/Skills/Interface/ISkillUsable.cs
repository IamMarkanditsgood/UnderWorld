using GamePlay.Character.Skills.Dictionaries;
using GamePlay.Level;
using UnityEngine;

namespace GamePlay.Character.Skills.Interface
{
    public interface ISkillUsable<T> where T: MonoBehaviour
    {
        public void UseSkill(GameObject character,ISpawner<T> spawner,SkillDictionaries skillDictionaries, SkillConfig skillConfig);
    }
    public interface ISkillUsable
    {
        public void UseSkill(GameObject character,SkillDictionaries skillDictionaries, SkillConfig skillConfig);
    }
}
