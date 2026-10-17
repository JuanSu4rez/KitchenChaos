using System;
using _Project.Scripts;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private ClearCounter selectedCounter;
    [SerializeField] private GameObject visualGameObject;

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

    private void Show()
    {
        visualGameObject.SetActive(true);
    }
    
    private void Hide()
    {
        visualGameObject.SetActive(false);
    }
}
