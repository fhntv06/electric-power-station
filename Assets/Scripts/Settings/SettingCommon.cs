using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingCommon : MonoBehaviour
{
    public SettingActions settingsActions;
    // public GlobalInputController GlobalInputController;

    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;
    public Dropdown fieldOfViewDropdown;

    public int currentQualityIndex = 0;
    public int currentResolutionIndex = 0;
    public int currentFieldOfViewIndex = 0;

    Resolution[] resolutions;
    List<int> fieldOfView = new List<int>() { 40, 65, 100 };

    public Camera playerCamera;

    /* enabled keys for control character
    List<string> keys = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "LeftShift", "RightShift", "Escape", "Mouse0", "Mouse1", "Tilde", "RightAlt", "LeftAlt" };
    

    public InputField forward;
    public InputField right;
    public InputField left;
    public InputField back;
    public InputField speedUp;
    public InputField pause;
    */
    private void Start()
    {
        LoadResolutionDropdown();
        settingsActions.LoadSettings();
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

    void LoadResolutionDropdown()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>(0);
        resolutions = Screen.resolutions;

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
    }
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
    public void SetFieldOfView(int indexFieldOfView)
    {
        playerCamera.fieldOfView = fieldOfView[indexFieldOfView];
    }
}
