using UnityEngine;

namespace _Project.Scripts
{
    public interface IKitchenObjectParent
    {
        public bool HasAnObject();
        
        //TODO - This is actually a collection, not a single object,
        // an Stack maybe?, a proper structure should be used
        public KitchenObject GetKitchenObject();
        

        public void SetKitchenObject(KitchenObject kitchenObject);
        
        
        public void ClearKitchenObject();

        public Transform GetParentingPoint();
    }
}