using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class QTEManager : MonoBehaviour
{
    // Define the sequence of arrow keys for the QTE
    private KeyCode[] arrowSequence = { KeyCode.UpArrow, KeyCode.RightArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.UpArrow };
    private int currentInputIndex = 0;

    // Track if the QTE is active
    private bool isQTEActive = false;

    // Reference to the UI Text element
    public Image qtePromptImage;

    // Event or method to call when QTE is successful
    public delegate void OnQTESuccess();
    public event OnQTESuccess QTESuccess;

    private void Start()
    {
        // Hide the prompt initially
        qtePromptImage.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isQTEActive)
        {
            HandleQTE();
        }
    }

    // Start the QTE
    public void StartQTE()
    {
        isQTEActive = true;
        currentInputIndex = 0;

        // Show the first prompt
        qtePromptImage.gameObject.SetActive(true);
        UpdateQTEUI();
    }

    private void HandleQTE()
    {
        // Check if the player is pressing the correct arrow key
        if (Input.GetKeyDown(arrowSequence[currentInputIndex]))
        {
            currentInputIndex++;

            // Check if the sequence is completed
            if (currentInputIndex >= arrowSequence.Length)
            {
                CompleteQTE();
            }
            else
            {
                // Update the UI for the next arrow key in the sequence
                UpdateQTEUI();
            }
        }
    }

    private void CompleteQTE()
    {
        isQTEActive = false;
        Debug.Log("QTE Successful!");

        // Hide the prompt when the QTE is complete
        qtePromptImage.gameObject.SetActive(false);

        // Call the success event
        QTESuccess?.Invoke();
    }

    public Sprite upArrowSprite;
    public Sprite downArrowSprite;
    public Sprite leftArrowSprite;
    public Sprite rightArrowSprite;

    private void UpdateQTEUI()
    {
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
        Debug.Log("QTE Stopped.");
        qtePromptImage.gameObject.SetActive(false);
    }
}
