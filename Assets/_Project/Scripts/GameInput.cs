using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.Scripts
{
    public class GameInput : MonoBehaviour
    {
        private PlayerInputActions playerInputActions;
        public event EventHandler OnPrimaryInteraction;
        public event EventHandler OnSecondaryInteraction;
        
        private void Awake()
        {
            playerInputActions = new PlayerInputActions();
            playerInputActions.Player.Enable();
            
            playerInputActions.Player.PrimaryInteraction.performed += PrimaryInteractionDone;
            playerInputActions.Player.SecondaryInteraction.performed += SecondaryInteractionDone;
        }

        private void Update()
        {
            var inputVector = GetMovementVectorNormalized();
        }

        public Vector2 GetMovementVectorNormalized()
        {
            Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
            inputVector = inputVector.normalized;
            return inputVector;
        }

        public void PrimaryInteractionDone(InputAction.CallbackContext callbackContext)
        {
            OnPrimaryInteraction?.Invoke(this, EventArgs.Empty);
        }
        
        public void SecondaryInteractionDone(InputAction.CallbackContext callbackContext)
        {
            OnSecondaryInteraction?.Invoke(this, EventArgs.Empty);
        }
    }
}