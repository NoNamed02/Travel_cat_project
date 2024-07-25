using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TravelRank : MonoBehaviour
{
    public GameObject imageObject;
    public Button back;
    public GameObject Loading;

    private Vector3 initialScale = new Vector3(15f, 15f, 1f);
    private Vector3 targetScale = new Vector3(5f, 5f, 1f);
    private float duration = 2f;
    private bool isScaling = false;

    void Start()
    {
        imageObject.SetActive(false);
    }

    void Update()
    {
        if (imageObject.activeSelf && !isScaling)
        {
            StartCoroutine(ScaleOverTime(initialScale, targetScale, duration));
            isScaling = true;
        }
    }

    IEnumerator ScaleOverTime(Vector3 fromScale, Vector3 toScale, float duration)
    {
        float startTime = Time.time;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            imageObject.transform.localScale = Vector3.Lerp(fromScale, toScale, t);
            elapsedTime += Time.deltaTime;
        }

        yield return new WaitForSeconds(2f);
        back.gameObject.SetActive(true);

        //imageObject.transform.localScale = toScale;
    }

    public void goto_room(){
        Loading.SetActive(true);
    }
}
