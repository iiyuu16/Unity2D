using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    private int fps = 30;

    // Start is called before the first frame update
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = fps;
    }

    // Update is called once per frame
    public void ChangeFrameRate(int selection)
    {
        switch (selection)
        {
            case 0:
                Application.targetFrameRate = fps; break;
            case 1:
                Application.targetFrameRate = 60; break;
            case 2:
                Application.targetFrameRate = 120; break;
        }
    }
}