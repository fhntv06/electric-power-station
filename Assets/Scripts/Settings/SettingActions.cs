using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingActions : MonoBehaviour
{
    public SettingCommon settingCommon;

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualitySettingPreference", settingCommon.qualityDropdown.value);
        PlayerPrefs.SetInt("ResolutionPreference", settingCommon.resolutionDropdown.value);
        PlayerPrefs.SetInt("FieldOfView", settingCommon.fieldOfViewDropdown.value);
        PlayerPrefs.SetInt("FullscreenPreference", System.Convert.ToInt32(Screen.fullScreen));
    }
    public void LoadSettings()
    {
        settingCommon.qualityDropdown.value = PlayerPrefs.HasKey("QualitySettingPreference") ? PlayerPrefs.GetInt("QualitySettingPreference") : settingCommon.currentQualityIndex;
        settingCommon.resolutionDropdown.value = PlayerPrefs.HasKey("ResolutionPreference") ? PlayerPrefs.GetInt("ResolutionPreference") : settingCommon.currentResolutionIndex;
        settingCommon.fieldOfViewDropdown.value = PlayerPrefs.HasKey("FieldOfView") ? PlayerPrefs.GetInt("FieldOfView") : settingCommon.currentFieldOfViewIndex;
        Screen.fullScreen = PlayerPrefs.HasKey("FullscreenPreference") ? System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference")) : true;

    }
}
