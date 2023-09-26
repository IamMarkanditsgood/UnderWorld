using System;
using UnityEngine;

namespace GamePlay.Character.Components
{
    [Serializable]
    public class MovementManager 
    {
        [SerializeField] private float _movementSpeed = 20;
        [SerializeField] private float _movementMaxSpeed = 5;
        public void MoveCharacter(Vector2 moveDirectionData, Rigidbody rigidbody)
        {
            Vector3 moveDirection = new Vector3(moveDirectionData.x, 0, moveDirectionData.y).normalized;
            Vector3 moveVelocity = moveDirection * _movementSpeed;

            rigidbody.AddForce(moveVelocity, ForceMode.Acceleration);
            rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, _movementMaxSpeed);
        }
    }
}
