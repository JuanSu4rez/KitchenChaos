using _Project.Scripts;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private BaseCounter selectedCounter;
    [SerializeField] private GameObject[] visualGameObjects;

    private void Start()
    {
        Player.Instance.OnInteractableFaced += Player_On;
    }

    private void OnDestroy()
    {
        if (Player.Instance != null)
            Player.Instance.OnInteractableFaced -= Player_On;
    }

    private void Player_On(object sender, Player.OnSelectedInteractableChangedEventArgs e)
    {
        if (e.SelectedInteractable is BaseCounter counter && counter == selectedCounter)
        {
            Show();
            return;
        }
        Hide();
    }

    private void Show() => SetVisualsActive(true);
    
    private void Hide() => SetVisualsActive(false);

    private void SetVisualsActive(bool active)
    {
        foreach (var visualGameObject in visualGameObjects)
            visualGameObject.SetActive(active);
    }
}
