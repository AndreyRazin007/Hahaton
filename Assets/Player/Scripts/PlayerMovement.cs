using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 _vectorMovement;

    [SerializeField] private float jumpPower;
    [SerializeField] private float speed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new(_vectorMovement.x * speed, _rigidbody.velocity.y);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _rigidbody.velocity = new(_rigidbody.velocity.x, jumpPower);
        }
    }

    public void Movement(InputAction.CallbackContext context)
    {
        _vectorMovement = context.ReadValue<Vector2>();
        Flip();
    }

    private void Flip()
    {
        if (_vectorMovement.x < -0.01f)
        {
            transform.localScale = new(-1, 1, 1);
        }

        if (_vectorMovement.x > 0.01f)
        {
            transform.localScale = new(1, 1, 1);
        }
    }
}
