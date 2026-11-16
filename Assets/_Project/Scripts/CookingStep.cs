using UnityEngine;

namespace _Project.Scripts
{
    // Progress of a single preparation step. Owned by the Ingredient being prepared,
    // so it travels with the food (e.g. a pan moved between stoves keeps its progress).
    public class CookingStep
    {
        private readonly float _totalEffort;
        private float _progress;

        public CookingStep(PreparationSteps step, float totalEffort)
        {
            Step = step;
            _totalEffort = Mathf.Max(0.01f, totalEffort);
        }

        public PreparationSteps Step { get; }

        public float ProgressNormalized => _progress / _totalEffort;

        public bool IsCompleted() => _progress >= _totalEffort;

        public void AddProgress(float amount) => _progress = Mathf.Min(_progress + amount, _totalEffort);
    }
}
