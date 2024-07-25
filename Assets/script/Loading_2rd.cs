using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading_2rd : MonoBehaviour
{
    public RectTransform imageTransform;
    public string sceneName;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
        op.allowSceneActivation = false;
        float timer = 0.0f;
        float startPosition = -375f;
        float endPosition = 375f;
        float progress = 0f;

        while (!op.isDone)
        {
            yield return null;
            timer += Time.deltaTime;

            if (op.progress < 0.9f)
            {
                progress = Mathf.Lerp(progress, op.progress, timer);
            }
            else
            {
                progress = Mathf.Lerp(progress, 1f, timer);
            }

            float targetPosition = Mathf.Lerp(startPosition, endPosition, progress);
            imageTransform.anchoredPosition = new Vector2(targetPosition, imageTransform.anchoredPosition.y);

            if (progress >= 0.99f)
            {
                op.allowSceneActivation = true;
                yield break;
            }
        }
    }
}
