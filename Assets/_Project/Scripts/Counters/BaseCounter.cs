using System;
using UnityEngine;

namespace _Project.Scripts
{
    public abstract class BaseCounter : MonoBehaviour, IInteractable, IKitchenObjectParent
    {
        [SerializeField] private Transform attachmentPoint;
        [SerializeField] private KitchenObject kitchenObject;
       
        
        public void TransferKitchenObject(Player interactor)
        {
            //PLayer takes the object from the counter
            if (!interactor.HasAnObject())
            {
                if (HasAnObject())
                {
                    GetKitchenObject().SetInteractableParent(interactor);
                }
                return;
            }

            //Counter takes the object from the player
            if (!HasAnObject())
            {
                interactor.GetKitchenObject().SetInteractableParent(this);
                return;
            }

            //Both have an object, check if they can be combined
            Debug.Log("Resolving interaction between " + GetKitchenObject().name + " and " + interactor.GetKitchenObject().name);
            ResolveInteraction(GetKitchenObject(), interactor.GetKitchenObject());
            
            // _ = ResolveInteraction(interactor.GetKitchenObject(), GetKitchenObject());
        }

        private void ResolveInteraction(KitchenObject objOnCounter, KitchenObject playerObj)
        {
            
            if (objOnCounter is CookWare cookWare && playerObj is Ingredient ingredient)
            {
                cookWare.AddIngredient(ingredient);
                return;
            }
            
            // if (objOnCounter is Ingredient counterIngredient && playerObj is CookWare playerCookWare)
            // {
            //     playerCookWare.SetKitchenObject(counterIngredient);
            //     return;
            // }   
        }

        public Transform GetParentingPoint() => attachmentPoint;

        public virtual void SetKitchenObject(KitchenObject obj)
        {
            if (kitchenObject == obj)
                return;

            kitchenObject = obj;
        }

        public KitchenObject GetKitchenObject() => kitchenObject;

        public virtual void ClearKitchenObject() => SetKitchenObject(null);
        
        public bool HasAnObject() => kitchenObject != null;

        public abstract void Interact(Player interactor);
        
        private void AddIngredientFromPlayerToCookWareOnCounter(){}
        
        private void AddIngredientFromCookWareOnCounterToPlayer(){}
    }
}
