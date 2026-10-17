using UnityEngine;

namespace _Project.Scripts
{
    public interface IInteractable
    {
        public bool IsAvailable();
        
        //TODO - This is actually a collection, not a single object,
        // an Stack maybe?, a proper structure should be used
        public KitchenObject GetKitchenObject();
        
        public void Interact(Player interactor);

        public void SetKitchenObject(KitchenObject kitchenObject);
        
        
        public void ClearKitchenObject();

        public Transform GetParentingPoint();
    }
}