using System;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.InputSystem.Controls.AxisControl;

public class MovementHandler : MonoBehaviour
{
    [SerializeField]
    private InputManager _inputManager;
    private CharacterController _characterController;
    [SerializeField]
    private Camera _mainCamera;

    private float _mouseSensitivity = 25f;
    private float _speed = 5f;
    private readonly float _gravity = -9.81f;
    private float _velocity;
    private float _pitch;
    private float _yaw;
    private float _xRot = 0f;

    void Start()
    {
        _inputManager = GetComponent<InputManager>();
        _characterController = GetComponent<CharacterController>();
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
        _yaw += _inputManager.MouseLook.x * Time.deltaTime * _mouseSensitivity;
        //_pitch += -_inputManager.MouseLook.y * Time.deltaTime * _mouseSensitivity;
        ////clamp to limit angle within 360 degrees
        _yaw = ClampAngle(_yaw, float.MinValue, float.MaxValue);
        //_pitch = ClampAngle(_pitch, -90, 90);
        transform.rotation = Quaternion.Euler(0.0f, _yaw, 0.0f);
        //transform.Rotate(Vector3.up, _inputManager.MouseLook.x * Time.deltaTime);
        _xRot -= _inputManager.MouseLook.y * Time.deltaTime * _mouseSensitivity;
        _xRot = Mathf.Clamp(_xRot, -90, 90);
        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = _xRot;
        _mainCamera.transform.eulerAngles = targetRotation;

    }
    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }

    private void Gravity()
    {
        if (_characterController.isGrounded && _velocity < 0)
        {
            _velocity = -2f;
        }

        _velocity += _gravity * Time.deltaTime;
    }
    private void MovePlayer()
    {
        Vector3 moveDir = (_inputManager.MoveDirection.y * transform.forward) + (_inputManager.MoveDirection.x * transform.right);
        _characterController.Move(moveDir * _speed * Time.deltaTime + new Vector3(0f, _velocity,0f) * Time.deltaTime);
    }
}
