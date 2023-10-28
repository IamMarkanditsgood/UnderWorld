using UnityEngine;

namespace GamePlay.Entities.Character.Skills
{
    [CreateAssetMenu(fileName = "SkillCollection", menuName = "ScriptableObjects/Skills/Collection", order = 1)]
    public class SkillCollection : ScriptableObject
    {
        [SerializeField] private SkillConfig[] _skills;

        public SkillConfig[] Skills => _skills;

    }
}