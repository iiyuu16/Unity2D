using UnityEngine;
using TMPro;

public class HPDisplay : MonoBehaviour
{
    public TextMeshProUGUI hpText;

    // Reference to the script containing player HP information
    public TopDownCharacterController player;

    void Start()
    {
        // Initialize references, you might want to set them through the Unity Editor
        if (hpText == null)
            hpText = GetComponent<TextMeshProUGUI>();

        if (player == null)
            player = GetComponent<TopDownCharacterController>();
    }

    void Update()
    {
        // Update the TextMeshPro Text with current and max HP
        if (player != null)
        {
            hpText.text ="Life" +
                " "+ player.currentHP + "/" + player.maxHP;
        }
        else
        {
            Debug.LogError("Player script not found!");
        }
    }
}
