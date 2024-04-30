using Assets.Project.CodeBase.Input.TouchscreenInput;
using System;
using UnityEngine;

namespace Assets.CodeBase.CameraLogic
{
    public class CameraRotationHandler : MonoBehaviour
    {
        [SerializeField] private GameplayInputManager _gameplayInputManager;

        [SerializeField] private Transform _targetRotation;
        [SerializeField] private float _sensivity = 100f;

        private float _horizontal = 0;
        private float _vertical = 0;

        private void Start()
        {
            _gameplayInputManager.RotationInputReceived += OnRotationInputReceived;
        }

        private void OnRotationInputReceived(Vector2 delta)
        {
            //_vertical -= _sensivity * delta.y * Time.deltaTime;
            _horizontal += _sensivity * delta.x * Time.deltaTime;

            _targetRotation.eulerAngles = new Vector3(0, _horizontal, 0);
        }
    }
}
