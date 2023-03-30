using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public GlobalInputController GlobalInputController;

    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;

    Resolution[] resolutions;
    /*
    List<string> keys = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "LeftShift", "RightShift", "Escape", "Mouse0", "Mouse1", "Tilde", "RightAlt", "LeftAlt" };
    */

    public InputField forward;
    public InputField right;
    public InputField left;
    public InputField back;
    public InputField speedUp;
    public InputField pause;

    private void Start()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>(0);
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        int count = 0;
        foreach (Resolution resolution in resolutions)
        {
            string option = resolution.width + "x" + resolution.height + " " + resolution.refreshRate + "Hz";
            options.Add(option);
            if (resolution.width == Screen.currentResolution.width && resolution.height == Screen.currentResolution.height)
                currentResolutionIndex = count;

            count++;
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
    }

/*    void KeyDown()
    {
        // 1) проверка что такую клавишу можно назначить, если нельзя, то return
        foreach (string key in keys)
        {
            if (Input.GetKeyDown(key))
            {
                print("Was pressed is " + key);
            }
        }
    }*/
    public void SetFullscreen(bool fullcreen)
    {
        Screen.fullScreen = fullcreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void ExitSettings()
    {
        SceneManager.LoadScene("Game");
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualitySettingPreference", qualityDropdown.value);
        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
        PlayerPrefs.SetInt("FullscreenPreference", System.Convert.ToInt32(Screen.fullScreen));
    }

    public void LoadSettings(int currentResolutionIndex)
    {
        qualityDropdown.value = PlayerPrefs.HasKey("QualitySettingPreference") ? PlayerPrefs.GetInt("QualitySettingPreference") : 3;
        resolutionDropdown.value = PlayerPrefs.HasKey("ResolutionPreference") ? PlayerPrefs.GetInt("ResolutionPreference") : currentResolutionIndex;
        Screen.fullScreen = PlayerPrefs.HasKey("FullscreenPreference") ? System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference")) : true;
    }
}
