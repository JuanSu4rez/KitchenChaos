using _Project.Scripts;
using UnityEngine;

public class RubbishCounter : BaseCounter
{
    public override void Interact(Player interactor)
    {
        if(!interactor.HasAnObject())
            return;
        
        if (interactor.GetKitchenObject() is Ingredient ingredient)
        {
            ingredient.DestroySelf();
        }
        
        if(interactor.GetKitchenObject() is CookWare cookware)
        {
            if(cookware.GetKitchenObject() is Ingredient ingredientInCookware)
            {
                ingredientInCookware.DestroySelf();
            }
        }
    }
}
