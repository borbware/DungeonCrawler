using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] int speed = 4;
    Vector2 _playerInput;
    Rigidbody2D _rigidBody;
    Animator _animator;
    SpriteRenderer _spriteRenderer;

    public string state = "idle";

    bool _flipped;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void CheckInput()
    {
		_playerInput = Vector2.ClampMagnitude(
			new Vector2(
				Input.GetAxisRaw("Horizontal"),
				Input.GetAxisRaw("Vertical")
			),
		1f);
    }
    void FlipAnimation()
    {
        if (_playerInput.x < -0.002)
            _flipped = true;
        else if (_playerInput.x > 0.002)
            _flipped = false;
        _spriteRenderer.flipX = _flipped;        
    }

    void Update()
    {
        if (state == "idle")
        {
            CheckInput();
            if (_playerInput.magnitude > 0.002) {
                // _animator.Play("playerWalking");
                _animator.SetTrigger("StartWalking");
                state = "walking";
            }
        } else if (state == "walking")
        {
            CheckInput();
            FlipAnimation();
            if (_playerInput.magnitude < 0.002)
            {
                _animator.SetTrigger("StopWalking");
                // _animator.Play("playerIdle");
                state = "idle";
            }
        } else if (state == "hurt")
        {
            
        }
        //_animator.SetFloat("Speed", _playerInput.magnitude);
    }
    void FixedUpdate() {
        _rigidBody.MovePosition(
            _rigidBody.position + new Vector2(
                _playerInput.x,
                _playerInput.y
            ) * Time.deltaTime * speed
        );
    }
}
