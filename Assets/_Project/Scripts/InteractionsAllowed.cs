using System.Collections.Generic;
using _Project.Scripts;
using UnityEngine;

[CreateAssetMenu(fileName = "NewScriptableObjectScript", menuName = "Scriptable Objects/NewScriptableObjectScript")]
public class InteractionsAllowed : ScriptableObject
{
    [SerializeField]
    public List<IngredientSteps> allowedInteractions;
}
 