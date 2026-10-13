using System;
using _Project.Scripts.PlayerStateMachine;
using UnityEngine;

namespace _Project.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float speed = 7f;
        [SerializeField] private GameInput gameInput;

        public ClearCounter SelectedCounter { get; set; }
        
        public float Speed => speed;
        public GameInput GameInput => gameInput;
        
        #region playerStates
        
        private IPlayerBaseState _currentState;
        public IdleState IdleState;
        public WalkingState WalkingState;
        public InteractingState InteractingState;
        
        #endregion playerStates
        
        public bool IsWalking => _currentState == WalkingState;
        public bool IsIdle => _currentState == IdleState;
        public bool IsInteracting => _currentState == InteractingState;

        private void Awake()
        {
            IdleState = new IdleState(this);
            WalkingState = new WalkingState(this);
            InteractingState = new InteractingState(this);
        }

        private void Start()
        {
            _currentState = IdleState;
            IdleState.EnterState();
            
            //Interaction events E for spawning, F for chopping, mixing, etc
            GameInput.OnPrimaryInteraction += PrimaryInteractionDone;
            GameInput.OnSecondaryInteraction += SecondaryInteractionDone;
        }

        private void Update()
        {
            _currentState.Update();
        }

        public void TransitToState(IPlayerBaseState newState)
        {
            if (_currentState == newState)
            {
                return;
            }
            
            _currentState = newState;
            _currentState.EnterState();
        }
        
        private void PrimaryInteractionDone(object sender, EventArgs e)
        {
            Debug.Log("Primary interaction done");
        }

        private void SecondaryInteractionDone(object sender, EventArgs e)
        {
            Debug.Log("Secondary interaction done");
        }

    }
}