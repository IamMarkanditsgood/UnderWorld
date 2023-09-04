using System;
using UnityEngine;

namespace Character
{
    public class InputController
    {
        public Action<Vector2> MoveButtonsPressed;
        public Action<Vector2> MoveMouse;

        private Vector2 GetKeyboardMovement()
        {
            Vector2 keyboardData;
            keyboardData.x = Input.GetAxis("Horizontal");
            keyboardData.y = Input.GetAxis("Vertical");
            return keyboardData;
        }

        private Vector2 GetMouseMovement()
        {
            Vector2 moueData;
            moueData.y = Input.GetAxis("Mouse Y");
            ;
            moueData.x = Input.GetAxis("Mouse X");
            return moueData;
        }

        public void CheckKeyboardKeys()
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                MoveButtonsPressed?.Invoke(GetKeyboardMovement());
            }
        }

        public void CheckMouseKeys()
        {
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                MoveMouse?.Invoke(GetMouseMovement());
            }
        }
    }
}