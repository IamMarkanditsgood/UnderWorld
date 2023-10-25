using System.Collections.Generic;
using GamePlay.Character.Components;
using GamePlay.Character.Skills;
using GamePlay.Character.Skills.CharacterSkills.MainSkills;
using GamePlay.Character.Skills.CharacterSkills.ShootSkills;
using GamePlay.Character.Skills.CharacterSkills.SupportSkills;
using GamePlay.Level.ScriptableObjects;
using UnityEngine;

namespace GamePlay.Character
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private InitialSkillsConfig _initialSkillsConfig;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private GameObject _characterBody;
        [SerializeField] private RotationManager _rotationManager;
        [SerializeField] private MovementManager _movementManager;
        [SerializeField] private SkillsManager _skillsManager;
        [SerializeField] private InteractionControl _interactionControl;
        [SerializeField] private GameObject _shield;
        [SerializeField] private GameObject _swords;
        [SerializeField] private GameObject _vortex;
        [SerializeField] private Transform _shootingSkillPos;
        private readonly InputController _inputController = new();

        private const string InteractableKey = "Interactable";

        public GameObject Shield => _shield;
        public GameObject Swords => _swords;
        public GameObject Vortex => _vortex;
        public Transform ShootingSkillPos => _shootingSkillPos;

        private void Awake()
        {
            _skillsManager.SkillDictionaries.SkillsDamage = _initialSkillsConfig.SkillsDamage;
            _skillsManager.SkillDictionaries.SkillsReloadTimer = _initialSkillsConfig.SkillsReloadTimer;
            _skillsManager.SkillDictionaries.BulletMover = _initialSkillsConfig.BulletMover;
            _skillsManager.SkillDictionaries.BulletConfig = _initialSkillsConfig.BulletConfigs;

            InitSkills();
            _rotationManager.InitData(_characterBody.transform);

            Subscribes();
        }

        private void Update()
        {
            _rotationManager.MoveRotationTarget();
            _rotationManager.RotateCharacter();

            _inputController.CheckKeyboardKeys();
            _inputController.CheckMouseKeys();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(InteractableKey))
            {
                _interactionControl.CurrentInteractableObject = other.gameObject;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(InteractableKey))
            {
                _interactionControl.CurrentInteractableObject = null;
            }
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void InitSkills()
        {
            _skillsManager.SetSkill(InputSkillVariable.Shift, SkillTypes.Teleport, new Teleport());
            _skillsManager.SetSkill(InputSkillVariable.LeftButtonMouse, SkillTypes.Arrow, new Arrow());
            _skillsManager.SetSkill(InputSkillVariable.RightButtonMouse, SkillTypes.Swords, new Swords());
        }

        private void OnShiftSkill() =>
            _skillsManager.Skills[InputSkillVariable.Shift].UseSkill(_characterBody);
        

        private void OnLeftButtonMouseSkill() =>
            _skillsManager.Skills[InputSkillVariable.LeftButtonMouse].UseSkill(_characterBody);
        

        private void OnRightButtonMouseSkill() =>
            _skillsManager.Skills[InputSkillVariable.RightButtonMouse].UseSkill(_characterBody);
        

        private void EPressed()
        {
            if (_interactionControl.CurrentInteractableObject != null)
            {
                _interactionControl.InteractWithEnvironment(_interactionControl.CurrentInteractableObject);
                _interactionControl.CurrentInteractableObject = null;
            }
        }
        private void MoveCharacter(Vector2 movementDirection)
        {
            _movementManager.MoveCharacter(movementDirection, _rigidbody);
        }
        private void Subscribes()
        {
            _inputController.OnMoveButtonsPressed += MoveCharacter;
            _inputController.OnShiftPressed += OnShiftSkill;
            _inputController.OnLeftButtonMousePressed += OnLeftButtonMouseSkill;
            _inputController.OnRightButtonMousePressed += OnRightButtonMouseSkill;
            _inputController.OnEPressed += EPressed;
        }

        private void Unsubscribe()
        {
            _inputController.OnMoveButtonsPressed -= MoveCharacter;
            _inputController.OnShiftPressed -= OnShiftSkill;
            _inputController.OnLeftButtonMousePressed -= OnLeftButtonMouseSkill;
            _inputController.OnRightButtonMousePressed -= OnRightButtonMouseSkill;
            _inputController.OnEPressed -= EPressed;
        }
    }
}