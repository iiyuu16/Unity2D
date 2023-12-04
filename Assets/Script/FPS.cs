using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    public TMP_Text fpsText;
    public TMP_Dropdown fpsDropdown;

    private const string FpsPlayerPrefsKey = "SelectedFPS";

    void Start()
    {
        fpsDropdown.onValueChanged.AddListener(OnFpsDropdownValueChanged);

        // Load the selected FPS from PlayerPrefs
        int savedFps = PlayerPrefs.GetInt(FpsPlayerPrefsKey, 60); // Default to 60 FPS if not set
        fpsDropdown.value = GetDropdownIndex(savedFps);

        // Apply the loaded FPS
        ChangeFrameRate(savedFps);

        UpdateFpsText();
    }

    void OnFpsDropdownValueChanged(int value)
    {
        UpdateFpsText();

        int selectedFps = GetSelectedFps();

        // Save the selected FPS to PlayerPrefs
        PlayerPrefs.SetInt(FpsPlayerPrefsKey, selectedFps);
        PlayerPrefs.Save();

        ChangeFrameRate(selectedFps);
    }

    void UpdateFpsText()
    {
        int selectedFps = GetSelectedFps();

        fpsText.text = $"FPS: {selectedFps}";
    }

    int GetSelectedFps()
    {
        return int.Parse(fpsDropdown.options[fpsDropdown.value].text);
    }

    int GetDropdownIndex(int fps)
    {
        switch (fps)
        {
            case 30: return 0;
            case 60: return 1;
            case 120: return 2;
            default: return 1; // Default to 60 FPS
        }
    }

    public void ChangeFrameRate(int selection)
    {
        switch (selection)
        {
            case 0:
                Application.targetFrameRate = 30; break;
            case 1:
                Application.targetFrameRate = 60; break;
            case 2:
                Application.targetFrameRate = 120; break;
        }
    }
}
