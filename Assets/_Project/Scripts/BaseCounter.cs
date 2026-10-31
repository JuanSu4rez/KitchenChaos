using UnityEngine;

namespace _Project.Scripts
{
    // Common base for counters that can hold a single KitchenObject
    public abstract class BaseCounter : Interactable, IKitchenObjectParent
    {
        [SerializeField] private Transform attachmentPoint;

        // Default pick-up / drop behaviour between the interactor and this counter
        protected void TransferKitchenObject(Player interactor)
        {
            //Interactor IS EMPTY HANDED
            if (!interactor.HasAnObject())
            {
                //THERE IS AN OBJECT ON THIS COUNTER -> GIVE IT TO INTERACTOR
                if (HasAnObject())
                    kitchenObject.SetInteractableParent(interactor);
                return;
            }

            //INTERACTOR HAS AN OBJECT AND COUNTER IS AVAILABLE -> DROP IT HERE
            if (!HasAnObject())
                interactor.GetKitchenObject().SetInteractableParent(this);
        }

        public Transform GetParentingPoint() => attachmentPoint;

        public void SetKitchenObject(KitchenObject obj) => kitchenObject = obj;

        public KitchenObject GetKitchenObject() => kitchenObject;

        public void ClearKitchenObject() => kitchenObject = null;

        public bool HasAnObject() => kitchenObject != null;
    }
}
