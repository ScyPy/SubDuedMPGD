using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public Vector2 MouseLook { get; private set; }
    public Vector2 MoveDirection { get; private set; }
    public bool Jump { get; private set; }
    public bool Attack { get; private set; }
    public bool Interacting { get;private set; }

    public Action<bool> HasAttacked;

    public Action HasJumped;

    public Action<bool> HasInteracted;

    public bool HotKey1 { get; private set; }
    public bool HotKey2 { get; private set; }
    public bool HotKey3 { get; private set; }

    public Action<int> HotKeyPressed;

    public Action CheatKeyPressed;

    public Action CheatInputRegistered;



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
        _playerActions.PlayerControls.Attack.canceled += ctx => OnAttack(ctx);
        _playerActions.PlayerControls.Jump.performed += ctx => OnJump(ctx);
        _playerActions.PlayerControls.Jump.canceled += ctx => OnJump(ctx);
        _playerActions.PlayerControls.Interact.performed += ctx => OnInteract(ctx);
        _playerActions.PlayerControls.Interact.canceled += ctx => OnInteract(ctx);
        _playerActions.PlayerControls.Hotkey1.performed += ctx => OnHotKey1(ctx);
        _playerActions.PlayerControls.Hotkey2.performed += ctx => OnHotKey2(ctx);
        _playerActions.PlayerControls.Hotkey3.performed += ctx => OnHotKey3(ctx);
        _playerActions.CheatMenu.CheatKey.performed += ctx => OnCheatConsoleEnabled(ctx);
        _playerActions.CheatMenu.RegisterCheat.performed += ctx => OnSendCheat(ctx);
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
        Jump = false; //jump reset
    }
    private void OnAttack(InputAction.CallbackContext ctx)
    {
        Attack = ctx.ReadValueAsButton();
        HasAttacked?.Invoke(Attack);

    }

    private void OnCheatConsoleEnabled(InputAction.CallbackContext ctx)
    {
        CheatKeyPressed?.Invoke();
    }

    void OnSendCheat(InputAction.CallbackContext ctx)
    {
        CheatInputRegistered?.Invoke();
    }

    private void OnInteract(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            HasInteracted?.Invoke(true);
        }
        else
            HasInteracted?.Invoke(false);
    }


    private void OnHotKey1(InputAction.CallbackContext ctx)
    {
        HotKeyPressed?.Invoke(0);
    }
    private void OnHotKey2(InputAction.CallbackContext ctx)
    {
        HotKeyPressed?.Invoke(1);

    }
    private void OnHotKey3(InputAction.CallbackContext ctx)
    {
        HotKeyPressed?.Invoke(2);
    }



}
