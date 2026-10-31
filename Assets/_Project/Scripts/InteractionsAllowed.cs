using System.Collections.Generic;
using _Project.Scripts;
using UnityEngine;

[CreateAssetMenu(fileName = "NewScriptableObjectScript", menuName = "Scriptable Objects/NewScriptableObjectScript")]
public class InteractionsAllowed : ScriptableObject
{
    [SerializeField]
    public List<IngredientSteps> allowedInteractions;
    
    public List<StepTypes> GetRequiredSteps(KitchenObjectSO ingredient)
    {
        var entry = allowedInteractions.Find(i => i.GetIngredient().GetKitchenObjectSo() == ingredient);
        return entry != null ? entry.GetCookingSteps() : new List<StepTypes>();
    }
}
 