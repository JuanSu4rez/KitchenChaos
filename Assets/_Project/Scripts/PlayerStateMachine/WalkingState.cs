using UnityEngine;

namespace _Project.Scripts.PlayerStateMachine
{
    public class WalkingState : IPlayerBaseState
    {
        private const float ROTATE_SPEED = 10f;
        private const float PLAYER_CAPSULE_COLLIDER_RADIUS = .7f;
        private const float PLAYER_CAPSULE_COLLIDER_HEIGHT = 2f;
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
                _player.TransitToState(_player.IdleState);
                return;
            }
    
            Walk(inputVector);
        }

        private void Walk(Vector2 inputVector)
        {
            float movementDistance = _player.Speed * Time.deltaTime;
            Vector3 movementDirection = new Vector3(inputVector.x, 0, inputVector.y).normalized;
    
            _player.transform.forward = Vector3.Slerp(_player.transform.forward, movementDirection, Time.deltaTime * ROTATE_SPEED);
            
            // Try to move in the desired direction ... 
            if (TryMoveInDirection(movementDirection, movementDistance)) return;
            
            // ... if that fails, try to move in the x direction only ...
            if (TryMoveInDirection(new Vector3(inputVector.x, 0, 0).normalized, movementDistance)) return;
            
            // ... if that fails, try to move in the z direction only ...
            if (TryMoveInDirection(new Vector3(0, 0, inputVector.y).normalized, movementDistance)) ;
            
        }

        private bool TryMoveInDirection(Vector3 direction, float distance)
        {
            if (CheckIfPlayerCollides(direction, distance))
            {
                return false;
            }
    
            _player.transform.position += direction * (_player.Speed * Time.deltaTime);
            return true;
        }
        
        
        // Capsule cast to check for collisions,
        // which is more accurate than a raycast for a player character,
        // as it takes into account the player's height and radius.
        private bool CheckIfPlayerCollides(Vector3 movementDirection, float movementDistance)
        {
            return Physics.CapsuleCast(
                _player.transform.position, 
                _player.transform.position + Vector3.up * PLAYER_CAPSULE_COLLIDER_HEIGHT, 
                PLAYER_CAPSULE_COLLIDER_RADIUS,
                movementDirection,
                movementDistance);
        }

    }
}