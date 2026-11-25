using System;
using UnityEngine;
using static _Project.Scripts.Ingredient;

namespace _Project.Scripts
{
    /// <summary>
    /// Cache Ingredient in Awake() and subscribe/unsubscribe in OnEnable() / OnDisable().
    /// That avoids repeated component lookups and makes the subscription follow the visual component’s enabled state.
    /// </summary>
    public class IngredientVisual : MonoBehaviour
    {
        [SerializeField] private Transform initialVisual;
        private Ingredient _ingredient;
        
        private void Awake() => _ingredient = GetComponent<Ingredient>();
        
        private void OnEnable() => _ingredient.OnPreparationStepCompleted += OnPreparationStepCompleted;

        private void OnPreparationStepCompleted(object sender, PreparationStepCompletedEventArgs e)
        {
            var result = KitchenObjectsVisualsManager.Instance.GetIngredientNewVisual(_ingredient, e.completedStepType);
             
             // Destroy(initialVisual.gameObject);
            // var outputPrefab = Instantiate(result, initialVisual.position, initialVisual.rotation, initialVisual.parent);
            // var newVisual = result.GetComponent<MeshRenderer>();
             
            Debug.Log($"New visual: {result}");
            Debug.Log(result.GetChild(0).GetChild(0).GetComponent<MeshRenderer>());
            initialVisual = result.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().transform;


        }

        private void OnDisable() => _ingredient.OnPreparationStepCompleted -= OnPreparationStepCompleted;
    }
}