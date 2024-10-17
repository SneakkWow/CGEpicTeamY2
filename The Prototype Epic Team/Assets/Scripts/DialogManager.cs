using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;


public class DialogManager : MonoBehaviour
{
    public TMP_Text textbox;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject dialogPanel;
    public GameObject skipButton;

    private void OnEnable()
    {
        index = 0;
        continueButton.SetActive(false);
        dialogPanel.SetActive(true);
        StartCoroutine(Type());
        Time.timeScale = 0;
        skipButton.SetActive(true);

    }

    IEnumerator Type()
    {
        textbox.text = "";
        foreach (char letter in sentences[index])
        {
            textbox.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        continueButton.SetActive(true);
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textbox.text = "";
            StartCoroutine(Type());
        }
        else
        {
            EndDialogue();
        }
    }

    public void SkipDialogue()
    {
        EndDialogue();
    }

    private void EndDialogue()
    {
        textbox.text = "";
        dialogPanel.SetActive(false);
        continueButton.SetActive(false);
        skipButton.SetActive(false);
        Time.timeScale = 1;

    }
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    ////// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && continueButton.activeSelf) 
        {
        NextSentence();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            SkipDialogue();
        }
    }
}
