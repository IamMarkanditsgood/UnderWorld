using UnityEngine;

namespace GamePlay.Character.Skills
{
    [CreateAssetMenu(fileName = "SkillCollection", menuName = "ScriptableObjects/Skills/Collection", order = 1)]
    public class SkillCollection : ScriptableObject
    {
        [SerializeField] private SkillConfig[] _mainSkills;
        [SerializeField] private SkillConfig[] _shootSkills;
        [SerializeField] private SkillConfig[] _supportSkills;

        public SkillConfig[] MainSkills => _mainSkills;
        public SkillConfig[] ShootSkills => _shootSkills;
        public SkillConfig[] SupportSkills => _supportSkills;
    }
}