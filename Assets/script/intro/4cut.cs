using System.Collections;
using UnityEngine;

public class cut_4 : MonoBehaviour
{
    private int cut = -1;
    public GameObject[] cuts = new GameObject[4];
    public GameObject Loading;
    

    void Start()
    {
        StartCoroutine(ActivateCutsWithDelay());
    }

    IEnumerator ActivateCutsWithDelay()
    {
        yield return new WaitForSeconds(1f); // 1초 후
        ActivateCut(0);

        yield return new WaitForSeconds(2f); // 2초 후
        ActivateCut(1);

        yield return new WaitForSeconds(2f); // 2초 후
        ActivateCut(2);

        yield return new WaitForSeconds(2f); // 2초 후
        ActivateCut(3);

        yield return new WaitForSeconds(2f); // 2초 후
        ActivateLoading();
    }

    void ActivateCut(int index)
    {
        if (index >= 0 && index < cuts.Length)
        {
            cuts[index].SetActive(true);
        }
    }

    void ActivateLoading()
    {
        Loading.SetActive(true);
    }

    void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            cut++;
            if (cut < cuts.Length)
            {
                ActivateCut(cut);
            }
        }
        */
    }
}
