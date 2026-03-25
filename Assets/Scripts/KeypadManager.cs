using UnityEngine;
using TMPro;

public class KeypadManager : MonoBehaviour
{
    [Header("Settings")]
    public string secretCode = "123";
    public int maxDigits = 3;

    [Header("References")]
    public TextMeshPro displayText;
    public DoorController door;
    public AudioSource audioSource;
    public AudioClip buttonClickSFX;
    public AudioClip errorSFX;
    public AudioClip successSFX;

    private string currentInput = "";

    void Awake()
    {
        UpdateDisplay();
    }

    public void PressDigit(string digit)
    {
        if (currentInput.Length >= maxDigits) return;

        PlaySound(buttonClickSFX);
        currentInput += digit;
        UpdateDisplay();

        if (currentInput.Length == maxDigits)
            Invoke(nameof(CheckCode), 0.3f);
    }

    public void PressClear()
    {
        currentInput = "";
        PlaySound(buttonClickSFX);
        UpdateDisplay();
    }

    private void CheckCode()
    {
        if (currentInput == secretCode)
        {
            PlaySound(successSFX);
            displayText.text = "OPEN";
            displayText.color = Color.green;
            door.OpenDoor();
        }
        else
        {
            PlaySound(errorSFX);
            displayText.text = "WRONG";
            displayText.color = Color.red;
            Invoke(nameof(ResetDisplay), 1.2f);
        }
    }

    private void ResetDisplay()
    {
        currentInput = "";
        displayText.color = Color.white;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        displayText.text = currentInput.PadRight(maxDigits, '_');
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
            audioSource.PlayOneShot(clip);
    }
}