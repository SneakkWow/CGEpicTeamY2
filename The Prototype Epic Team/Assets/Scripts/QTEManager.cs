using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QTEManager : MonoBehaviour
{
    // Array of arrow keys
    public KeyCode[] possibleArrows = { KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D};


    private KeyCode[] arrowSequence = new KeyCode[5];
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

    public FirstPersonController playerMovement;
    public QTETrigger triggerCollider;
    public DoorMovement doorMovement;

    public Color correctColor = Color.green; // Color for correct input
    public Color incorrectColor = Color.red;  // Color for incorrect input
    public Color defaultColor = Color.white;  // Default arrow color

    public float colorFlashDuration = 0.5f;

    private void Start()
    {
        qtePromptImage.gameObject.SetActive(false); // Hide prompt initially

        if (doorMovement == null)
        {
            doorMovement = GetComponent<DoorMovement>();
        }
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

        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }

        GenerateRandomArrowSequence();

        isQTEActive = true;
        currentInputIndex = 0;
        qtePromptImage.gameObject.SetActive(true); // Show prompt when QTE starts
        qtePromptImage.color = defaultColor;
        UpdateQTEUI();
    }

    private void HandleQTE()
    {
        if (Input.anyKeyDown)
        {
            if (CheckCorrectKey(arrowSequence[currentInputIndex]))
            {
                // Correct input: Flash green and move to the next input after a delay
                StartCoroutine(FlashColor(correctColor));

                currentInputIndex++;

                if (currentInputIndex >= arrowSequence.Length)
                {
                    CompleteQTE(); // QTE completed
                }
                else
                {
                    // Wait until the color flash ends before showing the next arrow
                    StartCoroutine(WaitForNextArrow());
                }
            }
            else if (CheckAnyArrowKey())
            {
                // Incorrect input: Flash red
                StartCoroutine(FlashColor(incorrectColor));
            }
        }
    }

    private bool CheckCorrectKey(KeyCode expectedKey)
    {
        switch (expectedKey)
        {
            case KeyCode.UpArrow:
                return Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W);
            case KeyCode.DownArrow:
                return Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S);
            case KeyCode.LeftArrow:
                return Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A);
            case KeyCode.RightArrow:
                return Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D);
            default:
                return false;
        }
    }

    private bool CheckAnyArrowKey()
    {
        return Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) ||
               Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) ||
               Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) ||
               Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D);
    }

    private IEnumerator FlashColor(Color flashColor)
    {
        // Flash the color for a brief moment
        qtePromptImage.color = flashColor;
        yield return new WaitForSeconds(colorFlashDuration);
        qtePromptImage.color = defaultColor; // Reset to default color after flash
    }

    private IEnumerator WaitForNextArrow()
    {
        // Wait for the flash to finish before showing the next arrow
        yield return new WaitForSeconds(colorFlashDuration);
        UpdateQTEUI();
    }

    private void CompleteQTE()
    {
        isQTEActive = false;
        qtePromptImage.gameObject.SetActive(false); // Hide prompt when QTE completes
        

        if (playerMovement != null)
        {
            playerMovement.enabled = true;
        }

        if(triggerCollider != null)
        {
            triggerCollider.gameObject.SetActive(false);
        }

        if (doorMovement != null)
        {
            doorMovement.StartSliding();
        }

        Debug.Log("QTE Successful!");
        QTESuccess?.Invoke();
    }

    private void UpdateQTEUI()
    {

        qtePromptImage.color = defaultColor;

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

    private void GenerateRandomArrowSequence()
    {
        for (int i = 0; i < arrowSequence.Length; i++)
        {
            arrowSequence[i] = possibleArrows[Random.Range(0, possibleArrows.Length)];
        }
    }

    public void StopQTE()
    {
        isQTEActive = false;
        qtePromptImage.gameObject.SetActive(false); // Hide prompt when QTE stops
        

        if (playerMovement != null)
        {
            playerMovement.enabled = true;
        }

        if (triggerCollider != null)
        {
            triggerCollider.gameObject.SetActive(false);
        }

        Debug.Log("QTE Stopped.");
    }
}
