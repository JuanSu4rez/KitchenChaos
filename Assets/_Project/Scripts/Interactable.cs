using System;
using System.Linq;
using UnityEngine;

namespace _Project.Scripts
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField]
        protected StepTypes secondaryInteraction;
        
        protected CookingStep _cookingStep;
        private InteractionsAllowed interactionsAllowed;
        protected KitchenObject kitchenObject;
        protected bool kitchenObjectIsLocked;
        

        // Created in Awake so observers (e.g. ProgressBarUI) can safely subscribe in their Start
        private void Awake()
        {
            _cookingStep = new CookingStep();
        }

        private void Start()
        {
            interactionsAllowed = IngredientsInteractionsManager.Instance.GetInteractionsAllowed();
        }

        public virtual void Interact(Player interactor)
        {
            Debug.Log("Interactable - Interact - default implementation"); 
        }
        
    
        public virtual void InteractSecondary(Player interactor)
        {
            Debug.Log("Interactable - InteractSecondary - default implementation"); 
        }
        
        protected bool IsSecondaryInteractionAllowed()
        {
            if (kitchenObject is not Ingredient ingredient)
                return false;

            var requiredSteps = interactionsAllowed.GetRequiredSteps(ingredient.GetKitchenObjectSo());
            return ingredient.IsNextStep(secondaryInteraction, requiredSteps);
        }

        
        /* An object gets locked when it is being interacted with (Secondary interaction)
         * until the secondary interaction is completed.
         * e.g. -> A tomato being chopped cannot be removed, unless the chopping has been completed.
         */
        
        // TODO - For now, this method locks any kind of object. HOWEVER, I need to review if this locking mechanism only applies to ingredients
        protected void LockKitchenObject() => kitchenObjectIsLocked = true;

        protected void UnlockKitchenObject() => kitchenObjectIsLocked = false;
        
        public CookingStep GetCookingStep() => _cookingStep;
    }
}