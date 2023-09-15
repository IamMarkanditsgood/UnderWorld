using System;
using Character.Data;
using UnityEngine;

namespace Character.MVC
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private CharacterData _characterData;

        private readonly InputController _inputController = new();
        private readonly CharacterModel _characterModel = new();

        private void Awake()
        {
            _characterModel.SetInitialData(_characterData);
            
            _inputController.MoveButtonsPressed += MoveCharacter;
            _inputController.MoveMouse += MoveRotationTarget;
            _inputController.ShiftPressed += () => _characterModel.UseSkill(_characterData.MainSkillData.Skill);
            _inputController.LbmPressed += () => _characterModel.UseSkill(_characterData.ShootskillData.Skill);    
            _inputController.RbmPressed += () => _characterModel.UseSkill(_characterData.SupportkillData.Skill);
            _inputController.EPressed +=  EPressed;
        }

        private void Update()
        {
            _inputController.CheckKeyboardKeys();
            _inputController.CheckMouseKeys();
        }

        private void FixedUpdate()
        {
            _characterModel.RotateCharacter(_characterData.CharacterBody, _characterData.RotationTarget, _characterData.SpeedOfRotation);
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
            _inputController.MoveButtonsPressed -= MoveCharacter;
            _inputController.MoveMouse -= MoveRotationTarget;
            _inputController.ShiftPressed -= () => _characterModel.UseSkill(_characterData.MainSkillData.Skill);
            _inputController.LbmPressed -= () => _characterModel.UseSkill(_characterData.ShootskillData.Skill);
            _inputController.RbmPressed -= () => _characterModel.UseSkill(_characterData.SupportkillData.Skill);
            _inputController.EPressed -= EPressed;
        }

        private void MoveCharacter(Vector2 movementDirection)
        {
            _characterModel.MoveCharacter(movementDirection, _characterData.Rigidbody, _characterData.SpeedOfMoving,
                _characterData.MaxSpeedOfMoving);
        }

        private void MoveRotationTarget(Vector2 mousePos)
        {
            _characterModel.MoveRotationTarget(_characterData, mousePos);
        }

        private void EPressed()
        {
            if (_characterData.CurrentInteractableObject != null)
            {
                _characterModel.InteractWithEnvironment(_characterData.CurrentInteractableObject);
                _characterData.CurrentInteractableObject = null;
            }
        }

    }
}