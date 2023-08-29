using TMPro;
using UnityEngine;

namespace Character.Data
{
    public class CharacterData : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;
        
        [SerializeField] private GameObject _characterBody;
        
        [SerializeField] private float _speedOfRotation;
        [SerializeField] private float _speedOfMoving;
        [SerializeField] private float _maxSpeedOfMoving;

        private MovementKeyboardData _movementKeyboardData = new();
        private MovementMouseData _movementMouseData = new();

        public MovementKeyboardData MovementKeyboardData => _movementKeyboardData;
        public MovementMouseData MovementMouseData => _movementMouseData;

        public Rigidbody Rb => _rb;


        public GameObject CharacterBody => _characterBody;
        
        public float SpeedOfRotation => _speedOfRotation;
        public float SpeedOfMoving => _speedOfMoving;
        public float MaxSpeedOfMoving => _maxSpeedOfMoving;
    }
}
