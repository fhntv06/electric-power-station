using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingActions : MonoBehaviour
{
    public GlobalSettings GlobalSettings;

    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;
    public Dropdown fieldOfViewDropdown;
    public Toggle fullscreen;

    void Start()
    {
        FormingListSettings();
    }

    void FormingListSettings() {
        FormingResolutionDropdown();
        FormingValueSettings();
    }

    void FormingResolutionDropdown()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>(0);
        GlobalSettings.resolutions = Screen.resolutions;

        int count = 0;
        foreach (Resolution resolution in GlobalSettings.resolutions)
        {
            string option = resolution.width + "x" + resolution.height + " " + resolution.refreshRate + "Hz";
            options.Add(option);
            if (resolution.width == Screen.currentResolution.width && resolution.height == Screen.currentResolution.height)
                GlobalSettings.defaultResolutionIndex = count;

            count++;
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
    }

    public void SaveSettings()
    {
        GlobalSettings.SetQuality(qualityDropdown.value);
        GlobalSettings.SetResolution(resolutionDropdown.value, fullscreen.isOn);
        GlobalSettings.SetFullscreen(fullscreen.isOn);
        GlobalSettings.SetFieldOfView(fieldOfViewDropdown.value);

        print("QualitySettingPreference " + PlayerPrefs.GetInt("QualitySettingPreference"));
        print("ResolutionPreference " + PlayerPrefs.GetInt("ResolutionPreference"));
        print("FieldOfView " + PlayerPrefs.GetInt("FieldOfView"));
        print("FullscreenPreference " + PlayerPrefs.GetInt("FullscreenPreference"));
    }
    public void FormingValueSettings()
    {
        qualityDropdown.value = PlayerPrefs.HasKey("QualitySettingPreference") ? PlayerPrefs.GetInt("QualitySettingPreference") : GlobalSettings.defaultQualityIndex;
        resolutionDropdown.value = PlayerPrefs.HasKey("ResolutionPreference") ? PlayerPrefs.GetInt("ResolutionPreference") : GlobalSettings.defaultResolutionIndex;
        fieldOfViewDropdown.value = PlayerPrefs.HasKey("FieldOfView") ? PlayerPrefs.GetInt("FieldOfView") : GlobalSettings.defaultFieldOfViewIndex;
        fullscreen.isOn = PlayerPrefs.HasKey("FullscreenPreference") ? System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference")) : true;
    }

    public void LoadSettingsForPlayer()
    {
        int indexFieldOfView = PlayerPrefs.HasKey("FieldOfView") ? PlayerPrefs.GetInt("FieldOfView") : GlobalSettings.defaultFieldOfViewIndex;

        GlobalSettings.playerCamera.fieldOfView = GlobalSettings.fieldOfView[indexFieldOfView];
    }
}
