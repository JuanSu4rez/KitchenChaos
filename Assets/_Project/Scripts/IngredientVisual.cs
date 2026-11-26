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
            var outputPrefab = KitchenObjectsVisualsManager.Instance.GetIngredientNewVisual(_ingredient, e.completedStepType);
             
            if (outputPrefab == null || outputPrefab.childCount == 0)
            {
                Debug.LogError($"Missing output visual for {_ingredient.name}. DOES THE CUSTOM SCRIPTABLE OBJECT EXISTS?", this);
                Debug.LogError($"IT HAS BEEN ADDED TO THE KitchenObjectsVisualManager?", this);
                return;
            }

            // The first child of the output prefab is its visual wrapper.
            var visualTemplate = outputPrefab.GetChild(0);
            var parent = initialVisual.parent;
            var replacement = Instantiate(visualTemplate, parent, false);

            initialVisual.gameObject.SetActive(false);
            Destroy(initialVisual.gameObject);
            initialVisual = replacement;
        }

        private void OnDisable() => _ingredient.OnPreparationStepCompleted -= OnPreparationStepCompleted;
    }
}