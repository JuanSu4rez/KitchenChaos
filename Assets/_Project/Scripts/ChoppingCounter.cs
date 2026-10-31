using UnityEngine;
using System.Linq;

namespace _Project.Scripts
{
    public class ChoppingCounter : Interactable, IKitchenObjectParent
    {
        
        [SerializeField] private Transform attachmentPoint;
        
        public override void Interact(Player interactor)
        {   
            //Interactor IS EMPTY HANDED
            if (!interactor.HasAnObject())
            {
                //THERE IS NO OBJECT ON THIS COUNTER -> DO NOTHING
                if (!HasAnObject()) return;
                
                //THERE IS AN OBJECT ON THIS COUNTER -> GIVE IT TO INTERACTOR
                kitchenObject.SetInteractableParent(interactor);
                return;
            }
            
            //INTERACTOR HAS AN OBJECT AND COUNTER IS AVAILABLE -> DROP IT HERE 
            if (!HasAnObject())
            {
                var objectFromInteractor = interactor.GetKitchenObject(); 
                objectFromInteractor.GetComponent<KitchenObject>().SetInteractableParent(this);
            }
        }

        public override void InteractSecondary(Player interactor)
        {
            if(!IsSecondaryInteractionAllowed())
                return;
            
            Chop();
        }

        private void Chop()
        {
            if (!_cookingStep.IsInProgress())
            {
                _cookingStep.Begin(100);
                LockKitchenObject();
            }

            //TODO - THIS IS JUST FOR TESTING DONT LET THIS '20' HERE
            _cookingStep.AddProgress(20);

            if (!_cookingStep.IsCompleted())
                return;

            UnlockKitchenObject();
        }
       
        

        public Transform GetParentingPoint() => attachmentPoint;
        
        public void SetKitchenObject(KitchenObject obj) => kitchenObject = obj;
        
        public KitchenObject GetKitchenObject() => kitchenObject;
        
        public void ClearKitchenObject() => kitchenObject = null;
        
        public bool HasAnObject() => kitchenObject != null;
    }
}