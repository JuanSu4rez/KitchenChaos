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
        private List<StepTypes> _cookingSteps;
        
        public Ingredient GetIngredient() => _ingredient;
        
        public List<StepTypes> GetCookingSteps() => _cookingSteps;
    }
}