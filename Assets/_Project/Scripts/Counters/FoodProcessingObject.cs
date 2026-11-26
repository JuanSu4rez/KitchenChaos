using System;
using UnityEngine;
using static _Project.Scripts.CookingTask;

namespace _Project.Scripts
{
    public abstract class FoodProcessingObject : BaseCounter, IAlternateInteractable
    {
        protected CookingTask _cookingTask;

        public void Start() => _cookingTask.OnProgressChanged += OnProgressChanged;

        public CookingTask GetCookingTask() => _cookingTask;
        
        public virtual void OnProgressChanged(object sender, ProgressChangedEventArgs e) { }   
        
        private void OnDestroy()
        {
            if (_cookingTask != null)
                _cookingTask.OnProgressChanged -= OnProgressChanged;
        }

        public virtual void AlternateInteract(Player interactor) { }
    }
}
