using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    [TextArea(5, 15)]
    public string[] sentences;
}
