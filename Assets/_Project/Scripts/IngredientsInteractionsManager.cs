using UnityEngine;
using UnityEngine.Serialization;

public class IngredientsInteractionsManager : MonoBehaviour
{
    [FormerlySerializedAs("interactionsAllowed")] [SerializeField]
    private StepPreparationAllowed stepPreparationAllowed;
    
    internal static IngredientsInteractionsManager Instance { get; private set; }


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("There is more than one IngredientsInteractionsManager instance");
        }
            
        Instance = this;
    }

    internal StepPreparationAllowed GetInteractionsAllowed() => stepPreparationAllowed;

}
