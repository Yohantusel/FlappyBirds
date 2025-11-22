using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float jumpForce = 7f;
    private Rigidbody2D _rb;
    private PlayerInputActions _controls;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _controls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        _controls.Player.Enable();
        _controls.Player.Jump.performed += OnJump;
    }

    private void OnDisable()
    {
        _controls.Player.Jump.performed -= OnJump;
        _controls.Player.Disable();
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;

        if (!GameManager.Instance.Started)
        {
            GameManager.Instance.StartGame();
            _rb.simulated = true; 
        }
        if (GameManager.Instance.GameOver)
        {
            GameManager.Instance.Restart();
        }
        

        _rb.linearVelocity = Vector2.up * jumpForce;
    }
    private void OnTriggerEnter2D(Collider2D check)
    {
        if (!check.CompareTag("Enemy")) return;
        GameManager.Instance.SetGameOver();
        
    }
    
}

