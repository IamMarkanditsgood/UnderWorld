using UnityEngine;

namespace MainCamera
{
    public class CameraData : MonoBehaviour
    {
        [SerializeField] private Transform _player;

        public Transform Player
        {
            get => _player;
            set => _player = value;
        }
    }
}
