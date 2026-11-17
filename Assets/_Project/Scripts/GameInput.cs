using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.Scripts
{
    public class GameInput : MonoBehaviour
    {
        private PlayerInputActions playerInputActions;
        internal event EventHandler OnPrimaryInteraction;
        internal event EventHandler OnSecondaryInteraction;

        private void Awake()
        {
            playerInputActions = new PlayerInputActions();
            playerInputActions.Player.Enable();
            
            playerInputActions.Player.PrimaryInteraction.performed += PrimaryInteractionDone;
            playerInputActions.Player.SecondaryInteraction.performed += SecondaryInteractionDone;
        }

        private void OnDestroy()
        {
            if (playerInputActions == null)
                return;

            playerInputActions.Player.PrimaryInteraction.performed -= PrimaryInteractionDone;
            playerInputActions.Player.SecondaryInteraction.performed -= SecondaryInteractionDone;
            playerInputActions.Dispose();
        }

        internal Vector2 GetMovementVectorNormalized()
        {
            Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
            return inputVector.normalized;
        }

        private void PrimaryInteractionDone(InputAction.CallbackContext callbackContext)
        {
            OnPrimaryInteraction?.Invoke(this, EventArgs.Empty);
        }
        
        private void SecondaryInteractionDone(InputAction.CallbackContext callbackContext)
        {
            OnSecondaryInteraction?.Invoke(this, EventArgs.Empty);
        }
    }
}