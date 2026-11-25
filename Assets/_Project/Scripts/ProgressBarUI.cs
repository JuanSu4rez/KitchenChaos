using System;
using _Project.Scripts;
using UnityEngine;
using UnityEngine.UI;

// A counter bar follows its held ingredient; an ingredient bar follows its own preparation.
public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private GameObject progressSourceObject;
    [SerializeField] private Image barImage;
    private CookingTask _progressSource;
    
    private void Start()
    {
        var _progressSource = progressSourceObject.GetComponent<FoodProcessingObject>().GetCookingTask();
        _progressSource.OnProgressChanged += OnProgressChanged;
        UpdateBar(_progressSource.ProgressNormalized);
    }

    private void OnDestroy()
    {
        if (_progressSource != null)
        {
            _progressSource.OnProgressChanged -= OnProgressChanged;
        }
    }

    private void OnProgressChanged(object sender, CookingTask.ProgressChangedEventArgs e) => UpdateBar(e.progressNormalized);

    private void UpdateBar(float progressNormalized)
    {   
        barImage.fillAmount = progressNormalized;
        gameObject.SetActive(progressNormalized > 0f && progressNormalized < 1f);
    }
}
