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

            _rotationManager.InitData(_characterBody.transform);
            
            _skillsManager.SetInitSkillsData(SkillTypes.Shield, SkillTypes.Arrow, SkillTypes.Swords, new Shield(), new Arrow(), new Swords());
            
            _inputController.OnMoveButtonsPressed += MoveCharacter;
            _inputController.OnShiftPressed += ShiftPressed;
            _inputController.OnLeftButtonMousePressed += LeftButtonMousePressed ;
            _inputController.OnRightButtonMousePressed += RightButtonMousePressed;
            _inputController.OnEPressed += EPressed;
        }

        private void Update()
        {
            _rotationManager.MoveRotationTarget();
            _inputController.CheckKeyboardKeys();
            _inputController.CheckMouseKeys();
        }

        private void FixedUpdate()
        {
            _rotationManager.RotateCharacter();
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
            _inputController.OnMoveButtonsPressed -= MoveCharacter;
            _inputController.OnShiftPressed -= ShiftPressed;
            _inputController.OnLeftButtonMousePressed -= LeftButtonMousePressed;
            _inputController.OnRightButtonMousePressed -= RightButtonMousePressed;
            _inputController.OnEPressed -= EPressed;
        }

        private void MoveCharacter(Vector2 movementDirection)
        {
            _movementManager.MoveCharacter(movementDirection, _rigidbody);
        }
        private void ShiftPressed()
        {
            _skillsManager.UseMainSkill(_characterBody);
        }

        private void LeftButtonMousePressed()
        {
            _skillsManager.UseShootSkill(_characterBody);
        }

        private void RightButtonMousePressed()
        {
            _skillsManager.UseSupportSkill(_characterBody);
        }
        private void EPressed()
        {
            if (_interactionControl.CurrentInteractableObject != null)
            {
                _interactionControl.InteractWithEnvironment(_interactionControl.CurrentInteractableObject);
                _interactionControl.CurrentInteractableObject = null;
            }
        }
    }
}