using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] InputActionAsset playerControls;
    InputAction playerJump;
    InputAction playerMove;

    CharacterController character;
    Vector3 moveVector;
    [SerializeField] float speed = 10f;
    [SerializeField] float _gravity = 9.81f;
    [SerializeField] float _jumpSpeed = 3.5f;
    [SerializeField] float _doubleJumpMulitpler = 0.5f;
    private float _directionY;
    private bool _canDoubleJump = false;

    // Start is called before the first frame update
    void Start()
    {
        //method2: register action by script
        var gameplayActionMap = playerControls.FindActionMap("Default");
        playerJump = gameplayActionMap.FindAction("Jump");
        playerJump.performed += OnPlayerJump;
        playerJump.canceled += OnPlayerJump;
        playerJump.Enable();

        playerMove = gameplayActionMap.FindAction("Move");
        playerMove.performed += OnMovementChanged;
        playerMove.canceled += OnMovementChanged;
        playerMove.Enable();

        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        character.Move(moveVector * speed * Time.fixedDeltaTime);

        _directionY -= _gravity * Time.deltaTime;
        moveVector.y = _directionY;
    }

    //method1: register action by PlayerInput|Events|Runtime
    public void OnMovementChanged(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        moveVector = new Vector3(direction.x, 0, direction.y);
    }

    //method2: register action by script
    public void OnPlayerJump(InputAction.CallbackContext context)
    {
        Debug.Log("player jumped");

        if (character.isGrounded)
        {
            _canDoubleJump = true;
            _directionY = _jumpSpeed;
        }
        else if (_canDoubleJump)
        {
            _canDoubleJump = false;
            _directionY = _jumpSpeed * _doubleJumpMulitpler;
            Debug.Log("player doubled jumped");
        }
    }
}
