using UnityEngine;

namespace _Project.Scripts
{
    public class ChoppingCounter : Interactable, IKitchenObjectParent
    {
        
        [SerializeField] private Transform attachmentPoint;
        [SerializeField] private KitchenObjectSO kitchenObjectSo;

        private KitchenObject kitchenObject;


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
        
        public Transform GetParentingPoint() => attachmentPoint;
        
        public void SetKitchenObject(KitchenObject obj) => kitchenObject = obj;
        
        public KitchenObject GetKitchenObject() => kitchenObject;
        
        public void ClearKitchenObject() => kitchenObject = null;
        
        public bool HasAnObject() => kitchenObject != null;
    }
}