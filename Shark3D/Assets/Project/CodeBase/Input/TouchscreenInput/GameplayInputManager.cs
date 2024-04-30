using System;
using UnityEngine;

namespace Assets.Project.CodeBase.Input.TouchscreenInput
{
    public class GameplayInputManager : MonoBehaviour
    {
        private RotateInput _rotationInput;
        private TouchscreenGameplayInput _touchscreenGameplay;

        public event Action<Vector2> RotationInputReceived;

        private void Awake()
        {
            _rotationInput = new RotateInput();

            _rotationInput.Enable();

            InitTouchInput(_rotationInput);
        }

        private void InitTouchInput(RotateInput rotationInput)
        {
            _touchscreenGameplay = new TouchscreenGameplayInput(rotationInput);

            _touchscreenGameplay.RotationInputReceived += OnRotationInputReceived;
        }

        private void OnRotationInputReceived(Vector2 delta) => 
            RotationInputReceived?.Invoke(delta);
    }
}
