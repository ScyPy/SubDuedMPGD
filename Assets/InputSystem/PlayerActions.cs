// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/PlayerActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""PlayerControls"",
            ""id"": ""e64ba0d9-cb84-4bcd-9a93-8ca0086bf016"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3c93cce7-7b9f-4b70-8a79-2074f96ff07c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2e4a257b-2cf1-4ec0-bb1a-d3568b3389bf"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""4a30e6cb-b9ba-4b74-bed7-59601ac14d18"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""dc85bccd-54bb-4809-accf-df8e876936c5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""771b6d8e-3bb0-4885-8bfa-bbbeb78b6d7d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Hotkey1"",
                    ""type"": ""Button"",
                    ""id"": ""5c6677d8-918f-41a8-84b6-57c6896ddc68"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Hotkey2"",
                    ""type"": ""Button"",
                    ""id"": ""854eefed-c06c-48bf-91a0-e2764c925879"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Hotkey3"",
                    ""type"": ""Button"",
                    ""id"": ""af08ac28-f1d7-457b-8f98-1035ccdddbe1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""3a421711-4cb1-4940-a370-d09efede596b"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""cac7175c-8d6e-4204-95d4-c1df04fe1e3c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1cb0e704-806b-4c46-8703-a04b1551ba73"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c8bf0188-03e4-4be2-8c7c-b489d336130e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b5143e19-759e-49e4-bd49-85bdcdc1eec7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0a697cf9-9a29-423d-92c5-37f0d7047772"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3820726e-95d1-4c71-9536-e22dba109f74"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ae4ea69-37cd-41d3-9f29-7b3b399ebf5f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7002f3d4-50de-4c7e-868c-7cdf97faee87"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fda5ee3c-4bc2-4aa2-96dd-ae3197ffb08e"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hotkey1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""77371ee4-3d45-4700-8a5d-dec7c0aac7fb"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hotkey2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55ff43c7-0b20-4c73-aecf-da1a29556f4e"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hotkey3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""CheatMenu"",
            ""id"": ""dde735cb-1592-4531-a3c6-1c32607ef94c"",
            ""actions"": [
                {
                    ""name"": ""RegisterCheat"",
                    ""type"": ""Button"",
                    ""id"": ""46cbd701-2f5a-40b4-9757-2074c3274f6b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CheatKey"",
                    ""type"": ""Button"",
                    ""id"": ""a8af6d49-4d91-4209-9409-ca7f47135f58"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""73fd0897-d50a-4aa2-970a-f98b6bfca9cd"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RegisterCheat"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc4c436a-b9e2-4449-a9b8-e964fc85611d"",
                    ""path"": ""<Keyboard>/slash"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CheatKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerControls
        m_PlayerControls = asset.FindActionMap("PlayerControls", throwIfNotFound: true);
        m_PlayerControls_Movement = m_PlayerControls.FindAction("Movement", throwIfNotFound: true);
        m_PlayerControls_Look = m_PlayerControls.FindAction("Look", throwIfNotFound: true);
        m_PlayerControls_Attack = m_PlayerControls.FindAction("Attack", throwIfNotFound: true);
        m_PlayerControls_Jump = m_PlayerControls.FindAction("Jump", throwIfNotFound: true);
        m_PlayerControls_Interact = m_PlayerControls.FindAction("Interact", throwIfNotFound: true);
        m_PlayerControls_Hotkey1 = m_PlayerControls.FindAction("Hotkey1", throwIfNotFound: true);
        m_PlayerControls_Hotkey2 = m_PlayerControls.FindAction("Hotkey2", throwIfNotFound: true);
        m_PlayerControls_Hotkey3 = m_PlayerControls.FindAction("Hotkey3", throwIfNotFound: true);
        // CheatMenu
        m_CheatMenu = asset.FindActionMap("CheatMenu", throwIfNotFound: true);
        m_CheatMenu_RegisterCheat = m_CheatMenu.FindAction("RegisterCheat", throwIfNotFound: true);
        m_CheatMenu_CheatKey = m_CheatMenu.FindAction("CheatKey", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // PlayerControls
    private readonly InputActionMap m_PlayerControls;
    private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
    private readonly InputAction m_PlayerControls_Movement;
    private readonly InputAction m_PlayerControls_Look;
    private readonly InputAction m_PlayerControls_Attack;
    private readonly InputAction m_PlayerControls_Jump;
    private readonly InputAction m_PlayerControls_Interact;
    private readonly InputAction m_PlayerControls_Hotkey1;
    private readonly InputAction m_PlayerControls_Hotkey2;
    private readonly InputAction m_PlayerControls_Hotkey3;
    public struct PlayerControlsActions
    {
        private @PlayerActions m_Wrapper;
        public PlayerControlsActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerControls_Movement;
        public InputAction @Look => m_Wrapper.m_PlayerControls_Look;
        public InputAction @Attack => m_Wrapper.m_PlayerControls_Attack;
        public InputAction @Jump => m_Wrapper.m_PlayerControls_Jump;
        public InputAction @Interact => m_Wrapper.m_PlayerControls_Interact;
        public InputAction @Hotkey1 => m_Wrapper.m_PlayerControls_Hotkey1;
        public InputAction @Hotkey2 => m_Wrapper.m_PlayerControls_Hotkey2;
        public InputAction @Hotkey3 => m_Wrapper.m_PlayerControls_Hotkey3;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMovement;
                @Look.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnLook;
                @Attack.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnAttack;
                @Jump.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                @Interact.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnInteract;
                @Hotkey1.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnHotkey1;
                @Hotkey1.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnHotkey1;
                @Hotkey1.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnHotkey1;
                @Hotkey2.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnHotkey2;
                @Hotkey2.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnHotkey2;
                @Hotkey2.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnHotkey2;
                @Hotkey3.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnHotkey3;
                @Hotkey3.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnHotkey3;
                @Hotkey3.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnHotkey3;
            }
            m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Hotkey1.started += instance.OnHotkey1;
                @Hotkey1.performed += instance.OnHotkey1;
                @Hotkey1.canceled += instance.OnHotkey1;
                @Hotkey2.started += instance.OnHotkey2;
                @Hotkey2.performed += instance.OnHotkey2;
                @Hotkey2.canceled += instance.OnHotkey2;
                @Hotkey3.started += instance.OnHotkey3;
                @Hotkey3.performed += instance.OnHotkey3;
                @Hotkey3.canceled += instance.OnHotkey3;
            }
        }
    }
    public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);

    // CheatMenu
    private readonly InputActionMap m_CheatMenu;
    private ICheatMenuActions m_CheatMenuActionsCallbackInterface;
    private readonly InputAction m_CheatMenu_RegisterCheat;
    private readonly InputAction m_CheatMenu_CheatKey;
    public struct CheatMenuActions
    {
        private @PlayerActions m_Wrapper;
        public CheatMenuActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @RegisterCheat => m_Wrapper.m_CheatMenu_RegisterCheat;
        public InputAction @CheatKey => m_Wrapper.m_CheatMenu_CheatKey;
        public InputActionMap Get() { return m_Wrapper.m_CheatMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CheatMenuActions set) { return set.Get(); }
        public void SetCallbacks(ICheatMenuActions instance)
        {
            if (m_Wrapper.m_CheatMenuActionsCallbackInterface != null)
            {
                @RegisterCheat.started -= m_Wrapper.m_CheatMenuActionsCallbackInterface.OnRegisterCheat;
                @RegisterCheat.performed -= m_Wrapper.m_CheatMenuActionsCallbackInterface.OnRegisterCheat;
                @RegisterCheat.canceled -= m_Wrapper.m_CheatMenuActionsCallbackInterface.OnRegisterCheat;
                @CheatKey.started -= m_Wrapper.m_CheatMenuActionsCallbackInterface.OnCheatKey;
                @CheatKey.performed -= m_Wrapper.m_CheatMenuActionsCallbackInterface.OnCheatKey;
                @CheatKey.canceled -= m_Wrapper.m_CheatMenuActionsCallbackInterface.OnCheatKey;
            }
            m_Wrapper.m_CheatMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RegisterCheat.started += instance.OnRegisterCheat;
                @RegisterCheat.performed += instance.OnRegisterCheat;
                @RegisterCheat.canceled += instance.OnRegisterCheat;
                @CheatKey.started += instance.OnCheatKey;
                @CheatKey.performed += instance.OnCheatKey;
                @CheatKey.canceled += instance.OnCheatKey;
            }
        }
    }
    public CheatMenuActions @CheatMenu => new CheatMenuActions(this);
    public interface IPlayerControlsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnHotkey1(InputAction.CallbackContext context);
        void OnHotkey2(InputAction.CallbackContext context);
        void OnHotkey3(InputAction.CallbackContext context);
    }
    public interface ICheatMenuActions
    {
        void OnRegisterCheat(InputAction.CallbackContext context);
        void OnCheatKey(InputAction.CallbackContext context);
    }
}
