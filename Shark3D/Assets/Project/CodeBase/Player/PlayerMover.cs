using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private float _speedRotate;
    [SerializeField] private CharacterController _characterController;
    
    
    private Vector3 _velocityDirection;
    private float _gravityForce;
    private Vector2 _moveDirection;

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
        Rotate(newDirection);
    }

    private void MoveCharacter(Vector3 direction)
    {
        _velocityDirection.x = direction.x * _speedMove;
        _velocityDirection.z = direction.z * _speedMove;

        _characterController.Move(_velocityDirection * Time.deltaTime);
    }

    private void Rotate(Vector3 direction)
    {
        if (_characterController.isGrounded)
        {
            if (Vector3.Angle(transform.forward, direction) > 0)
            {
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, _speedRotate, 0);
                transform.rotation = Quaternion.LookRotation(newDirection);
            }
        }
    }

    private void GravityHandling()
    {
        if (!_characterController.isGrounded)
        {
            _velocityDirection.y -= _gravityForce * Time.deltaTime;
        }
        else
        {
            _velocityDirection.y = -5f;
        }
    }
}
