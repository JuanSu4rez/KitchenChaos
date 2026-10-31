using UnityEngine;
using System.Linq;

namespace _Project.Scripts
{
    public class ChoppingCounter : BaseCounter
    {
        public override void Interact(Player interactor)
        {
            if (kitchenObjectIsLocked)
                return;

            TransferKitchenObject(interactor);
        }

        public override void InteractSecondary(Player interactor)
        {
            if(!IsSecondaryInteractionAllowed())
                return;
            
            Chop();
        }

        private void Chop()
        {
            if (!_cookingStep.IsInProgress())
            {
                //TODO - THIS IS JUST FOR TESTING DONT LET THIS '100' HERE
                _cookingStep.Begin(100);
                LockKitchenObject();
            }

            //TODO - THIS IS JUST FOR TESTING DONT LET THIS '20' HERE
            _cookingStep.AddProgress(15);

            if (!_cookingStep.IsCompleted())
                return;

            UnlockKitchenObject();
            kitchenObject.GetComponent<Ingredient>().AddStepCompleted(StepTypes.Chop);
        }
    }
}