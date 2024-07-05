//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/inputHandling/TouchInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @TouchInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @TouchInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TouchInputActions"",
    ""maps"": [
        {
            ""name"": ""Touch"",
            ""id"": ""2cdfdd5f-71e5-4761-ad11-d60c25a3f750"",
            ""actions"": [
                {
                    ""name"": ""PrimaryTouch"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a1871367-22da-4955-8ef7-7d2697dda62d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PrimaryTouchPressure"",
                    ""type"": ""PassThrough"",
                    ""id"": ""00c18b3f-7a5a-4f68-a01f-1c87b08a894f"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""90a222dc-0fd0-4eb1-bb34-ed17d7359b1f"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1fa11ff7-29e0-4fad-bdc7-6ef4cc3ed7ea"",
                    ""path"": ""<Touchscreen>/primaryTouch/pressure"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryTouchPressure"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Pinch"",
            ""id"": ""85571c72-a35d-4957-a462-b6292bab8995"",
            ""actions"": [
                {
                    ""name"": ""PrimaryTouch"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f6e323f1-6bfa-4d86-8ffb-4b0b84798c6c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SecondaryTouch"",
                    ""type"": ""PassThrough"",
                    ""id"": ""efa41eef-fa1a-4d7c-8181-0f88777fbc13"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8f0e3861-f6ea-4874-9380-e538f4da95c4"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9fbed460-f721-48e1-80a5-86fd53a7fdae"",
                    ""path"": ""<Touchscreen>/touch1/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Touch
        m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
        m_Touch_PrimaryTouch = m_Touch.FindAction("PrimaryTouch", throwIfNotFound: true);
        m_Touch_PrimaryTouchPressure = m_Touch.FindAction("PrimaryTouchPressure", throwIfNotFound: true);
        // Pinch
        m_Pinch = asset.FindActionMap("Pinch", throwIfNotFound: true);
        m_Pinch_PrimaryTouch = m_Pinch.FindAction("PrimaryTouch", throwIfNotFound: true);
        m_Pinch_SecondaryTouch = m_Pinch.FindAction("SecondaryTouch", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Touch
    private readonly InputActionMap m_Touch;
    private List<ITouchActions> m_TouchActionsCallbackInterfaces = new List<ITouchActions>();
    private readonly InputAction m_Touch_PrimaryTouch;
    private readonly InputAction m_Touch_PrimaryTouchPressure;
    public struct TouchActions
    {
        private @TouchInputActions m_Wrapper;
        public TouchActions(@TouchInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @PrimaryTouch => m_Wrapper.m_Touch_PrimaryTouch;
        public InputAction @PrimaryTouchPressure => m_Wrapper.m_Touch_PrimaryTouchPressure;
        public InputActionMap Get() { return m_Wrapper.m_Touch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
        public void AddCallbacks(ITouchActions instance)
        {
            if (instance == null || m_Wrapper.m_TouchActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_TouchActionsCallbackInterfaces.Add(instance);
            @PrimaryTouch.started += instance.OnPrimaryTouch;
            @PrimaryTouch.performed += instance.OnPrimaryTouch;
            @PrimaryTouch.canceled += instance.OnPrimaryTouch;
            @PrimaryTouchPressure.started += instance.OnPrimaryTouchPressure;
            @PrimaryTouchPressure.performed += instance.OnPrimaryTouchPressure;
            @PrimaryTouchPressure.canceled += instance.OnPrimaryTouchPressure;
        }

        private void UnregisterCallbacks(ITouchActions instance)
        {
            @PrimaryTouch.started -= instance.OnPrimaryTouch;
            @PrimaryTouch.performed -= instance.OnPrimaryTouch;
            @PrimaryTouch.canceled -= instance.OnPrimaryTouch;
            @PrimaryTouchPressure.started -= instance.OnPrimaryTouchPressure;
            @PrimaryTouchPressure.performed -= instance.OnPrimaryTouchPressure;
            @PrimaryTouchPressure.canceled -= instance.OnPrimaryTouchPressure;
        }

        public void RemoveCallbacks(ITouchActions instance)
        {
            if (m_Wrapper.m_TouchActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ITouchActions instance)
        {
            foreach (var item in m_Wrapper.m_TouchActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_TouchActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public TouchActions @Touch => new TouchActions(this);

    // Pinch
    private readonly InputActionMap m_Pinch;
    private List<IPinchActions> m_PinchActionsCallbackInterfaces = new List<IPinchActions>();
    private readonly InputAction m_Pinch_PrimaryTouch;
    private readonly InputAction m_Pinch_SecondaryTouch;
    public struct PinchActions
    {
        private @TouchInputActions m_Wrapper;
        public PinchActions(@TouchInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @PrimaryTouch => m_Wrapper.m_Pinch_PrimaryTouch;
        public InputAction @SecondaryTouch => m_Wrapper.m_Pinch_SecondaryTouch;
        public InputActionMap Get() { return m_Wrapper.m_Pinch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PinchActions set) { return set.Get(); }
        public void AddCallbacks(IPinchActions instance)
        {
            if (instance == null || m_Wrapper.m_PinchActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PinchActionsCallbackInterfaces.Add(instance);
            @PrimaryTouch.started += instance.OnPrimaryTouch;
            @PrimaryTouch.performed += instance.OnPrimaryTouch;
            @PrimaryTouch.canceled += instance.OnPrimaryTouch;
            @SecondaryTouch.started += instance.OnSecondaryTouch;
            @SecondaryTouch.performed += instance.OnSecondaryTouch;
            @SecondaryTouch.canceled += instance.OnSecondaryTouch;
        }

        private void UnregisterCallbacks(IPinchActions instance)
        {
            @PrimaryTouch.started -= instance.OnPrimaryTouch;
            @PrimaryTouch.performed -= instance.OnPrimaryTouch;
            @PrimaryTouch.canceled -= instance.OnPrimaryTouch;
            @SecondaryTouch.started -= instance.OnSecondaryTouch;
            @SecondaryTouch.performed -= instance.OnSecondaryTouch;
            @SecondaryTouch.canceled -= instance.OnSecondaryTouch;
        }

        public void RemoveCallbacks(IPinchActions instance)
        {
            if (m_Wrapper.m_PinchActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPinchActions instance)
        {
            foreach (var item in m_Wrapper.m_PinchActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PinchActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PinchActions @Pinch => new PinchActions(this);
    public interface ITouchActions
    {
        void OnPrimaryTouch(InputAction.CallbackContext context);
        void OnPrimaryTouchPressure(InputAction.CallbackContext context);
    }
    public interface IPinchActions
    {
        void OnPrimaryTouch(InputAction.CallbackContext context);
        void OnSecondaryTouch(InputAction.CallbackContext context);
    }
}
