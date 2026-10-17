using _Project.Scripts;
using JetBrains.Annotations;
using UnityEngine;

namespace _Project.Scripts
{

    public class ClearCounter : MonoBehaviour, IInteractable
    {

        [SerializeField] private Transform attachmentPoint;
        [SerializeField] private KitchenObjectSO kitchenObjectSo;

        private KitchenObject kitchenObject;



        public void Interact(Player interactor)
        {   
            //Interactor DOES NOT HAVE an object
            if (interactor.IsAvailable())
            {
                //THERE IS NO OBJECT ON THIS COUNTER -> SPAWN A NEW ONE
                if (IsAvailable())
                {
                    Transform kitchenObjectTransform = Instantiate(kitchenObjectSo.prefab, attachmentPoint);
                    kitchenObjectTransform.GetComponent<KitchenObject>().SetInteractableParent(this);
                    return;
                } 
                
                //THERE IS AN OBJECT ON THIS COUNTER -> GIVE IT TO INTERACTOR
                kitchenObject.SetInteractableParent(interactor);
                return;
            }
            
            //INTERACTOR HAS AN OBJECT AND COUNTER IS AVAILABLE -> DROP IT HERE 
            if (IsAvailable())
            {
                var objectFromInteractor = interactor.GetKitchenObject(); 
                objectFromInteractor.GetComponent<KitchenObject>().SetInteractableParent(this);
            }
            
        }
        
        public Transform GetParentingPoint() => attachmentPoint;
        
        public void SetKitchenObject(KitchenObject obj) => kitchenObject = obj;
        
        public KitchenObject GetKitchenObject() => kitchenObject;
        
        public void ClearKitchenObject() => kitchenObject = null;
        
        public bool IsAvailable() => kitchenObject == null;
    }
}
