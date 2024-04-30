using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Project.CodeBase.Input.TouchscreenInput
{
    public class TouchscreenGameplayInput
    {
        private readonly RotateInput _rotationInput;

        public event Action<Vector2> RotationInputReceived;

        public TouchscreenGameplayInput(RotateInput rotationInput)
        {
            _rotationInput = rotationInput;

            _rotationInput.Touchscreen.TouchDelta.performed += OnRotationInputPerformend;
        }

        private void OnRotationInputPerformend(InputAction.CallbackContext context) => 
            RotationInputReceived?.Invoke(context.ReadValue<Vector2>());
    }
}
