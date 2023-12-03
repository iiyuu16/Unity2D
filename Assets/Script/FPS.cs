using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    public TMP_Text fpsText;
    public TMP_Dropdown fpsDropdown;

    void Start()
    {   
        fpsDropdown.onValueChanged.AddListener(OnFpsDropdownValueChanged);

        UpdateFpsText();
    }

    void OnFpsDropdownValueChanged(int value)
    {
        UpdateFpsText();

        ChangeFrameRate(value);
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
