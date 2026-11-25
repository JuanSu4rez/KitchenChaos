using UnityEngine;

namespace _Project.Scripts
{
    public class ContainerCounter : BaseCounter
    {
        [SerializeField] private KitchenObjectSO kitchenObjectSo;

        private KitchenObject kitchenObject;

        public override void Interact(Player interactor)
        {
            if (!interactor.HasAnObject() && !HasAnObject())
            {
                Transform kitchenObjectTransform = Instantiate(kitchenObjectSo.prefab, GetParentingPoint());
                kitchenObjectTransform.GetComponent<KitchenObject>().SetInteractableParent(this);
            }
        
            TransferKitchenObject(interactor);
        }
        
    }
}
