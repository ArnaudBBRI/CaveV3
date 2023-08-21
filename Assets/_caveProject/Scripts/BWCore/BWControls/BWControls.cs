// GENERATED AUTOMATICALLY FROM 'Assets/_caveProject/Scripts/BWCore/BWControls/BWControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @BWControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @BWControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""BWControls"",
    ""maps"": [
        {
            ""name"": ""InGame"",
            ""id"": ""6e9a2ea9-41f1-499b-b059-7667b1939c97"",
            ""actions"": [
                {
                    ""name"": ""move"",
                    ""type"": ""Value"",
                    ""id"": ""f2faf1cd-fe90-4332-8cdc-1dcbf6da2377"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""point"",
                    ""type"": ""Value"",
                    ""id"": ""2ec28842-f057-4b59-8f8c-1b783ac65903"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""verticalMove"",
                    ""type"": ""Value"",
                    ""id"": ""ac097f6e-a2cc-473e-82c5-8092285c8455"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""look"",
                    ""type"": ""Value"",
                    ""id"": ""5508a565-a9ae-4761-a1f6-1616250aa289"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""restart"",
                    ""type"": ""Button"",
                    ""id"": ""07df3824-f881-431d-b5a6-16c092f42f07"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""changeCursorMode"",
                    ""type"": ""Button"",
                    ""id"": ""0eaba414-15ee-4f26-a089-449c432eaa9a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""465956a4-41ae-4555-8306-00c56f1a7d3e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a3b77474-22a9-4d90-8513-06fd9ab4b218"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""128cb4cb-590a-4bb1-95bc-00626c45cd4f"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""07f8b6d3-4cf6-4165-9b1e-0aef3417fea9"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8cca8ab3-eff9-413f-8e5e-20ac4012d9ea"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""aa3a6079-c9b1-477d-b2b0-43d79c0513f7"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""b82c0c19-0508-47f0-9502-a1087aed1bbd"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""verticalMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a56837f3-488e-43b4-a774-ea79dc95548a"",
                    ""path"": ""<Keyboard>/#(q)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""verticalMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""08e1a0ae-d44e-431a-96d7-4ce28ded27e2"",
                    ""path"": ""<Keyboard>/#(a)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""verticalMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""cd17529c-712b-4246-bd7d-5acdd96b38c0"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2(invertX=false)"",
                    ""groups"": """",
                    ""action"": ""look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aed7a1ae-f1e9-4453-8e79-0f5d22f8021e"",
                    ""path"": ""<Keyboard>/#(r)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c62f672-b539-45e6-bc8b-dd8c862695c2"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""changeCursorMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // InGame
        m_InGame = asset.FindActionMap("InGame", throwIfNotFound: true);
        m_InGame_move = m_InGame.FindAction("move", throwIfNotFound: true);
        m_InGame_point = m_InGame.FindAction("point", throwIfNotFound: true);
        m_InGame_verticalMove = m_InGame.FindAction("verticalMove", throwIfNotFound: true);
        m_InGame_look = m_InGame.FindAction("look", throwIfNotFound: true);
        m_InGame_restart = m_InGame.FindAction("restart", throwIfNotFound: true);
        m_InGame_changeCursorMode = m_InGame.FindAction("changeCursorMode", throwIfNotFound: true);
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

    // InGame
    private readonly InputActionMap m_InGame;
    private IInGameActions m_InGameActionsCallbackInterface;
    private readonly InputAction m_InGame_move;
    private readonly InputAction m_InGame_point;
    private readonly InputAction m_InGame_verticalMove;
    private readonly InputAction m_InGame_look;
    private readonly InputAction m_InGame_restart;
    private readonly InputAction m_InGame_changeCursorMode;
    public struct InGameActions
    {
        private @BWControls m_Wrapper;
        public InGameActions(@BWControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @move => m_Wrapper.m_InGame_move;
        public InputAction @point => m_Wrapper.m_InGame_point;
        public InputAction @verticalMove => m_Wrapper.m_InGame_verticalMove;
        public InputAction @look => m_Wrapper.m_InGame_look;
        public InputAction @restart => m_Wrapper.m_InGame_restart;
        public InputAction @changeCursorMode => m_Wrapper.m_InGame_changeCursorMode;
        public InputActionMap Get() { return m_Wrapper.m_InGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InGameActions set) { return set.Get(); }
        public void SetCallbacks(IInGameActions instance)
        {
            if (m_Wrapper.m_InGameActionsCallbackInterface != null)
            {
                @move.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnMove;
                @move.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnMove;
                @move.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnMove;
                @point.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnPoint;
                @point.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnPoint;
                @point.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnPoint;
                @verticalMove.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnVerticalMove;
                @verticalMove.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnVerticalMove;
                @verticalMove.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnVerticalMove;
                @look.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnLook;
                @look.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnLook;
                @look.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnLook;
                @restart.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnRestart;
                @restart.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnRestart;
                @restart.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnRestart;
                @changeCursorMode.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnChangeCursorMode;
                @changeCursorMode.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnChangeCursorMode;
                @changeCursorMode.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnChangeCursorMode;
            }
            m_Wrapper.m_InGameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @move.started += instance.OnMove;
                @move.performed += instance.OnMove;
                @move.canceled += instance.OnMove;
                @point.started += instance.OnPoint;
                @point.performed += instance.OnPoint;
                @point.canceled += instance.OnPoint;
                @verticalMove.started += instance.OnVerticalMove;
                @verticalMove.performed += instance.OnVerticalMove;
                @verticalMove.canceled += instance.OnVerticalMove;
                @look.started += instance.OnLook;
                @look.performed += instance.OnLook;
                @look.canceled += instance.OnLook;
                @restart.started += instance.OnRestart;
                @restart.performed += instance.OnRestart;
                @restart.canceled += instance.OnRestart;
                @changeCursorMode.started += instance.OnChangeCursorMode;
                @changeCursorMode.performed += instance.OnChangeCursorMode;
                @changeCursorMode.canceled += instance.OnChangeCursorMode;
            }
        }
    }
    public InGameActions @InGame => new InGameActions(this);
    public interface IInGameActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
        void OnVerticalMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
        void OnChangeCursorMode(InputAction.CallbackContext context);
    }
}
