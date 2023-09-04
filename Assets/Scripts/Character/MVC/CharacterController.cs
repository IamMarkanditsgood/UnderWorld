using Character.Data;
using UnityEngine;

namespace Character.MVC
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private CharacterData _characterData;

        private readonly InputController _inputController = new();
        private readonly CharacterModel _characterModel = new();
        
        private void FixedUpdate()
        {
            _inputController.CheckKeyboardKeys();
        }

        private void OnEnable()
        {
            _inputController.MoveButtonsPressed += MoveCharacter;
            _inputController.MoveMouse += RotateCharacter;
        }

        private void OnDisable()
        {
            _inputController.MoveButtonsPressed -= MoveCharacter;
            _inputController.MoveMouse -= RotateCharacter;
        }

        private void MoveCharacter(Vector2 movementDirection)
        {
            _characterModel.MoveCharacter(movementDirection, _characterData.Rigidbody, _characterData.SpeedOfMoving,
                _characterData.MaxSpeedOfMoving);
        }

        private void RotateCharacter(Vector2 movementDirection)
        {
        }
    }
}