using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Scripts
{
    [System.Serializable]
    public class IngredientPreparationSteps
    {
        [SerializeField]
        private Ingredient _ingredient;
        
        [SerializeField]
        private List<CookingStepTypes> _cookingSteps;
        
        public Ingredient GetIngredient() => _ingredient;
        
        public List<CookingStepTypes> GetCookingSteps() => _cookingSteps;
    }
}