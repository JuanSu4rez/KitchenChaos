using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Scripts
{
    [System.Serializable]
    public class IngredientSteps
    {
        [SerializeField]
        private Ingredient _ingredient;
        
        [SerializeField]
        private List<PreparationSteps> _cookingSteps;
        
        public Ingredient GetIngredient() => _ingredient;
        
        public List<PreparationSteps> GetCookingSteps() => _cookingSteps;
    }
}