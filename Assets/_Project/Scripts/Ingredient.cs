using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts
{
    public class Ingredient : KitchenObject
    {
        public event EventHandler<PreparationStepCompletedEventArgs> OnPreparationStepCompleted;
    
        public class PreparationStepCompletedEventArgs : EventArgs
        {
            public KitchenObjectSO KitchenObjectSo;
            public CookingStepTypes completedStepType;
        }
        
        [SerializeField] private IngredientStates _ingredientState;
        
        private readonly List<CookingStepTypes> _completedCookingSteps = new();

        public void AddCookingStep(CookingStepTypes stepType)
        {
            _completedCookingSteps.Add(stepType);
            OnPreparationStepCompleted?
                .Invoke(
                this, 
                new PreparationStepCompletedEventArgs { completedStepType = stepType, KitchenObjectSo = KitchenObjectSo }
                );
        }
        
        public IngredientStates GetIngredientState() => _ingredientState;
        public List<CookingStepTypes> GetCompletedCookingSteps() => _completedCookingSteps;

    }
}
