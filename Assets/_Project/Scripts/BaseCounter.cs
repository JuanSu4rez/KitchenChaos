using UnityEngine;

namespace _Project.Scripts
{
    // Common base for counters that can hold a single KitchenObject
    public abstract class BaseCounter : MonoBehaviour, IInteractable, IKitchenObjectParent
    {
        [SerializeField] private Transform attachmentPoint;
        [SerializeField] private KitchenObject kitchenObject;

        // Default pick-up / drop behaviour between the interactor and this counter
        public void TransferKitchenObject(Player interactor)
        {
            if (!interactor.HasAnObject())
            {
                if (HasAnObject())
                {
                    GetKitchenObject().SetInteractableParent(interactor);
                }
                return;
            }

            if (!HasAnObject())
            {
                interactor.GetKitchenObject().SetInteractableParent(this);
            }
        }

        public Transform GetParentingPoint() => attachmentPoint;

        public void SetKitchenObject(KitchenObject obj) => kitchenObject = obj;

        public KitchenObject GetKitchenObject() => kitchenObject;

        public void ClearKitchenObject() => kitchenObject = null;

        public bool HasAnObject() => kitchenObject != null;

        public abstract void Interact(Player interactor);
    }
}
