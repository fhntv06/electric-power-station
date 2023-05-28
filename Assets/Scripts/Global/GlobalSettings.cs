using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class GlobalSettings : MonoBehaviour
{
    // public GlobalInputController GlobalInputController;

    public int defaultQualityIndex = 2;
    public int defaultResolutionIndex;
    public int defaultFieldOfViewIndex;

    public Resolution[] resolutions;
    public List<int> fieldOfView = new List<int>() { 40, 65, 100 };

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

    public void SetFullscreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
        PlayerPrefs.SetInt("FullscreenPreference", System.Convert.ToInt32(fullscreen));
    }

    public void SetResolution(int resolutionIndex, bool fullscreen)
    {
        Screen.SetResolution(resolutions[resolutionIndex].width, resolutions[resolutionIndex].height, fullscreen);
        PlayerPrefs.SetInt("ResolutionPreference", resolutionIndex);

    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("QualitySettingPreference", qualityIndex);
    }

    public void SetFieldOfView(int firldOfViewIndex)
    {
        PlayerPrefs.SetInt("FieldOfView", firldOfViewIndex);
    }

    public void ReLoadGlobalSettings()
    {
        defaultQualityIndex = PlayerPrefs.HasKey("QualitySettingPreference") ? PlayerPrefs.GetInt("QualitySettingPreference") : 2;
        defaultResolutionIndex = PlayerPrefs.HasKey("ResolutionPreference") ? PlayerPrefs.GetInt("ResolutionPreference") : 4;
        defaultFieldOfViewIndex = PlayerPrefs.HasKey("FieldOfView") ? PlayerPrefs.GetInt("FieldOfView") : 1;
        Screen.fullScreen = PlayerPrefs.HasKey("FullscreenPreference") ? System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference")) : true;
    }
}
