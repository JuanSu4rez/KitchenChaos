using UnityEngine;

namespace _Project.Scripts.PlayerStateMachine
{
    public class WalkingState : IPlayerBaseState
    {
        private Player _player;
        
        public WalkingState(Player player) => _player = player;
        
        public override void EnterState()
        {
            Debug.Log("Running State Entered");
        }

        public override void Update()
        {
            Vector2 inputVector = _player.GameInput.GetMovementVectorNormalized();
            if (inputVector == Vector2.zero)
            {
                _player.TransitionToState(_player.IdleState);
                return;
            }
            
            Vector3 movement = new Vector3(inputVector.x, 0, inputVector.y);
            _player.transform.position += movement * (_player.Speed * Time.deltaTime);
            
            float rotateSpeed = 10f;
            _player.transform.forward = Vector3.Slerp(_player.transform.forward, movement, Time.deltaTime * rotateSpeed);
        }
    }
}