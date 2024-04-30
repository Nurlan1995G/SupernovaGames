using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.CodeBase.CameraLogic
{
    public class CameraRotater : MonoBehaviour
    {
        [SerializeField] private float _speedRotate;

        private RotateInput _rotateInput;
        private Vector2 _lastDirection;
        
        private float _currentXRotation;
        private float _currentYRotation;
        
        private void Awake()
        {
            _rotateInput = new RotateInput();
            _rotateInput.Enable();

            _rotateInput.Touchscreen.TouchDelta.performed += OnTouchPerformed;
        }

        private void OnTouchPerformed(InputAction.CallbackContext context) =>
            Rotate(context.ReadValue<Vector2>());

        private void Rotate(Vector2 direction)
        {
            if(_lastDirection != direction)
            {
                _currentXRotation += direction.x * _speedRotate * Time.deltaTime;
                _currentYRotation += -direction.y * _speedRotate * Time.deltaTime;

                _currentYRotation = Mathf.Clamp(_currentYRotation, -45f, 90f);

                Quaternion rotationX = Quaternion.Euler(0, _currentXRotation, 0);
                Quaternion rotationY = Quaternion.Euler(_currentYRotation, 0, 0);

                transform.rotation = rotationX * rotationY;
                _lastDirection = direction;
            }
        }
    }
}
