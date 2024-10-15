using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LogoTransition : MonoBehaviour
{
    public CanvasGroup logo1;
    public CanvasGroup logo2;

    public float fadeDuration = 1f; 
    public float displayDuration = 2f;

    void Start()
    {
        logo1.alpha = 0;
        logo2.alpha = 0;
        logo2.gameObject.SetActive(false);

        StartCoroutine(PlayLogoSequence());
    }

    IEnumerator PlayLogoSequence()
    {
        yield return StartCoroutine(FadeIn(logo1));
        yield return new WaitForSeconds(displayDuration);

        yield return StartCoroutine(FadeOut(logo1));

        logo1.gameObject.SetActive(false);
        logo2.gameObject.SetActive(true);

        yield return StartCoroutine(FadeIn(logo2));
        yield return new WaitForSeconds(displayDuration);

        yield return StartCoroutine(FadeOut(logo2));

        SceneManager.LoadScene("Dialog");
    }

    IEnumerator FadeIn(CanvasGroup canvasGroup)
    {
        float startTime = Time.time;

        while (Time.time < startTime + fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(0, 1, (Time.time - startTime) / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 1;
    }

    IEnumerator FadeOut(CanvasGroup canvasGroup)
    {
        float startTime = Time.time;

        while (Time.time < startTime + fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(1, 0, (Time.time - startTime) / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 0;
    }
}
