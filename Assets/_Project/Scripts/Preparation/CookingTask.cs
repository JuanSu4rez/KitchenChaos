using System;
using UnityEngine;

namespace _Project.Scripts
{
    [Serializable]
    public abstract class CookingTask
    {
        public event EventHandler<ProgressChangedEventArgs> OnProgressChanged;
        public class ProgressChangedEventArgs : EventArgs
        {
            public float progressNormalized;
        }

        [SerializeField]
        private readonly float _totalEffort = 1f;
        private float _progress;
        private CookingStepTypes _stepType;
        private Ingredient _ingredient;

        public CookingTask(CookingStepTypes stepType)
        {
            _stepType = stepType;
        }

        public CookingStepTypes StepType => _stepType;

        public float ProgressNormalized => _progress / _totalEffort;

        public bool IsCompleted() => !IsInProgress();
        
        public bool IsInProgress() => _progress > 0f && _progress < _totalEffort;
        
        public void AddProgress(float amount)
        {
            _progress += amount;
            OnProgressChanged?.Invoke(this, new ProgressChangedEventArgs { progressNormalized = ProgressNormalized });
            
            if(_progress > _totalEffort)
            {
                _progress = 0f;
            }
        }
    }
}
