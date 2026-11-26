using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using static _Project.Scripts.CookingTask;

namespace _Project.Scripts
{
    public class ChoppingBoardCounter : FoodProcessingObject
    {
        [SerializeField] private List<IngredientPreparationSO> choppedIngredientsSOArray;
        [FormerlySerializedAs("effortPerInteraction")] [SerializeField] protected float effortPerChop = 0.13f;
        
        public void Awake() => _cookingTask = new ChoppingTask();
        
        public override void OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if(e.progressNormalized >= 1f)
            {
                var ingredient = GetKitchenObject()?.GetComponent<Ingredient>();
                ingredient.AddCookingStep(_cookingTask.StepType);
            }
        }   
        
        public override void AlternateInteract(Player interactor)
        {
            if (GetKitchenObject() is not Ingredient ingredient) 
                return;
            
            var requiredPreparationSteps = IngredientsInteractionsManager.GetIngredientPreparationSteps(ingredient);
            
            if (!requiredPreparationSteps.Contains(_cookingTask.StepType) || ingredient.GetCompletedCookingSteps().Contains(_cookingTask.StepType)) 
                return;
            
            _cookingTask.AddProgress(effortPerChop);
        } 
        
        public override void Interact(Player interactor)
        {
            if (_cookingTask.IsInProgress())
                return;
            
            TransferKitchenObject(interactor);
        }
    }
}