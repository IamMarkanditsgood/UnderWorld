using UnityEngine;

namespace GamePlay.Skills
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SkillsScriptableObject", order = 1)]
    public class SkillsConfig : ScriptableObject
    {
        [SerializeField] private GameObject _skillSound;
    }
}
