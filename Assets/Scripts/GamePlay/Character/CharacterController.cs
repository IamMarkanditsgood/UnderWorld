using Character.Data;
using GamePlay.Character.Interaction;
using GamePlay.Character.Movement;
using GamePlay.Character.Rotation;
using GamePlay.Character.Skills;
using UnityEngine;

namespace Character
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private CharacterData _characterData;

        private readonly InputController _inputController = new();
        private readonly RotationManager _rotationManager = new();
        private readonly MovementManager _movementManager = new();
        private readonly SkillsManager _skillsManager = new();

        private void Awake()
        {
            _skillsManager.SetInitialSkillsData(_characterData);
            
            _inputController.OnMoveButtonsPressed += MoveCharacter;
            _inputController.MoveMouse += MoveRotationTarget;
            _inputController.OnShiftPressed += () => _skillsManager.UseSkill(_characterData.MainSkillData.Skill);
            _inputController.OnLeftButtonMousePressed += () => _skillsManager.UseSkill(_characterData.ShootskillData.Skill);    
            _inputController.OnRightButtonMousePressed += () => _skillsManager.UseSkill(_characterData.SupportkillData.Skill);
            _inputController.OnEPressed += Epressed;
        }

        private void Update()
        {
            _inputController.CheckKeyboardKeys();
            _inputController.CheckMouseKeys();
        }

        private void FixedUpdate()
        {
            
            _rotationManager.RotateCharacter(_characterData.CharacterBody, _characterData.RotationTarget, _characterData.SpeedOfRotation);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
            {   
                
                _characterData.CurrentInteractableObject = other.gameObject;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
            {   
                
                _characterData.CurrentInteractableObject = null;
            }
        }
        private void OnDestroy()
        {
            _inputController.OnMoveButtonsPressed -= MoveCharacter;
            _inputController.MoveMouse -= MoveRotationTarget;
            _inputController.OnShiftPressed -= () => _skillsManager.UseSkill(_characterData.MainSkillData.Skill);
            _inputController.OnLeftButtonMousePressed -= () => _skillsManager.UseSkill(_characterData.ShootskillData.Skill);
            _inputController.OnRightButtonMousePressed -= () => _skillsManager.UseSkill(_characterData.SupportkillData.Skill);
            _inputController.OnEPressed -= Epressed;
        }

        private void MoveCharacter(Vector2 movementDirection)
        {
            _movementManager.MoveCharacter(movementDirection, _characterData.Rigidbody, _characterData.SpeedOfMoving,
                _characterData.MaxSpeedOfMoving);
        }

        private void MoveRotationTarget(Vector2 mousePos)
        {
            _rotationManager.MoveRotationTarget(_characterData, mousePos);
        }

        private void Epressed()
        {
            if (_characterData.CurrentInteractableObject != null)
            {
                InteractionManager interactionManager = new();
                interactionManager.InteractWithEnvironment(_characterData.CurrentInteractableObject);
                _characterData.CurrentInteractableObject = null;
            }
        }
    }
}