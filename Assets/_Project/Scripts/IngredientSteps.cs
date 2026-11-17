using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts
{
    [System.Serializable]
    public class IngredientSteps
    {
        [SerializeField]
        private Ingredient _ingredient;
        
        [SerializeField]
        private List<PreparationSteps> _cookingSteps;
        
        internal Ingredient GetIngredient() => _ingredient;
        
        internal List<PreparationSteps> GetCookingSteps() => _cookingSteps;
    }
}