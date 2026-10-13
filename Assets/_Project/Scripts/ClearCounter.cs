using _Project.Scripts;
using JetBrains.Annotations;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IInteractable
{

    [SerializeField] private GameObject attachmentPoint;
    
    public void Interact()
    {
        
    }

    public bool IsAvailable()
    {
        return attachmentPoint.transform.childCount > 0;
    }

    [CanBeNull]
    public GameObject GetObject()
    {
        if(IsAvailable()) return null;
        return attachmentPoint.transform.GetChild(0).gameObject;
    }

    public void AddObject(GameObject obj)
    {
        if(!IsAvailable()) return;
        obj.transform.SetParent(attachmentPoint.transform);
    }
}
