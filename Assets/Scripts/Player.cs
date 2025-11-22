using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float jumpForce = 7f;
    private Rigidbody2D _rb;
    private PlayerInputActions _controls;
    public Sprite idleSprite;
    public Sprite jumpSprite;
    SpriteRenderer _sr;
    private void Update()
    {
        if (_rb.linearVelocity.y < 0)
            _sr.sprite = idleSprite;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _controls = new PlayerInputActions();
        _sr = GetComponent<SpriteRenderer>();
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
        _sr.sprite = jumpSprite;
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

