using System;
using System.Linq;
using _Project.Scripts;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private Interactable selectedCounter;
    [SerializeField] private GameObject[] visualGameObjects;

    private void Start()
    {
        Player.Instance.OnInteractableFaced += Player_On;
        Hide();
    }

    private void Player_On(object sender, Player.OnSelectedInteractableChangedEventArgs e)
    {
        if (e.SelectedInteractable == selectedCounter)
        {
            Show();
            return;
        }
        Hide();
    }

    private void Show() => visualGameObjects.ToList().ForEach(visualGameObject => visualGameObject.SetActive(true));
    
    private void Hide() => visualGameObjects.ToList().ForEach(visualGameObject => visualGameObject.SetActive(false));
}
