using GamePlay.Character.Components;
using GamePlay.Character.Skills;
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
        
        private readonly InputController _inputController = new();

        private void Awake()
        {
            _skillsManager.SkillDictionaries.SkillsDamage = _initialSkillsConfig.SkillsDamage;
            _skillsManager.SkillDictionaries.SkillsReloadTimer = _initialSkillsConfig.SkillsReloadTimer;
            
            _rotationManager.InitialData(_characterBody.transform);
            
            _skillsManager.SetInitialSkillsData(SkillTypes.Teleport, SkillTypes.Arrow, SkillTypes.Swords, new Teleport(), new Arrow(), new Swords());
            
            _inputController.OnMoveButtonsPressed += MoveCharacter;
            _inputController.OnShiftPressed += () => _skillsManager.UseSkill(_skillsManager.MainSkillData.Skill);
            _inputController.OnLeftButtonMousePressed += () => _skillsManager.UseSkill(_skillsManager.ShootskillData.Skill);    
            _inputController.OnRightButtonMousePressed += () => _skillsManager.UseSkill(_skillsManager.SupportkillData.Skill);
            _inputController.OnEPressed += Epressed;
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
            if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
            {   
                
                _interactionControl.CurrentInteractableObject = other.gameObject;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
            {   
                
                _interactionControl.CurrentInteractableObject = null;
            }
        }
        private void OnDestroy()
        {
            _inputController.OnMoveButtonsPressed -= MoveCharacter;
            _inputController.OnShiftPressed -= () => _skillsManager.UseSkill(_skillsManager.MainSkillData.Skill);
            _inputController.OnLeftButtonMousePressed -= () => _skillsManager.UseSkill(_skillsManager.ShootskillData.Skill);
            _inputController.OnRightButtonMousePressed -= () => _skillsManager.UseSkill(_skillsManager.SupportkillData.Skill);
            _inputController.OnEPressed -= Epressed;
        }

        private void MoveCharacter(Vector2 movementDirection)
        {
            _movementManager.MoveCharacter(movementDirection, _rigidbody);
        }
        
        private void Epressed()
        {
            if (_interactionControl.CurrentInteractableObject != null)
            {
                
                _interactionControl.InteractWithEnvironment(_interactionControl.CurrentInteractableObject);
                _interactionControl.CurrentInteractableObject = null;
            }
        }
    }
}