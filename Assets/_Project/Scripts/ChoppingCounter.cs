using UnityEngine;

namespace _Project.Scripts
{
    public class ChoppingCounter : BaseCounter, IAlternateInteractable
    {
        [SerializeField] private float workPerChop = 1f;

        public override void Interact(Player interactor)
        {
            // Station rule: an ingredient can't be removed until chopping is finished
            if (GetKitchenObject() is Ingredient ingredient && ingredient.IsStepInProgress(PreparationSteps.Chop))
                return;

            TransferKitchenObject(interactor);
        }

        public void AlternateInteract(Player interactor)
        {
            if (GetKitchenObject() is Ingredient ingredient)
                ingredient.ApplyWork(PreparationSteps.Chop, workPerChop);
        }
    }
}
