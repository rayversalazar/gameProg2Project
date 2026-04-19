using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeScreen : MonoBehaviour
{
    [SerializeField] Image fadeImage;
    [SerializeField] float fadeSpeed = 2f;

    private void Start()
    {

        Color startColor = fadeImage.color;
        startColor.a = 0f;
        fadeImage.color = startColor;
    }

    public void Fade(float targetAlpha)
    {
        StartCoroutine(FadeRoutine(targetAlpha));
    }

    private IEnumerator FadeRoutine(float targetAlpha)
    {
        Color currentColor = fadeImage.color;

        while (!Mathf.Approximately(currentColor.a, targetAlpha))
        {
            currentColor.a = Mathf.MoveTowards(
                currentColor.a,
                targetAlpha,
                fadeSpeed * Time.deltaTime
            );

            fadeImage.color = currentColor;
            yield return null; // wait for next frame
        }
    }
    public void blackout()
    {
        Color getColor = fadeImage.color;
        getColor.a = 1f;
        fadeImage.color = getColor;
    }
}