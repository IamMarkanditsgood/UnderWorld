using System;
using UnityEngine;

namespace Character
{
    public class InputController
    {
        public Action<Vector2> MoveButtonsPressed;
        public Action<Vector2> MoveMouse;
        public Action ShiftPressed;
        public Action LbmPressed;
        public Action RbmPressed;
        public Action EPressed;

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

            if (Input.GetKeyDown(KeyCode.E))
            {
                EPressed?.Invoke();
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
                LbmPressed?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                RbmPressed?.Invoke();   
            }
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                MoveMouse?.Invoke(GetMouseScreenPos());
            }
        }
    }
}