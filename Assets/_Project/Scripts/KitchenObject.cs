using UnityEngine;

namespace _Project.Scripts
{
    public class KitchenObject : MonoBehaviour
    {
        [SerializeField] 
        protected KitchenObjectSO KitchenObjectSo;
        
        //The parent object where the kitchenObject is located
        private IKitchenObjectParent _interactableParent;
        
        
        public KitchenObjectSO GetKitchenObjectSo() => KitchenObjectSo;
        
        public void SetInteractableParent(IKitchenObjectParent interactable)
        {
            if (interactable.HasAnObject())
            {
                Debug.Log("Interactable is not available");
                return;
            }
            
            if (_interactableParent != null)
            {
               _interactableParent.ClearKitchenObject();
            }
            
            _interactableParent = interactable;
            _interactableParent.SetKitchenObject(this);
            
            //PARENTING POINT
            transform.parent = _interactableParent.GetParentingPoint();
            transform.localPosition = Vector3.zero;
        }
    }
}
