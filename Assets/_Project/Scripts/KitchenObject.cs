using UnityEngine;

namespace _Project.Scripts
{
    public class KitchenObject : MonoBehaviour
    {
        [SerializeField] private KitchenObjectSO kitchenObjectSO;
        
        
        //The parent object where the kitchenObject is located
        private IInteractable _interactableParent;
        
        
        public KitchenObjectSO GetKitchenObjectSo() => kitchenObjectSO;
        
        public void SetInteractableParent(IInteractable interactable)
        {
            if (_interactableParent != null)
            {
               _interactableParent.ClearKitchenObject();
            }
            
            _interactableParent = interactable;
            if (!interactable.IsAvailable())
            {
                Debug.Log("Interactable is not available");
                return;
            }
            
            _interactableParent.SetKitchenObject(this);
            
            //PARENTING POINT
            transform.parent = _interactableParent.GetParentingPoint();
            transform.localPosition = Vector3.zero;
        }
        
        public IInteractable GetInteractable() => _interactableParent;
    }
}
