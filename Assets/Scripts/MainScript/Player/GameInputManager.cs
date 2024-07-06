using LXF_Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInputManager : LXF_Singleton<GameInputManager>
{
    PlayerInput _playerInput;
    InputAction _moveAction;
    InputAction _jumpAction;

    private Rigidbody2D _rb; 
    private BoxCollider2D _box; 
    [SerializeField]
    private float moveSpeed = 5f; 
    [SerializeField]
    private float jumpForce = 5f; 
    [SerializeField]
    private bool canJump = true;

    private void Start() {
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions["MoveMent"];
        _jumpAction = _playerInput.actions["Jump"];

        _rb=GetComponent<Rigidbody2D>();
        _box=GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate() {
        MovePlayer();

        if(canJump)
            JumpPlayer();
    }

    void MovePlayer(){
        //AudioManager.Instance.Play("move");

        Vector2 moveInput = _moveAction.ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        _rb.velocity = 
            new Vector3(moveDirection.x * moveSpeed, _rb.velocity.y, moveDirection.z * moveSpeed);
    }

    void JumpPlayer(){
        if (_jumpAction.triggered)
        {
            //AudioManager.Instance.Play("jump");

            _rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Platform"){
            canJump = true;
        }
    }
}

