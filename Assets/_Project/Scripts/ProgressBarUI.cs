using System;
using System.Net.Mime;
using _Project.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private Interactable _interactable;
    [SerializeField] private Image barImage;

    private void Start()
    {
        _interactable.GetCookingStep().OnProgressChanged += OnProgressChanged;
        barImage.fillAmount = 0;
        Hide();
    }

    private void OnDestroy()
    {
        _interactable.GetCookingStep().OnProgressChanged -= OnProgressChanged;
    }

    private void OnProgressChanged(object sender, CookingStep.OnProgressChangedEventArgs e)
    {
        barImage.fillAmount = e.progressNormalized;
        if (e.progressNormalized <= 0f || e.progressNormalized >= 1f)
        {
            Hide();
            return;
        }
        
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
