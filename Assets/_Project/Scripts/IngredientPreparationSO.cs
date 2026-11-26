using UnityEngine;

namespace _Project.Scripts
{
    [CreateAssetMenu(fileName = "ChoppedIngredientsSO", menuName = "MY SCRIPTABLE OBJECTS/ChoppedIngredientsSO")]
    public class IngredientPreparationSO : ScriptableObject
    {
        public CookingStepTypes stepType;
        public Transform ingredientInput; 
        public Transform ingredientOutput;
        public string objectName;
    }
}