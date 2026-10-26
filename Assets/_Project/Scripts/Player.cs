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
            public Interactable SelectedInteractable;
        }
        
        
        [SerializeField] private Transform attachmentPoint;
        [SerializeField] private float speed = 7f;
        [SerializeField] private GameInput gameInput;

        private KitchenObject kitchenObject;
        
        
        private Vector3 _lastInteractDirection;
        public Interactable SelectedObject { get; set; }
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
            
            CheckIfPlayerCanInteract();
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
        
        private void PrimaryInteractionPerformed(object sender, EventArgs e)
        {
            if (SelectedObject != null)
            {
                SelectedObject.Interact(this);
            }
        }

        private void SecondaryInteractionDone(object sender, EventArgs e)
        {
            if (SelectedObject != null)
            {
                SelectedObject.InteractSecondary(this);
            }
        }

        
        // Check if the player can interact with an object in their line of sight.
        private void CheckIfPlayerCanInteract()
        {
            Vector2 inputVector = GameInput.GetMovementVectorNormalized();
            Vector3 movementDirection = new Vector3(inputVector.x, 0, inputVector.y).normalized;

            if (movementDirection != Vector3.zero)
            {
                _lastInteractDirection = movementDirection;
            }

            var interactionDistance = 1.5f;
            if (Physics.Raycast(transform.position, _lastInteractDirection, out RaycastHit hit, interactionDistance))
            {
                if(hit.transform.TryGetComponent(out Interactable interactable))
                {
                    SetSelectedInteractable(interactable);
                    return;
                }
            }
            SetSelectedInteractable(null);
        }

        private void SetSelectedInteractable(Interactable interactable)
        {
            if (SelectedObject == interactable)
            {
                return;
            }

            SelectedObject = interactable;
            OnInteractableFaced?.Invoke(this, new OnSelectedInteractableChangedEventArgs
            {
                SelectedInteractable = interactable
            });
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