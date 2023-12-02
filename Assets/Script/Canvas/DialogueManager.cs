using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public TMP_Text actorName;
    public TMP_Text messageText;
    public RectTransform bgBox;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;

    private Coroutine textAnimationCoroutine;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;

        Debug.Log("Started Convo! Loaded messages: " + messages.Length);
        DisplayMessages();
        bgBox.LeanScale(Vector3.one, 0.1f);
    }

    void DisplayMessages()
    {
        if (textAnimationCoroutine != null)
        {
            StopCoroutine(textAnimationCoroutine);
        }

        Message messageToDisplay = currentMessages[activeMessage];
        actorName.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorID];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;

        textAnimationCoroutine = StartCoroutine(AnimateTextReveal(messageToDisplay.message));
    }

    IEnumerator AnimateTextReveal(string text)
    {
        messageText.text = "";

        foreach (char letter in text)
        {
            messageText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessages();
        }
        else
        {
            Debug.Log("End of Convo");
            bgBox.LeanScale(Vector3.zero, 0.1f).setEaseInOutExpo();
        }
    }

    void Start()
    {
        bgBox.transform.localScale = Vector3.zero;
    }

    void Update()
    {
        if (((Input.GetKeyDown(KeyCode.Mouse0)) && isActive == true))
        {
            NextMessage();
        }
    }
}