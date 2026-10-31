using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace _Project.Scripts
{
    [Serializable]
    public class Ingredient : KitchenObject
    {
        private bool _isLocked;
        private IngredientStates _state;
        private List<StepTypes> _completedSteps = new();
        
        public void AddStepCompleted(StepTypes step) => _completedSteps.Add(step);
        
        public bool IsNextStep(StepTypes step, List<StepTypes> requiredSteps) =>
            _completedSteps.Count < requiredSteps.Count && requiredSteps[_completedSteps.Count] == step;

        public bool IsReady(List<StepTypes> requiredSteps) => _completedSteps.Count >= requiredSteps.Count;
    }
}