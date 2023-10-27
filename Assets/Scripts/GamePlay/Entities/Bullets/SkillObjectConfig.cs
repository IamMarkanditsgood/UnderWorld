using UnityEngine;

namespace GamePlay.Bullets
{
    [CreateAssetMenu(fileName = "SkillObject", menuName = "ScriptableObjects/SkillObject", order = 1)]
    public class SkillObjectConfig : ScriptableObject
    {
        [SerializeField] private GameObject _sound;
        [SerializeField] private float _speed;
        
        public GameObject Sound => _sound;
        public float Speed => _speed;
    }
}
