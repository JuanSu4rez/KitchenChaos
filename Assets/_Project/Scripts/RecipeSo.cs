using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Scripts
{
    [CreateAssetMenu(fileName = "RecipeSo", menuName = "MY SCRIPTABLE OBJECTS/RecipeSo")]
    public class RecipeSo : ScriptableObject
    {
        public string Name;
        public Sprite sprite;
        public List<IngredientSteps> tasks;
    }
}