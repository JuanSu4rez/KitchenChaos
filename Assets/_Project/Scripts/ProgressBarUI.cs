using System;
using _Project.Scripts;
using UnityEngine;
using UnityEngine.UI;

// A counter bar follows its held ingredient; an ingredient bar follows its own preparation.
public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private GameObject progressSourceObject;
    [SerializeField] private Image barImage;
    private IHasKitchenTask _progressSource;
    
    private void Start()
    {   
        _progressSource = transform.parent.GetComponent<IHasKitchenTask>();
        _progressSource.KitchenTask.OnProgressChanged += OnProgressChanged;
        UpdateBar(_progressSource.KitchenTask.ProgressNormalized);
    }

    private void OnDestroy()
    {
        if (_progressSource != null)
        {
            _progressSource.KitchenTask.OnProgressChanged -= OnProgressChanged;
        }
    }

    private void OnProgressChanged(object sender, KitchenTask.ProgressChangedEventArgs e) => UpdateBar(e.progressNormalized);

    private void UpdateBar(float progressNormalized)
    {   
        barImage.fillAmount = progressNormalized;
        gameObject.SetActive(progressNormalized > 0f && progressNormalized < 1f);
    }
}
