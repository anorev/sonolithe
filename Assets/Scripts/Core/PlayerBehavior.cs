using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField]
    Camera _camera;

    [SerializeField]
    CharacterController _characterController;

    [SerializeField]
    GameObject _groundCheck;

    [SerializeField]
    LayerMask _groundMask;

    PlayerInput playerInput;

    [SerializeField]
    float _moveSpeed = 10.0f;

    float _groundDistance = 0.4f;
    float _gravity = -9.81f;
    bool _isGrounded;
    float _jumpHeight = 3.0f;
    public bool activeControls;

    Vector3 _velocity;

    float _xRotation;
    
    [SerializeField]
    float _mouseSensibility = 100.0f;
    /*float _yRotation; */
    
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerBehaviorCheckGround();
        PlayerBehaviorLook();
        PlayerBehaviorMove();
        PlayerBehaviorHandleJump();

    }

    void PlayerBehaviorLook()
    {
        float mouseX = playerInput.CharacterControls.Look.ReadValue<Vector2>().x * _mouseSensibility * Time.deltaTime;
        float mouseY = playerInput.CharacterControls.Look.ReadValue<Vector2>().y * _mouseSensibility * Time.deltaTime;
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -70.0f, 70.0f);
        _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0.0f, 0.0f);
        gameObject.transform.Rotate(Vector3.up * mouseX);
    }

    void PlayerBehaviorMove()
    {
        float x = playerInput.CharacterControls.Move.ReadValue<Vector2>().x;
        float z = playerInput.CharacterControls.Move.ReadValue<Vector2>().y;

        Vector3 move = gameObject.transform.right * x + gameObject.transform.forward * z;
        _characterController.Move(move * _moveSpeed * Time.deltaTime);
    }

    void PlayerBehaviorCheckGround()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.transform.position, _groundDistance, _groundMask);
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -6.0f;
        }

        _velocity.y += _gravity * Time.deltaTime;

        _characterController.Move(_velocity * Time.deltaTime);
    }

    void PlayerBehaviorHandleJump()
    {
        if (playerInput.CharacterControls.Jump.triggered && _isGrounded)
        {
            Debug.Log("aaa");
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2 * _gravity);
        }
    }

    void OnEnable()
    {
        playerInput.CharacterControls.Enable();
    }

    void OnDisable()
    {
        playerInput.CharacterControls.Disable();

    }
}
