using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;

    private bool isTriggerEnabled = true;
    public new Collider2D collider;
    public TopDownCharacterController player;

    public void Awake()
    {
        collider = GetComponent<Collider2D>();
        player = FindObjectOfType<TopDownCharacterController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartDialogue();
        }
    }

    public void StartDialogue()
    {
        if (!isTriggerEnabled)
        {
            Debug.Log("Dialogue trigger is disabled.");
            return;
        }

        Button dialogueButton = GetComponentInChildren<Button>();
        if (dialogueButton != null)
        {
            dialogueButton.interactable = false;
            gameObject.SetActive(false);
        }

        FindObjectOfType<DialogueManager>().OpenDialogue(messages, actors);
    }
}

[System.Serializable]
public class Message
{
    public int actorID;
    public string message;
}

[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}
