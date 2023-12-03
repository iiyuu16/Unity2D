using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    private void Start()
    {
        // Ensure the slider is initialized properly
        if (slider != null)
        {
            slider.value = 1f; // Set initial value to full health
        }
    }

    public void UpdateStatusBar(float currentValue, float maxValue)
    {
        // Update the slider value based on the current and max values
        if (slider != null)
        {
            slider.value = Mathf.Clamp01(currentValue / maxValue);
        }
    }

    void Update()
    {
        // Make sure we have a target to follow
        if (target != null)
        {
            // Update the position of the health bar based on the target's position and the offset
            transform.position = target.position + offset;
        }
    }
}
