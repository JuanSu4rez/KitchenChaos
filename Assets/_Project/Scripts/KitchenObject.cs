using UnityEngine;

namespace _Project.Scripts
{
    public class KitchenObject : MonoBehaviour
    {
        [SerializeField] private KitchenObjectSO kitchenObjectSO;
        
        
        //The parent object where the kitchenObject is located
        private IKitchenObjectParent _interactableParent;
        
        
        public KitchenObjectSO GetKitchenObjectSo() => kitchenObjectSO;
        
        public void SetInteractableParent(IKitchenObjectParent interactable)
        {
            if (_interactableParent != null)
            {
               _interactableParent.ClearKitchenObject();
            }
            
            _interactableParent = interactable;
            if (interactable.HasAnObject())
            {
                Debug.Log("Interactable is not available");
                return;
            }
            
            _interactableParent.SetKitchenObject(this);
            
            //PARENTING POINT
            transform.parent = _interactableParent.GetParentingPoint();
            transform.localPosition = Vector3.zero;
        }
    }
}
