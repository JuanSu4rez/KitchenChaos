using UnityEngine;

namespace _Project.Scripts.PlayerStateMachine
{
    public class IdleState : IPlayerBaseState
    {
        private Player _player;
        
        public IdleState(Player player) => _player = player;
        
        public override void EnterState()
        {
            Debug.Log("Idle State Entered");
        }

        public override void Update()
        {
            Vector2 inputVector = _player.GameInput.GetMovementVectorNormalized();

            if (inputVector != Vector2.zero)
            {
                _player.TransitToState(_player.WalkingState);
            }
        }
    }
}