using _Project.Scripts;
using JetBrains.Annotations;
using UnityEngine;

namespace _Project.Scripts
{

    public class ClearCounter : BaseCounter
    {
        [SerializeField] private KitchenObjectSO kitchenObjectSo;
        public override void Interact(Player interactor)
        {
            base.TransferKitchenObject(interactor);
        }
    }
}
