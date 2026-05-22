using System.Collections;
using TMPro;
using UnityEngine;

public class TypeEffect : MonoBehaviour
{
    public TMP_Text textComponent;

    [TextArea]
    public string fullText;

    public float typingSpeed = 0.05f;

    void Start()
    {
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        textComponent.text = "";

        foreach (char letter in fullText)
        {
            textComponent.text += letter;

            yield return new WaitForSeconds(
                typingSpeed
            );
        }
    }
}