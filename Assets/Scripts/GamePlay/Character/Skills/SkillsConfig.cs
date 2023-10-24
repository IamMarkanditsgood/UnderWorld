using GamePlay.Bullets;
using GamePlay.Level.ScriptableObjects;
using UnityEngine;

namespace GamePlay.Character.Skills
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SkillsScriptableObject", order = 1)]
    public class SkillsConfig : ScriptableObject
    {
        [SerializeField] private GameObject _skillSound;
        [SerializeField] private SkillObjectConfig _skillObjectConfig;
        
        public GameObject SkillSound => _skillSound;
        public SkillObjectConfig SkillObjectConfig => _skillObjectConfig;
    }
}
