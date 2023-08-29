namespace Character.Data
{
    public class MovementKeyboardData
    {
        private float _horizontalInput;
        private float _verticalInput;

        public float HorizontalInput
        {
            get => _horizontalInput;
            set => _horizontalInput = value;
        }

        public float VerticalInput
        {
            get => _verticalInput;
            set => _verticalInput = value;
        }
    }
}