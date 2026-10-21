using UnityEngine;

namespace _Project.Scripts
{
    public class ContainerCounter : Interactable, IKitchenObjectParent
    {
        [SerializeField] private Transform attachmentPoint;
        [SerializeField] private KitchenObjectSO kitchenObjectSo;

        private KitchenObject kitchenObject;



        public override void Interact(Player interactor)
        {   
            //Interactor IS EMPTY HANDED
            if (!interactor.HasAnObject())
            {
                //THERE IS NO OBJECT ON THIS COUNTER -> SPAWN A NEW ONE
                if (!HasAnObject())
                {
                    Transform kitchenObjectTransform = Instantiate(kitchenObjectSo.prefab, attachmentPoint);
                    kitchenObjectTransform.GetComponent<KitchenObject>().SetInteractableParent(this);
                }
                
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