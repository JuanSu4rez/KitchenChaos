using UnityEngine;

public class IngredientsInteractionsManager : MonoBehaviour
{
    [SerializeField]
    protected InteractionsAllowed interactionsAllowed;
    
    public static IngredientsInteractionsManager Instance { get; private set; }


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("There is more than one IngredientsInteractionsManager instance");
        }
            
        Instance = this;
    }

    public InteractionsAllowed GetInteractionsAllowed() => interactionsAllowed;

}
