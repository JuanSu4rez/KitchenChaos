using System;
using _Project.Scripts.PlayerStateMachine;
using UnityEngine;

namespace _Project.Scripts
{
    public class Player : MonoBehaviour, IKitchenObjectParent
    {
        
        public static Player Instance { get; private set; }
        
        // Events
        public event EventHandler<OnSelectedInteractableChangedEventArgs> OnInteractableFaced;

        public class OnSelectedInteractableChangedEventArgs : EventArgs
        {
            public IInteractable SelectedInteractable;
        }
        
        
        [SerializeField] private Transform attachmentPoint;
        [SerializeField] private float speed = 7f;
        [SerializeField] private GameInput gameInput;

        private KitchenObject kitchenObject;
        
        
        private Vector3 _lastInteractDirection;
        public IInteractable SelectedObject { get; set; }
        public Transform HeldObject { get; set; }
        
        public float Speed => speed;
        public GameInput GameInput => gameInput;
        
        // PlayerStates
        
        private IPlayerBaseState _currentState;
        public IdleState IdleState;
        public WalkingState WalkingState;
        public InteractingState InteractingState;
        
        
        public bool IsWalking => _currentState == WalkingState;
        public bool IsIdle => _currentState == IdleState;
        public bool IsInteracting => _currentState == InteractingState;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.Log("There is more than one Player instance");
            }
            
            Instance = this;
            IdleState = new IdleState(this);
            WalkingState = new WalkingState(this);
            InteractingState = new InteractingState(this);
        }

        private void Start()
        {
            _currentState = IdleState;
            IdleState.EnterState();
            
            //Interaction events E for spawning, F for chopping, mixing, etc
            GameInput.OnPrimaryInteraction += PrimaryInteractionPerformed;
            GameInput.OnSecondaryInteraction += SecondaryInteractionDone;
        }

        private void Update()
        {
            _currentState.Update();
            PlayerInteractionDetector.UpdateSelection(this);
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

        public void SetLastInteractDirection(Vector3 direction) => _lastInteractDirection = direction;

        public Vector3 GetLastInteractDirection() => _lastInteractDirection;

        public void NotifySelectedInteractableChanged(IInteractable interactable)
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
        
        public void Interact(Player interactor)
        {
            
        }

        public Transform GetParentingPoint() => attachmentPoint;

        public void SetKitchenObject(KitchenObject obj) => kitchenObject = obj;

        public KitchenObject GetKitchenObject() => kitchenObject;
        
        public void ClearKitchenObject() => kitchenObject = null;
        
        public bool HasAnObject() => kitchenObject != null;
    }
}