using Character.Data;
using UnityEngine;

namespace Character.MVC
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private CharacterData _characterData;

        private InputController _inputController = new();
        private CharacterModel _characterModel = new CharacterModel();

        private void FixedUpdate()
        {
            _inputController.GetKeyboardMovement(_characterData.MovementKeyboardData);
            _inputController.GetMouseMovement(_characterData.MovementMouseData);
            
            _characterModel.MoveCharacter(_characterData.MovementKeyboardData, _characterData.Rigidbody, _characterData.SpeedOfMoving, _characterData.MaxSpeedOfMoving);
        }
    }
}
