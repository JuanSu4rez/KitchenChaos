using _Project.Scripts;
using UnityEngine;

public class RubbishCounter : BaseCounter
{
    public override void Interact(Player interactor)
    {
        if (interactor.HasAnObject())
        {
            interactor.GetKitchenObject().DestroySelf();
        }
    }
}
