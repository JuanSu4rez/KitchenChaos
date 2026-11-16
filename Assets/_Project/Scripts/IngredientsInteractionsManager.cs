using UnityEngine;
using UnityEngine.Serialization;

public class IngredientsInteractionsManager : MonoBehaviour
{
    [FormerlySerializedAs("interactionsAllowed")] [SerializeField]
    protected StepPreparationAllowed stepPreparationAllowed;
    
    public static IngredientsInteractionsManager Instance { get; private set; }


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("There is more than one IngredientsInteractionsManager instance");
        }
            
        Instance = this;
    }

    public StepPreparationAllowed GetInteractionsAllowed() => stepPreparationAllowed;

}
