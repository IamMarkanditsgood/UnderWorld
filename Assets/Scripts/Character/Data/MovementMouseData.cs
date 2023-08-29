using UnityEngine;

namespace Character.Data
{
    public class MovementMouseData
    {
        private float _horizontalInput;
        private float _verticalInput;
        
        public float HorizontalInput { set => _horizontalInput = value; }
        public float VerticalInput { set => _verticalInput = value; }
    }
}
