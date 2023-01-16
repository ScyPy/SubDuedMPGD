using UnityEngine;
using Cinemachine;
public class MovementHandler : MonoBehaviour
{
    [SerializeField]
    private InputManager _inputManager;
    private CharacterController _characterController;
    [SerializeField]
    private Camera _mainCamera;

    private float _mouseSensitivity = 25f;
    private float _speed = 5f;
    private const float _gravity = -18f; //stronger custom gravity
    private float _velocity;
    private float _pitch;
    private float _yaw;
    private float _xRot = 0f;
    private const float _rotationSpeed = 60f;
    private const float _jumpHeight = 0.8f;


    void Start()
    {
        _inputManager = GetComponent<InputManager>();
        _characterController = GetComponent<CharacterController>();
        _mainCamera = Camera.main;
        _inputManager.HasJumped += Jump;
    }

    // Update is called once per frame
    void Update()
    {
        Gravity();
        Look();
        MovePlayer();
    }

    private void Look()
    {
        //_yaw += _inputManager.MouseLook.x * Time.deltaTime * _mouseSensitivity;
        ////_pitch += -_inputManager.MouseLook.y * Time.deltaTime * _mouseSensitivity;
        //////clamp to limit angle within 360 degrees
        //_yaw = ClampAngle(_yaw, float.MinValue, float.MaxValue);
        ////_pitch = ClampAngle(_pitch, -90, 90);
        //transform.rotation = Quaternion.SlerpUnclamped(transform.rotation, Quaternion.Euler(0.0f, _yaw, 0.0f), _rotationSpeed * Time.deltaTime);
        ////transform.Rotate(Vector3.up, _inputManager.MouseLook.x * Time.deltaTime);
        //_xRot -= _inputManager.MouseLook.y * Time.deltaTime * _mouseSensitivity;
        //_xRot = Mathf.Clamp(_xRot, -90, 90);
        //Vector3 targetRotation = transform.eulerAngles;
        //targetRotation.x = _xRot;
        //_mainCamera.transform.eulerAngles = targetRotation;
        transform.rotation = Quaternion.Euler(0f, _mainCamera.transform.eulerAngles.y, 0f);

    }
    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }

    private void Gravity()
    {
        //stop velocity from infinitely dropping
        if (_characterController.isGrounded && _velocity < 0)
        {
            _velocity = -2f;
        }

        _velocity += _gravity * Time.deltaTime;

        //if (_inputManager.Jump && _characterController.isGrounded)
        //{
        //    _velocity = Mathf.Sqrt(-2f * _jumpHeight * _gravity);
        //}
        //_inputManager.Jump = false;
    }
    private void MovePlayer()
    {
        //move in transform forward direction
        Vector3 moveDir = (_inputManager.MoveDirection.y * transform.forward) + (_inputManager.MoveDirection.x * transform.right);
        _characterController.Move(moveDir * _speed * Time.deltaTime + new Vector3(0f, _velocity,0f) * Time.deltaTime);
    }

    private void Jump()
    {
        if (!_characterController.isGrounded) return;

        _velocity = Mathf.Sqrt(-2f * _jumpHeight * _gravity);

    }
}
