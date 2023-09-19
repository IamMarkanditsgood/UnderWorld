using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GamePlay.Skills;
using Skills;
using Skills.Dictionaries;
using UnityEngine;

namespace Character.Data
{
    public class CharacterData : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private GameObject _characterBody;
        [SerializeField] private GameObject _currentInteractableObject;
        [SerializeField] private Transform _rotationTarget;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _movementMaxSpeed;
        [SerializeField] private SkillsConfig _mainSkillScriptableObject;
        [SerializeField] private SkillsConfig _shootSkillScriptableObject;
        [SerializeField] private SkillsConfig _supportSkillScriptableObject;
        
        private SkillData _shootskillData = new SkillData();
        private SkillData _supportkillData = new SkillData();
        private SkillData _mainSkillData = new SkillData();
        private SkillDictionaries _skillDictionaries = new SkillDictionaries();
        private bool _isInteract = false;
        
        public Rigidbody Rigidbody => _rigidbody;
        public GameObject CharacterBody => _characterBody;
        public GameObject CurrentInteractableObject
        {
            get => _currentInteractableObject;
            set => _currentInteractableObject = value;
        }
        public Transform RotationTarget => _rotationTarget;
        public float SpeedOfRotation => _rotationSpeed;
        public float SpeedOfMoving => _movementSpeed;
        public float MaxSpeedOfMoving => _movementMaxSpeed;
        public SkillsConfig MainSkillScriptableObject
        {
            get => _mainSkillScriptableObject;
            set => _mainSkillScriptableObject = value;
        }
        public SkillsConfig ShootSkillScriptableObject
        {
            get => _shootSkillScriptableObject;
            set => _shootSkillScriptableObject = value;
        }
        public SkillsConfig SupportSkillScriptableObject
        {
            get => _supportSkillScriptableObject;
            set => _supportSkillScriptableObject = value;
        }
        public SkillData ShootskillData => _shootskillData;
        public SkillData SupportkillData => _supportkillData;
        public SkillData MainSkillData => _mainSkillData;
        public SkillDictionaries SkillDictionaries => _skillDictionaries;
        public bool IsInteract
        {
            get => _isInteract;
            set => _isInteract = value;
        }
    }
}