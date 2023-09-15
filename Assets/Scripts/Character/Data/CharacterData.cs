using System.Collections.Generic;
using System.Runtime.CompilerServices;

using Skills;
using Skills.Dictionaries;
using UnityEngine;

namespace Character.Data
{
    public class CharacterData : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private GameObject _characterBody;
        [SerializeField] private Transform _rotationTarget;
        [SerializeField] private float _speedOfRotation;
        [SerializeField] private float _speedOfMoving;
        [SerializeField] private float _maxSpeedOfMoving;
        [SerializeField] private SkillsScriptableObject _mainSkillScriptableObject;
        [SerializeField] private SkillsScriptableObject _shootSkillScriptableObject;
        [SerializeField] private SkillsScriptableObject _supportSkillScriptableObject;
        private SkillData _shootskillData = new SkillData();
        private SkillData _supportkillData = new SkillData();
        private SkillData _mainSkillData = new SkillData();
        private SkillDictionaries _skillDictionaries = new SkillDictionaries();
        [SerializeField] private GameObject _currentInteractableObject;
        
        public Rigidbody Rigidbody => _rigidbody;
        public GameObject CharacterBody => _characterBody;
        public Transform RotationTarget => _rotationTarget;
        public float SpeedOfRotation => _speedOfRotation;
        public float SpeedOfMoving => _speedOfMoving;
        public float MaxSpeedOfMoving => _maxSpeedOfMoving;
        public SkillsScriptableObject MainSkillScriptableObject { get; set; }
        public SkillsScriptableObject ShootSkillScriptableObject { get; set; }
        public SkillsScriptableObject SupportSkillScriptableObject { get; set; }
        public SkillData ShootskillData => _shootskillData;
        public SkillData SupportkillData => _supportkillData;
        public SkillData MainSkillData => _mainSkillData;
        public SkillDictionaries SkillDictionaries => _skillDictionaries;
        public GameObject CurrentInteractableObject
        {
            get { return _currentInteractableObject;}
            set { _currentInteractableObject = value; }
        }


    }
}