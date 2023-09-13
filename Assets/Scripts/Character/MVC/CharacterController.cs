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
            _inputController.ShiftPressed += ShiftPresed;
            _inputController.LBMPressed += LbmPresed;
            _inputController.RBMPressed += RbmPresed;
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

        private void OnDestroy()
        {
            _inputController.MoveButtonsPressed -= MoveCharacter;
            _inputController.MoveMouse -= MoveRotationTarget;
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

        private void ShiftPresed()
        {
            _characterModel.UseSkill(_characterData.MainSkillData.Skill);    
        }
        private void LbmPresed()
        {
            _characterModel.UseSkill(_characterData.ShootskillData.Skill);    
        }
        private void RbmPresed()
        {
            _characterModel.UseSkill(_characterData.SupportkillData.Skill);    
        }
    }
}