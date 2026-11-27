using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts
{
    public class FryingPan : CookWare, IHasKitchenTask
    {
        [SerializeField] private Transform attachmentPoint;
        [SerializeField] private KitchenObject kitchenObject;
        public KitchenTask KitchenTask { get; protected set; }
        
        public void Awake() => KitchenTask = new FryingTask();
        
        public override void AddIngredient(Ingredient ingredient)
        {
            var requiredPreparationSteps = IngredientsInteractionsManager.GetIngredientPreparationSteps(ingredient);
            
            // TODO - THERE IS A BUG WITH THIS IMPLEMENTATION
            //  THIS NEEDS AN ADDITIONAL CHECK.
            //  NOT ONLY IF THE INGREDIENT NEEDS TO BE FRIED, BUT ALSO IF FRYING IS THE NEXT STEP IN THE PREPARATION PROCESS.
            //  OTHERWISE, THE PLAYER COULD FRY AN INGREDIENT THAT NEEDS TO BE CHOPPED FIRST.
            if (!requiredPreparationSteps.Contains(CookingStepTypes.Fry) || ingredient.GetCompletedCookingSteps().Contains(CookingStepTypes.Fry)) 
                return;
            
            ingredient.SetInteractableParent(this);
        }
        
        public override Transform GetParentingPoint() => attachmentPoint;
        
        public override void SetKitchenObject(KitchenObject obj)
        {
            if (kitchenObject == obj)
                return;

            kitchenObject = obj;
        }
        
        public override bool HasAnObject() => kitchenObject != null;

        public void AddHeat(float heatAmount)
        {
            if(kitchenObject is not Ingredient ingredient)
                return;
            
            KitchenTask.AddProgress(heatAmount);
        }
    }
}