using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ThreeFadeToBlack : MonoBehaviour
{
    public Image fadeImage; // Reference to the UI Image that covers the screen
    public float fadeDuration = 1f; // Duration of the fade

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player touches the object
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color fadeColor = fadeImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeColor.a = Mathf.Clamp01(elapsedTime / fadeDuration); // Gradually increase alpha
            fadeImage.color = fadeColor;
            yield return null;
        }

        // Ensure the screen is completely black
        fadeColor.a = 1f;
        fadeImage.color = fadeColor;
    }
}
