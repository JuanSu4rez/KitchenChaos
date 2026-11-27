using System;
using UnityEngine;

namespace _Project.Scripts
{
    public class StoveCounter : BaseCounter
    {
        [SerializeField] private KitchenObjectSO kitchenObjectSo;

        public void Start() => SpawnFryingPan();

        private void SpawnFryingPan()
        {
            if (GetKitchenObject() != null)
                return;
            
            if(kitchenObjectSo.prefab.GetComponent(typeof(CookWare)) == null)
                throw new Exception("Prefab is not a Frying Pan");
            
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSo.prefab, GetParentingPoint());
            kitchenObjectTransform.GetComponent<KitchenObject>().SetInteractableParent(this);
        }

        public override void Interact(Player interactor)
        {
            TransferKitchenObject(interactor);
        }

        private void InductHeat(FryingPan fryingPan)
        {
            fryingPan.AddHeat((0.09f * Time.deltaTime));
        }

        public void Update()
        {
            if(!HasAnObject())
                return;
            
            if(GetKitchenObject() is not FryingPan fryingPan)
                return;
            
            InductHeat(fryingPan);
        }
    }
}