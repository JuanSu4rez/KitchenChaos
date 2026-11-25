
using System.Collections.Generic;
using _Project.Scripts;
using UnityEngine;

public class KitchenObjectsVisualsManager : MonoBehaviour
{
    public static KitchenObjectsVisualsManager Instance { get; private set; }
    [SerializeField] private List<IngredientPreparationSO> ingredientPreparationVisualsList;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("There is more than one KitchenObjectsVisualsManager instance");
        }
            
        Instance = this;
    }

    public Transform GetIngredientNewVisual(Ingredient ingredient, CookingStepTypes stepType)
    {
        var outputPrefabIngredient = ingredientPreparationVisualsList
            .Find( SO => SO.ingredientInput == ingredient.GetKitchenObjectSo().prefab && SO.stepType == stepType).ingredientOutput;
        return outputPrefabIngredient;
    }
}