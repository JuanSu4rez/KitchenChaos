using System;
using UnityEngine;
using static _Project.Scripts.CookingTask;

namespace _Project.Scripts
{
    public abstract class FoodProcessingCounter : BaseCounter, IAlternateInteractable, IHasKitchenTask
    {
        public event EventHandler<KitchenObject> OnKitchenObjectAdded;
        public event EventHandler<KitchenObject> OnKitchenObjectRemoved;
        public KitchenTask KitchenTask { get; protected set; }
        
        public void Start() => KitchenTask.OnProgressChanged += OnProgressChanged;
        
        public virtual void OnProgressChanged(object sender, KitchenTask.ProgressChangedEventArgs e) { }   
        
        
        public override void SetKitchenObject(KitchenObject obj)
        {
            base.SetKitchenObject(obj);
            if (obj != null)
                OnKitchenObjectAdded?.Invoke(this, obj);
            else
                OnKitchenObjectRemoved?.Invoke(this, obj);
        }
        
        public override void ClearKitchenObject()
        {
            base.ClearKitchenObject();
            OnKitchenObjectRemoved?.Invoke(this, GetKitchenObject());
        }

        public virtual void AlternateInteract(Player interactor) { }
        
        private void OnDestroy()
        {
            if (KitchenTask != null)
                KitchenTask.OnProgressChanged -= OnProgressChanged;
        }
    }
}
