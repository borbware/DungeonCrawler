using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] int speed = 4;
    Vector2 _playerInput;
    Rigidbody2D _rigidBody;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
		_playerInput = Vector2.ClampMagnitude(
			new Vector2(
				Input.GetAxisRaw("Horizontal"),
				Input.GetAxisRaw("Vertical")
			),
		1f);
    }
    void FixedUpdate() {
        _rigidBody.MovePosition(
            transform.position + new Vector3(
                _playerInput.x,
                _playerInput.y,
                0f
            ) * Time.deltaTime * speed
        );
    }
}
