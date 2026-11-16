using _Project.Scripts;
using UnityEngine;
using UnityEngine.UI;

// Displays the progress of the IHasProgress it belongs to. Place it inside the prefab that owns
// the progress (e.g. the ingredient), so the bar travels with it from counter to hand to stove.
public class ProgressBarUI : MonoBehaviour
{
    [Tooltip("Optional. If empty, the nearest IHasProgress in the parents is used.")]
    [SerializeField] private GameObject progressSourceObject;
    [SerializeField] private Image barImage;

    private IHasProgress _progressSource;

    private void Start()
    {
        _progressSource = progressSourceObject != null
            ? progressSourceObject.GetComponent<IHasProgress>()
            : GetComponentInParent<IHasProgress>();

        if (_progressSource == null)
        {
            Debug.LogWarning($"{nameof(ProgressBarUI)} on '{name}' has no IHasProgress source", this);
            gameObject.SetActive(false);
            return;
        }

        _progressSource.OnProgressChanged += OnProgressChanged;
        UpdateBar(_progressSource.ProgressNormalized);
    }

    private void OnDestroy()
    {
        if (_progressSource != null)
            _progressSource.OnProgressChanged -= OnProgressChanged;
    }

    private void OnProgressChanged(object sender, ProgressChangedEventArgs e) => UpdateBar(e.progressNormalized);

    private void UpdateBar(float progressNormalized)
    {
        barImage.fillAmount = progressNormalized;
        gameObject.SetActive(progressNormalized > 0f && progressNormalized < 1f);
    }
}
