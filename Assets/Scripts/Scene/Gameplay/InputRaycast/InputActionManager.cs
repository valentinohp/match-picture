//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/Scene/Gameplay/InputRaycast/InputManager.inputactions
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

namespace MatchPicture.Gameplay.InputRaycast
{
    public partial class @InputActionManager : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputActionManager()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputManager"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""1dc90e19-e6f2-45db-b7c0-5f9717e1301f"",
            ""actions"": [
                {
                    ""name"": ""Touchscreen"",
                    ""type"": ""PassThrough"",
                    ""id"": ""45e643a6-2463-4dbb-855e-2783d0ccd4e0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1311cd33-2818-4b21-8cec-ea61ebf464a7"",
                    ""path"": ""<Touchscreen>/primaryTouch/startPosition"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""Touchscreen"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mobile"",
            ""bindingGroup"": ""Mobile"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_Touchscreen = m_Player.FindAction("Touchscreen", throwIfNotFound: true);
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

        // Player
        private readonly InputActionMap m_Player;
        private IPlayerActions m_PlayerActionsCallbackInterface;
        private readonly InputAction m_Player_Touchscreen;
        public struct PlayerActions
        {
            private @InputActionManager m_Wrapper;
            public PlayerActions(@InputActionManager wrapper) { m_Wrapper = wrapper; }
            public InputAction @Touchscreen => m_Wrapper.m_Player_Touchscreen;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    @Touchscreen.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchscreen;
                    @Touchscreen.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchscreen;
                    @Touchscreen.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchscreen;
                }
                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Touchscreen.started += instance.OnTouchscreen;
                    @Touchscreen.performed += instance.OnTouchscreen;
                    @Touchscreen.canceled += instance.OnTouchscreen;
                }
            }
        }
        public PlayerActions @Player => new PlayerActions(this);
        private int m_MobileSchemeIndex = -1;
        public InputControlScheme MobileScheme
        {
            get
            {
                if (m_MobileSchemeIndex == -1) m_MobileSchemeIndex = asset.FindControlSchemeIndex("Mobile");
                return asset.controlSchemes[m_MobileSchemeIndex];
            }
        }
        public interface IPlayerActions
        {
            void OnTouchscreen(InputAction.CallbackContext context);
        }
    }
}
