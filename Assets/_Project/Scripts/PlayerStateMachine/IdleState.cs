using UnityEngine;

namespace _Project.Scripts.PlayerStateMachine
{
    internal sealed class IdleState : IPlayerBaseState
    {
        private readonly Player _player;
        
        internal IdleState(Player player) => _player = player;
        
        internal override void Update()
        {
            Vector2 inputVector = _player.GameInput.GetMovementVectorNormalized();

            if (inputVector != Vector2.zero)
            {
                _player.TransitToState(_player.WalkingState);
            }
        }
    }
}