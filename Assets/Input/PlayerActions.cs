//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Input/PlayerActions.inputactions
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

public partial class @PlayerActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""Ant"",
            ""id"": ""99895129-f8d4-4dac-86e8-cb2afb4a4d5b"",
            ""actions"": [
                {
                    ""name"": ""Dive"",
                    ""type"": ""Button"",
                    ""id"": ""7d948bb3-8b1d-4d21-afe1-c1f5c89bfcd2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c536e102-8036-4a4c-9aff-e663e42cb6ee"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Ant
        m_Ant = asset.FindActionMap("Ant", throwIfNotFound: true);
        m_Ant_Dive = m_Ant.FindAction("Dive", throwIfNotFound: true);
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

    // Ant
    private readonly InputActionMap m_Ant;
    private List<IAntActions> m_AntActionsCallbackInterfaces = new List<IAntActions>();
    private readonly InputAction m_Ant_Dive;
    public struct AntActions
    {
        private @PlayerActions m_Wrapper;
        public AntActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Dive => m_Wrapper.m_Ant_Dive;
        public InputActionMap Get() { return m_Wrapper.m_Ant; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AntActions set) { return set.Get(); }
        public void AddCallbacks(IAntActions instance)
        {
            if (instance == null || m_Wrapper.m_AntActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_AntActionsCallbackInterfaces.Add(instance);
            @Dive.started += instance.OnDive;
            @Dive.performed += instance.OnDive;
            @Dive.canceled += instance.OnDive;
        }

        private void UnregisterCallbacks(IAntActions instance)
        {
            @Dive.started -= instance.OnDive;
            @Dive.performed -= instance.OnDive;
            @Dive.canceled -= instance.OnDive;
        }

        public void RemoveCallbacks(IAntActions instance)
        {
            if (m_Wrapper.m_AntActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IAntActions instance)
        {
            foreach (var item in m_Wrapper.m_AntActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_AntActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public AntActions @Ant => new AntActions(this);
    public interface IAntActions
    {
        void OnDive(InputAction.CallbackContext context);
    }
}
