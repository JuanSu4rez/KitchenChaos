using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using static _Project.Scripts.CookingTask;

namespace _Project.Scripts
{
    public class ChoppingBoardCounter : FoodProcessingCounter
    {
        [FormerlySerializedAs("effortPerInteraction")] [SerializeField] protected float effortPerChop = 0.13f;

        public void Awake() => KitchenTask = new ChoppingTask();
        
        public override void OnProgressChanged(object sender, KitchenTask.ProgressChangedEventArgs e)
        {
            if(e.progressNormalized >= 1f)
            {
                var ingredient = GetKitchenObject()?.GetComponent<Ingredient>();
                ingredient.AddCookingStep(CookingStepTypes.Chop);
            }
        }   
        
        public override void AlternateInteract(Player interactor)
        {
            if (GetKitchenObject() is not Ingredient ingredient) 
                return;
            
            var requiredPreparationSteps = IngredientsInteractionsManager.GetIngredientPreparationSteps(ingredient);
            
            if (!requiredPreparationSteps.Contains(CookingStepTypes.Chop) || ingredient.GetCompletedCookingSteps().Contains(CookingStepTypes.Chop)) 
                return;
            
            Chop(ingredient);
        }

        private void Chop(Ingredient ingredient)
        {   
            KitchenTask.AddProgress(effortPerChop);
        }

        public override void Interact(Player interactor)
        {
            if (KitchenTask.IsInProgress())
                return;
            
            TransferKitchenObject(interactor);
        }
    }
}