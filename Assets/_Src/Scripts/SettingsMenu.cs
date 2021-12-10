using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Utils;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] Transform _settingsModal;
    [SerializeField] Button _closeBtn;

    public void Start()
    {
        _settingsModal.localScale = Vector2.zero;
        gameObject.SetActive(false);
    }

    public void Open()
    {
        gameObject.SetActive(true);
        _settingsModal.DOScale(1.0f, 0.5f);
        _closeBtn.interactable = true;
        this.LogSuccess("Huraah it's a success");
    }
    public void Close()
    {
        _closeBtn.interactable = false;
        _settingsModal.DOScale(Vector2.zero, 0.8f).SetEase(Ease.InBack).OnComplete(() => {
            gameObject.SetActive(false);
        });
        this.LogError("Just", "a", "test");
    }

}
