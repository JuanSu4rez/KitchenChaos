using System;
using UnityEngine;

namespace _Project.Scripts
{
    public class GameInput : MonoBehaviour
    {
        private PlayerInputActions playerInputActions;
        
        private void Awake()
        {
            playerInputActions = new PlayerInputActions();
            playerInputActions.Player.Enable();
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
    }
}