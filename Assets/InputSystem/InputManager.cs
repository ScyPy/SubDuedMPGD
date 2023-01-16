using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public Vector2 MouseLook { get; private set; }
    public Vector2 MoveDirection { get; private set; }
    public bool Jump { get; set; }
    public bool Attack { get; private set; }

    public Action HasAttacked;

    public Action HasJumped;

    [SerializeField]
    private PlayerActions _playerActions;

    void Awake()
    {
        //Initalize input action generated c# class
        _playerActions = new PlayerActions();
        //Set player control actions
        #region Setting Controls
        _playerActions.PlayerControls.Movement.performed += ctx => OnMovement(ctx);
        _playerActions.PlayerControls.Look.performed += ctx => OnLook(ctx);
        _playerActions.PlayerControls.Attack.performed += ctx => OnAttack(ctx);
        _playerActions.PlayerControls.Jump.performed += ctx => OnJump(ctx);
        #endregion

    }



    void Start()
    {

    }
    void OnEnable()
    {
        _playerActions.Enable();
    }
    void OnDisable()
    {
        _playerActions.Disable();

    }
    void Update()
    {
        
    }
    private void OnMovement(InputAction.CallbackContext moveInput)
    {
        MoveDirection = moveInput.ReadValue<Vector2>();
    }
    private void OnLook(InputAction.CallbackContext mouseInput)
    {
        MouseLook = mouseInput.ReadValue<Vector2>(); 
    }
    private void OnJump(InputAction.CallbackContext jumpValue)
    {
        Jump = jumpValue.ReadValueAsButton();
        if (Jump)
            HasJumped?.Invoke();
        Jump = false;
    }
    private void OnAttack(InputAction.CallbackContext ctx)
    {
        Attack = ctx.ReadValueAsButton();
        if (Attack)
            HasAttacked?.Invoke();

    }
}
