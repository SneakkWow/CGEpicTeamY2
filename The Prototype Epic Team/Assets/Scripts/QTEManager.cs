using UnityEngine;
using UnityEngine.UI;

public class QTEManager : MonoBehaviour
{
    // Array of arrow keys
    private KeyCode[] arrowSequence = { KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.UpArrow };
    private int currentInputIndex = 0;

    // Image UI component for displaying arrow prompt
    public Image qtePromptImage;

    // Sprites for the different arrow keys
    public Sprite upArrowSprite;
    public Sprite downArrowSprite;
    public Sprite leftArrowSprite;
    public Sprite rightArrowSprite;

    // Event to trigger on QTE success
    public delegate void OnQTESuccess();
    public event OnQTESuccess QTESuccess;

    private bool isQTEActive = false;

    private void Start()
    {
        qtePromptImage.gameObject.SetActive(false); // Hide prompt initially
    }

    private void Update()
    {
        if (isQTEActive)
        {
            HandleQTE();
        }
    }

    public void StartQTE()
    {
        isQTEActive = true;
        currentInputIndex = 0;
        qtePromptImage.gameObject.SetActive(true); // Show prompt when QTE starts
        UpdateQTEUI();
    }

    private void HandleQTE()
    {
        if (Input.GetKeyDown(arrowSequence[currentInputIndex]))
        {
            currentInputIndex++;

            if (currentInputIndex >= arrowSequence.Length)
            {
                CompleteQTE();
            }
            else
            {
                UpdateQTEUI();
            }
        }
    }

    private void CompleteQTE()
    {
        isQTEActive = false;
        qtePromptImage.gameObject.SetActive(false); // Hide prompt when QTE completes
        Debug.Log("QTE Successful!");
        QTESuccess?.Invoke();
    }

    private void UpdateQTEUI()
    {
        // Update the prompt image based on the next arrow in the sequence
        switch (arrowSequence[currentInputIndex])
        {
            case KeyCode.UpArrow:
                qtePromptImage.sprite = upArrowSprite;
                break;
            case KeyCode.DownArrow:
                qtePromptImage.sprite = downArrowSprite;
                break;
            case KeyCode.LeftArrow:
                qtePromptImage.sprite = leftArrowSprite;
                break;
            case KeyCode.RightArrow:
                qtePromptImage.sprite = rightArrowSprite;
                break;
        }
    }

    public void StopQTE()
    {
        isQTEActive = false;
        qtePromptImage.gameObject.SetActive(false); // Hide prompt when QTE stops
        Debug.Log("QTE Stopped.");
    }
}
