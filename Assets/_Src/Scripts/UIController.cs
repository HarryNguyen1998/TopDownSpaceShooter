using UnityEngine;
using UnityEngine.UI;
using Utils;

public class UIController : MonoBehaviour
{
    [SerializeField] SettingsMenu _settingsMenu;
    [SerializeField] Button _openSettingsBtn;

    public void OpenSettingsMenu()
    {
        this.LogWarning("Launching", "Nuke");
        _settingsMenu.Open();
    }

}
