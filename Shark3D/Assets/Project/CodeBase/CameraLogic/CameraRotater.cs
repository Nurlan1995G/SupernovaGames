using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.CodeBase.CameraLogic
{
    public class CameraRotater : MonoBehaviour
    {
        [SerializeField] private float _speedRotate;

        private Vector2 _rotateDirection;
        private Vector2 _lastDirection;
        
        private float _currentXRotation;
        private float _currentYRotation;

        public void OnRotate(InputAction.CallbackContext context)
        {
            _rotateDirection = context.ReadValue<Vector2>();

            Debug.Log(_rotateDirection + " - rotateDirection");

            Rotate(_rotateDirection);
        }

        private void Rotate(Vector2 direction)
        {
            if(_lastDirection != direction)
            {
                _currentXRotation += direction.x * _speedRotate * Time.deltaTime;
                _currentYRotation += -direction.y * _speedRotate * Time.deltaTime;

                _currentYRotation = Mathf.Clamp(_currentYRotation, 45f, 90f);

                Quaternion rotationX = Quaternion.Euler(0, _currentYRotation, 0);
                Quaternion rotationY = Quaternion.Euler(_currentXRotation, 0, 0);

                transform.rotation = rotationX * rotationY;
                _lastDirection = direction;
            }

        }
    }
}
