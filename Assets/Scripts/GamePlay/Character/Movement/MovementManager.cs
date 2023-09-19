using UnityEngine;

namespace GamePlay.Character.Movement
{
    public class MovementManager 
    {
        public void MoveCharacter(Vector2 moveDirectionData, Rigidbody rigidbody, float moveSpeed, float maxSpeed)
        {
            Vector3 moveDirection = new Vector3(moveDirectionData.x, 0, moveDirectionData.y).normalized;
            Vector3 moveVelocity = moveDirection * moveSpeed;

            rigidbody.AddForce(moveVelocity, ForceMode.Acceleration);
            rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxSpeed);
        }
    }
}
