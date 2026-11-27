using System;
using UnityEngine;

namespace _Project.Scripts
{
    public abstract class KitchenTask
    {
        [SerializeField]
        protected readonly float _totalEffort = 1f;
        protected float _progress;
        public event EventHandler<ProgressChangedEventArgs> OnProgressChanged;
        
        public class ProgressChangedEventArgs : EventArgs
        {
            public float progressNormalized;
        }
        
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