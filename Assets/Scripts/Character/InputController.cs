using Character.Data;
using UnityEngine;

namespace Character
{
    public class InputController
    {
        public MovementKeyboardData GetKeyboardMovement(MovementKeyboardData movementKeyboardData)
        {
            movementKeyboardData.HorizontalInput = Input.GetAxis("Horizontal");
            movementKeyboardData.VerticalInput = Input.GetAxis("Vertical");
            return movementKeyboardData;
        }
        public MovementMouseData GetMouseMovement(MovementMouseData movementMouseData)
        {
            movementMouseData.HorizontalInput = Input.GetAxis("Mouse Y"); ;
            movementMouseData.VerticalInput = Input.GetAxis("Mouse X"); 
            return movementMouseData;
        }
        
    }
}