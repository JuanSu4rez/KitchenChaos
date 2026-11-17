using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts
{
    public class Ingredient : KitchenObject, IHasProgress
    {
        public event EventHandler<ProgressChangedEventArgs> OnProgressChanged;

        [Serializable]
        private struct StepEffort
        {
            public PreparationSteps step;
            public float effort;
        }

        // How much work each step takes for this ingredient (e.g. chops, or seconds on a stove)
        [SerializeField] private float defaultStepEffort = 5f;
        [SerializeField] private List<StepEffort> stepEfforts = new();

        private readonly List<PreparationSteps> _completedSteps = new();
        private CookingStep _currentStep;

        public float ProgressNormalized => _currentStep?.ProgressNormalized ?? 0f;

        internal bool IsStepInProgress(PreparationSteps step) => _currentStep != null && _currentStep.Step == step;

        // Applies work from a station. Returns false if this step can't be done on this ingredient right now.
        internal bool ApplyWork(PreparationSteps step, float amount)
        {
            if (!IsNextStep(step))
                return false;

            _currentStep ??= new CookingStep(step, GetEffortFor(step));
            _currentStep.AddProgress(amount);
            RaiseProgressChanged(_currentStep.ProgressNormalized);

            if (!_currentStep.IsCompleted())
                return true;

            _completedSteps.Add(step);
            _currentStep = null;
            return true;
        }

        private bool IsNextStep(PreparationSteps step)
        {
            var requiredSteps = GetRequiredSteps();
            return _completedSteps.Count < requiredSteps.Count && requiredSteps[_completedSteps.Count] == step;
        }

        private List<PreparationSteps> GetRequiredSteps()
        {
            var rules = IngredientsInteractionsManager.Instance != null
                ? IngredientsInteractionsManager.Instance.GetInteractionsAllowed()
                : null;

            return rules != null ? rules.GetRequiredSteps(GetKitchenObjectSo()) : new List<PreparationSteps>();
        }

        private float GetEffortFor(PreparationSteps step)
        {
            foreach (var entry in stepEfforts)
            {
                if (entry.step == step)
                    return entry.effort;
            }

            return defaultStepEffort;
        }

        private void RaiseProgressChanged(float progressNormalized) =>
            OnProgressChanged?.Invoke(this, new ProgressChangedEventArgs { progressNormalized = progressNormalized });
    }
}
