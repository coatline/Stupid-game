using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : Singleton<DialogueManager>
{
    [SerializeField] Animator dialogueBoxAnimator;
    [SerializeField] TMP_Text dialogText;
    [SerializeField] TMP_Text nameText;
    int currentSentence;
    string[] sentences;

    bool isTalking;

    private void Update()
    {
        if (isTalking == false) return;

        if (Input.GetKeyDown(KeyCode.Space))
            DisplayNextSentence();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBoxAnimator.SetBool("IsOpen", true);

        isTalking = true;

        Cursor.lockState = CursorLockMode.None;

        nameText.text = $"{dialogue.Name}:";

        sentences = dialogue.Sentences;
        currentSentence = 0;

        //foreach (string sentence in dialogue.Sentences)
        //{
        //    sentences.Enqueue(sentence);
        //}

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (currentSentence == sentences.Length)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences[currentSentence];
        dialogText.text = sentence;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        currentSentence++;
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        isTalking = false;
        dialogueBoxAnimator.SetBool("IsOpen", false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
