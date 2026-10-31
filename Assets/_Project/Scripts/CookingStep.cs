using System;
using UnityEngine;

namespace _Project.Scripts
{
    [System.Serializable]
    public class CookingStep
    {
        
        public event EventHandler<OnProgressChangedEventArgs> OnProgressChanged;
        public event EventHandler OnStepStarted;
        public event EventHandler OnStepCompleted;
        public class OnProgressChangedEventArgs: EventArgs
        {
            public float progressNormalized;
        }
        
        [SerializeField]
        private StepTypes _stepType;
        [SerializeField]
        private int _totalEffort;
        private int _progress;
        private bool _isCompleted;
        private bool _isInProgress;

        public CookingStep() { } // kept for Unity deserialization
        public CookingStep(StepTypes stepType, int totalEffort)
        {
            _stepType = stepType;
            _totalEffort = totalEffort;
        }

        // Resets this step so the same instance (and its subscribers) can be reused for the next task
        public void Begin(int totalEffort)
        {
            _totalEffort = Mathf.Max(1, totalEffort);
            _progress = 0;
            _isCompleted = false;
            _isInProgress = true;

            OnStepStarted?.Invoke(this, EventArgs.Empty);
            RaiseProgressChanged();
        }

        public void AddProgress(int newProgress)
        {
            if (!_isInProgress)
                return;

            _progress = Mathf.Min(_progress + newProgress, _totalEffort);
            RaiseProgressChanged();

            if (_progress < _totalEffort)
                return;

            _isCompleted = true;
            _isInProgress = false;
            OnStepCompleted?.Invoke(this, EventArgs.Empty);
        }

        private void RaiseProgressChanged()
        {
            OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
                {
                    progressNormalized = _progress / (float)_totalEffort
                }
            );
        }

        public bool IsCompleted() => _isCompleted;

        public bool IsInProgress() => _isInProgress;

        public int GetTotalEffort() => _totalEffort;

        public int GetProgress() => _progress;
        
    }

    
}