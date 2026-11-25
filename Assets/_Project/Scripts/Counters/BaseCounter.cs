using System;
using UnityEngine;

namespace _Project.Scripts
{
    public abstract class BaseCounter : MonoBehaviour, IInteractable, IKitchenObjectParent
    {
        [SerializeField] private Transform attachmentPoint;
        [SerializeField] private KitchenObject kitchenObject;

        public event EventHandler OnKitchenObjectChanged;
        //TODO - THIS IS A GOOD PLACE TO RISE AN EVENT WHEN A KITCHEN OBJECT IS REMOVED OR/AND ADDED.
        
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

        public void SetKitchenObject(KitchenObject obj)
        {
            if (kitchenObject == obj)
                return;

            kitchenObject = obj;
            OnKitchenObjectChanged?.Invoke(this, EventArgs.Empty);
        }

        public KitchenObject GetKitchenObject() => kitchenObject;

        public void ClearKitchenObject() => SetKitchenObject(null);

        public bool HasAnObject() => kitchenObject != null;

        public abstract void Interact(Player interactor);
    }
}
