using Character.Data;
using UnityEngine;

namespace Character.MVC
{
    public class CharacterModel
    {
        public void MoveCharacter(MovementKeyboardData moveDirectionData, Rigidbody rb, float moveSpeed, float maxSpeed)
        {
            Vector3 moveDirection = new Vector3(moveDirectionData.HorizontalInput, 0.0f, moveDirectionData.VerticalInput).normalized;
            Vector3 moveVelocity = moveDirection * moveSpeed;
            
            rb.AddForce(moveVelocity, ForceMode.Acceleration);
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }
}
