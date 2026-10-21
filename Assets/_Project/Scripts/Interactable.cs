using UnityEngine;

namespace _Project.Scripts
{
    public class Interactable : MonoBehaviour
    {
        public virtual void Interact(Player interactor)
        {
            Debug.Log("Interactable - Interact - default implementation"); 
        }
    }
}