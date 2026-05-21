using UnityEngine;
using TMPro;
using System.Collections;

public class IntroUI : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    public TMP_Text introText;

    public GameObject crosshair;

    public GameObject player;

    [TextArea]
    public string fullText;

    public float typingSpeed = 0.05f;

    void Start()
    {
        // Disable movement
        player.GetComponent<PlayerMovement>()
            .enabled = false;

        // Disable mouse look
        player.GetComponent<MouseLook>()
            .enabled = false;

        // Hide crosshair
        crosshair.SetActive(false);

        // Unlock cursor
        Cursor.lockState =
            CursorLockMode.None;

        Cursor.visible = true;

        StartCoroutine(ShowIntro());
    }

    IEnumerator ShowIntro()
    {
        // Start invisible
        canvasGroup.alpha = 0;

        // Fade In
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha +=
                Time.deltaTime * 2;

            yield return null;
        }

        // Clear text
        introText.text = "";

        // Typewriter effect
        foreach (char letter in fullText)
        {
            introText.text += letter;

            yield return new WaitForSeconds(
                typingSpeed
            );
        }

        // Wait
        yield return new WaitForSeconds(2f);

        // Fade Out
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -=
                Time.deltaTime * 2;

            yield return null;
        }

        // Enable movement
        player.GetComponent<PlayerMovement>()
            .enabled = true;

        // Enable mouse look
        player.GetComponent<MouseLook>()
            .enabled = true;

        // Show crosshair
        crosshair.SetActive(true);

        // Lock cursor again
        Cursor.lockState =
            CursorLockMode.Locked;

        Cursor.visible = false;

        // Disable intro
        gameObject.SetActive(false);
    }
}