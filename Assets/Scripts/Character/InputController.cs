using System;
using UnityEngine;

namespace Character
{
    public class InputController
    {
        public Action<Vector2> MoveButtonsPressed;
        public Action<Vector2> MoveMouse;
        public Action ShiftPressed;
        public Action LBMPressed;
        public Action RBMPressed;

        private Vector2 GetKeyboardMovement()
        {
            Vector2 keyboardData;
            keyboardData.x = Input.GetAxis("Horizontal");
            keyboardData.y = Input.GetAxis("Vertical");
            return keyboardData;
        }

        private Vector2 GetMouseScreenPos()
        {
            Vector2 moueData;
            moueData.y = Input.mousePosition.y;
            moueData.x = Input.mousePosition.x;
            return moueData;
        }

        public void CheckKeyboardKeys()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                ShiftPressed?.Invoke();
            }

            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                MoveButtonsPressed?.Invoke(GetKeyboardMovement());
            }
        }

        public void CheckMouseKeys()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                LBMPressed?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                RBMPressed?.Invoke();   
            }
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                MoveMouse?.Invoke(GetMouseScreenPos());
            }
        }
    }
}