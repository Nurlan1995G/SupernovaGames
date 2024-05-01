using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerControllerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    [SerializeField] private float _grafiryForce = 20;
    private float _currentAttractionCharacter;   //текущее придвижение персонажа

    private CharacterController _characterController;
    private Vector2 _moveDirection;

    private Transform _cameraTransform;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        GravityHandling();
        Move(_moveDirection);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector2>();
    }

    private void Move(Vector2 direction)
    {
        Vector3 newDirection = new Vector3(direction.x, 0, direction.y);

        Quaternion cameraRotationY = Quaternion.Euler(0, _cameraTransform.eulerAngles.y, 0);

        MoveCharacter(newDirection, cameraRotationY);

        RotateCharacter(newDirection, cameraRotationY);
    }

    public void MoveCharacter(Vector3 moveDirection, Quaternion cameraRotation)
    {
        Vector3 finalDirection = (cameraRotation  * moveDirection).normalized;

        _characterController.Move(_moveSpeed * Time.deltaTime * finalDirection);
    }

    public void RotateCharacter(Vector3 moveDirection, Quaternion cameraRotation)
    {
        if (Vector3.Angle(transform.forward, moveDirection) > 0)
        {
             Vector3 finalDirection = (cameraRotation * moveDirection).normalized;
             transform.rotation = Quaternion.LookRotation(_rotateSpeed * Time.deltaTime * finalDirection);
        }
    }

    private void GravityHandling()
    {
        if (_characterController.isGrounded == false)
            _currentAttractionCharacter -= _grafiryForce * Time.deltaTime;
        else
            _currentAttractionCharacter = 0;
    }
}
