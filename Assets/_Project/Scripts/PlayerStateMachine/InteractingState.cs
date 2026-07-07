using _Project.Scripts.PlayerStateMachine;
using UnityEngine;

namespace _Project.Scripts
{
    public class InteractingState : IPlayerBaseState
    {
        private Player _player;
        
        public InteractingState(Player player) => _player = player;
        
        public override void EnterState()
        {
            Debug.Log("Interacting State Entered");
        }

        public override void Update()
        {
            Debug.Log("Interacting State Updated");
        }
    }
}