using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class event_fade_in_out : MonoBehaviour
{
    public float fadeDuration = 1.0f;
    public float fadeDelay = 1.0f;

    public Image image;
    public TextMeshProUGUI textMesh;

    private bool fadingIn = true;

    void Start()
    {
        StartCoroutine(FadeInOut());
    }

    IEnumerator FadeInOut()
    {
        // Fade in
        float startTime = Time.time;
        while (Time.time < startTime + fadeDuration)
        {
            float normalizedTime = (Time.time - startTime) / fadeDuration;
            float alpha = Mathf.Lerp(0f, 1f, normalizedTime);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, alpha);
            yield return null;
        }
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
        textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 1f);

        // Hold
        yield return new WaitForSeconds(fadeDelay);

        // Fade out
        startTime = Time.time;
        while (Time.time < startTime + fadeDuration)
        {
            float normalizedTime = (Time.time - startTime) / fadeDuration;
            float alpha = Mathf.Lerp(1f, 0f, normalizedTime);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, alpha);
            yield return null;
        }
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0f);

        gameObject.SetActive(false);
    }
}
