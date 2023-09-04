using UnityEngine;

namespace Character.MVC
{
    public class CharacterModel
    {
        public void MoveCharacter(Vector2 moveDirectionData, Rigidbody rb, float moveSpeed, float maxSpeed)
        {
            Vector3 moveDirection = new Vector3(moveDirectionData.x, 0, moveDirectionData.y).normalized;
            Vector3 moveVelocity = moveDirection * moveSpeed;

            rb.AddForce(moveVelocity, ForceMode.Acceleration);
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }
}