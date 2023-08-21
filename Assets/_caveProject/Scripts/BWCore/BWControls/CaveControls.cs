// GENERATED AUTOMATICALLY FROM 'Assets/_caveProject/Scripts/BWCore/BWControls/CaveControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CaveControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CaveControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CaveControls"",
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
    public struct InGameActions
    {
        private @CaveControls m_Wrapper;
        public InGameActions(@CaveControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @move => m_Wrapper.m_InGame_move;
        public InputAction @point => m_Wrapper.m_InGame_point;
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
            }
        }
    }
    public InGameActions @InGame => new InGameActions(this);
    public interface IInGameActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
    }
}
