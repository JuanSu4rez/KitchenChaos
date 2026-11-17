using System;
using _Project.Scripts.PlayerStateMachine;
using UnityEngine;

namespace _Project.Scripts
{
    public class Player : MonoBehaviour, IKitchenObjectParent
    {
        
        internal static Player Instance { get; private set; }
        
        // Events
        internal event EventHandler<OnSelectedInteractableChangedEventArgs> OnInteractableFaced;

        internal class OnSelectedInteractableChangedEventArgs : EventArgs
        {
            internal IInteractable SelectedInteractable;
        }
        
        
        [SerializeField] private Transform attachmentPoint;
        [SerializeField] private float speed = 7f;
        [SerializeField] private GameInput gameInput;

        private KitchenObject kitchenObject;
        
        
        private Vector3 _lastInteractDirection;
        internal IInteractable SelectedObject { get; set; }
        
        internal float Speed => speed;
        internal GameInput GameInput => gameInput;
        
        // PlayerStates
        
        private IPlayerBaseState _currentState;
        internal IdleState IdleState;
        internal WalkingState WalkingState;
        
        
        internal bool IsWalking => _currentState == WalkingState;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.Log("There is more than one Player instance");
            }
            
            Instance = this;
            IdleState = new IdleState(this);
            WalkingState = new WalkingState(this);
        }

        private void Start()
        {
            _currentState = IdleState;
            IdleState.EnterState();
            
            //Interaction events E for spawning, F for chopping, mixing, etc
            GameInput.OnPrimaryInteraction += PrimaryInteractionPerformed;
            GameInput.OnSecondaryInteraction += SecondaryInteractionDone;
        }

        private void OnDestroy()
        {
            if (gameInput == null)
                return;

            gameInput.OnPrimaryInteraction -= PrimaryInteractionPerformed;
            gameInput.OnSecondaryInteraction -= SecondaryInteractionDone;
        }

        private void Update()
        {
            _currentState.Update();
            PlayerInteractionDetector.UpdateSelection(this);
        }

        internal void TransitToState(IPlayerBaseState newState)
        {
            if (_currentState == newState)
            {
                return;
            }
            
            _currentState = newState;
            _currentState.EnterState();
        }

        internal void SetLastInteractDirection(Vector3 direction) => _lastInteractDirection = direction;

        internal Vector3 GetLastInteractDirection() => _lastInteractDirection;

        internal void NotifySelectedInteractableChanged(IInteractable interactable)
        {
            OnInteractableFaced?.Invoke(this, new OnSelectedInteractableChangedEventArgs
            {
                SelectedInteractable = interactable
            });
        }
        
        private void PrimaryInteractionPerformed(object sender, EventArgs e)
        {
            if (SelectedObject != null)
            {
                SelectedObject.Interact(this);
            }
        }

        private void SecondaryInteractionDone(object sender, EventArgs e)
        {
            if (SelectedObject is IAlternateInteractable alternateInteractable)
            {
                alternateInteractable.AlternateInteract(this);
            }
        }
        
        public Transform GetParentingPoint() => attachmentPoint;

        public void SetKitchenObject(KitchenObject obj) => kitchenObject = obj;

        public KitchenObject GetKitchenObject() => kitchenObject;
        
        public void ClearKitchenObject() => kitchenObject = null;
        
        public bool HasAnObject() => kitchenObject != null;
    }
}