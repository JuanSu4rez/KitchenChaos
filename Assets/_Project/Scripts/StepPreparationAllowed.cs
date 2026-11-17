using System.Collections.Generic;
using _Project.Scripts;
using UnityEngine;

[CreateAssetMenu(fileName = "NewScriptableObjectScript", menuName = "Scriptable Objects/NewScriptableObjectScript")]
public class StepPreparationAllowed : ScriptableObject
{
    [SerializeField] private List<IngredientSteps> allowedInteractions;
    
    internal List<PreparationSteps> GetRequiredSteps(KitchenObjectSO ingredient)
    {
        var entry = allowedInteractions.Find(i => i.GetIngredient().GetKitchenObjectSo() == ingredient);
        return entry != null ? entry.GetCookingSteps() : new List<PreparationSteps>();
    }
}
 