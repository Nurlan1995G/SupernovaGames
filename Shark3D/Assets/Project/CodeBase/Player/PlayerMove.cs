using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector2 _moveDirection;

    private void Update()
    {
        Move(_moveDirection);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector2>();
    }

    private void Move(Vector2 direction)
    {
        float scaledMoveSpeed = _speed * Time.deltaTime;

        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
        transform.position += moveDirection * scaledMoveSpeed;
    }
}
