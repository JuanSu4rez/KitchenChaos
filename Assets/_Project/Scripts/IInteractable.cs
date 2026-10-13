using UnityEngine;

namespace _Project.Scripts
{
    public interface IInteractable
    {
        public bool IsAvailable();
        
        //TODO - This is actually a collection, not a single object,
        // an Stack maybe?, a proper structure should be used
        public GameObject GetObject();

        public void AddObject(GameObject obj);
    }
}