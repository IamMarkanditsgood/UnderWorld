using UnityEngine;

namespace Character.Data
{
    public class CharacterData : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private GameObject _characterBody;
        [SerializeField] private float _speedOfRotation;
        [SerializeField] private float _speedOfMoving;
        [SerializeField] private float _maxSpeedOfMoving;

        public Rigidbody Rigidbody => _rigidbody;
        public GameObject CharacterBody => _characterBody;
        public float SpeedOfRotation => _speedOfRotation;
        public float SpeedOfMoving => _speedOfMoving;
        public float MaxSpeedOfMoving => _maxSpeedOfMoving;
    }
}