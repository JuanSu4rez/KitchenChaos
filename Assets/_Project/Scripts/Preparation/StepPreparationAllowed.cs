using System.Collections.Generic;
using _Project.Scripts;
using UnityEngine;

[CreateAssetMenu(fileName = "NewScriptableObjectScript", menuName = "Scriptable Objects/NewScriptableObjectScript")]
public class StepPreparationAllowed : ScriptableObject
{
    [SerializeField]
    public List<IngredientPreparationSteps> allowedInteractions;
    
}
 