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

    private void Start() =>
        _characterController = GetComponent<CharacterController>();

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
        MoveCharacter(newDirection);
        RotateCharacter(newDirection);
    }

    public void MoveCharacter(Vector3 moveDirection)
    {
        moveDirection = moveDirection * _moveSpeed;
        moveDirection.y = _currentAttractionCharacter;
        _characterController.Move(moveDirection * Time.deltaTime);
    }

    public void RotateCharacter(Vector3 moveDirection)
    {
        if (_characterController.isGrounded)
        {
            if (Vector3.Angle(transform.forward, moveDirection) > 0)
            {
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, moveDirection, _rotateSpeed, 0);
                transform.rotation = Quaternion.LookRotation(newDirection);
            }
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
