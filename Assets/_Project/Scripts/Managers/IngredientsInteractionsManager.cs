using System.Collections.Generic;
using System.Linq;
using _Project.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

public class IngredientsInteractionsManager : MonoBehaviour
{
    [FormerlySerializedAs("interactionsAllowed")] [SerializeField]
    protected StepPreparationAllowed stepPreparationAllowed;
    
    public static IngredientsInteractionsManager Instance { get; private set; }


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("There is more than one IngredientsInteractionsManager instance");
        }
            
        Instance = this;
    }

    private StepPreparationAllowed GetPreparationSteps() => stepPreparationAllowed;
    
    public static List<CookingStepTypes> GetIngredientPreparationSteps(Ingredient ingredient)
    {
        Debug.Log("1111");
        var ingredientPreparationStepsList = Instance.GetPreparationSteps().allowedInteractions.FindAll(i => i.GetIngredient().GetKitchenObjectSo() == ingredient.GetKitchenObjectSo());
        var result = ingredientPreparationStepsList.ToList().Find(i => i.GetIngredient().GetKitchenObjectSo() == ingredient.GetKitchenObjectSo());;
        Debug.Log("22222222222");
        return result != null ? result.GetCookingSteps() : new List<CookingStepTypes>();
    }
    
}