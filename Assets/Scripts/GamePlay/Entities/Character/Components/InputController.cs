using System;
using UnityEngine;

namespace GamePlay.Character.Components
{
    public class InputController
    {
        public event Action<Vector2> OnMoveButtonsPressed;
        public event Action OnShiftPressed;
        public event Action OnLeftButtonMousePressed;
        public event Action OnRightButtonMousePressed;
        public event Action OnEPressed;

        private Vector2 GetKeyboardMovement()
        {
            Vector2 keyboardData;
            keyboardData.x = Input.GetAxis("Horizontal");
            keyboardData.y = Input.GetAxis("Vertical");
            return keyboardData;
        }
        public void CheckKeyboardKeys()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                OnShiftPressed?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                OnEPressed?.Invoke();
            }
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                OnMoveButtonsPressed?.Invoke(GetKeyboardMovement());
            }
        }

        public void CheckMouseKeys()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                OnLeftButtonMousePressed?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                OnRightButtonMousePressed?.Invoke();   
            }
        }
    }
}