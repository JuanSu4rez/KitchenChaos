using UnityEngine;

namespace _Project.Scripts
{
    // Progress of a single preparation step. Owned by the Ingredient being prepared,
    // so it travels with the food (e.g. a pan moved between stoves keeps its progress).
    internal sealed class CookingStep
    {
        private readonly float _totalEffort;
        private float _progress;

        internal CookingStep(PreparationSteps step, float totalEffort)
        {
            Step = step;
            _totalEffort = Mathf.Max(0.01f, totalEffort);
        }

        internal PreparationSteps Step { get; }

        internal float ProgressNormalized => _progress / _totalEffort;

        internal bool IsCompleted() => _progress >= _totalEffort;

        internal void AddProgress(float amount) => _progress = Mathf.Min(_progress + amount, _totalEffort);
    }
}
