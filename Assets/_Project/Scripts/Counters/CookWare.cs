using UnityEngine;

namespace _Project.Scripts
{
    public abstract class CookWare : KitchenObject, IKitchenObjectParent, IInteractable
    {
        public virtual bool HasAnObject() => 
            throw new System.NotImplementedException("HasAnObject() not implemented in CookwareObject");
        
        public virtual KitchenObject GetKitchenObject() =>
            throw new System.NotImplementedException("GetKitchenObject() not implemented in CookwareObject");
        
        public virtual void SetKitchenObject(KitchenObject kitchenObject) => 
            throw new System.NotImplementedException("SetKitchenObject() not implemented in CookwareObject");
        
        public virtual void ClearKitchenObject() => 
            throw new System.NotImplementedException("ClearKitchenObject() not implemented in CookwareObject");
        
        public virtual Transform GetParentingPoint() => 
            throw new System.NotImplementedException("GetParentingPoint() not implemented in CookwareObject");

        public virtual void Interact(Player interactor) => throw new System.NotImplementedException("Interact() not implemented in CookwareObject");
        
        public abstract void AddIngredient(Ingredient ingredient);
    }
}