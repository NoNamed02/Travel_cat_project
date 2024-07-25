using UnityEngine;
using UnityEngine.UI;

public class rest_stemina_show : MonoBehaviour
{
    public Slider stemina;
    public Image sliderImage;

    private float pre_stemina;

    private bool increasingAlpha = true;
    private float minAlpha = 0.2f;
    private float maxAlpha = 1f;
    private float alphaChangeSpeed = 0.5f; 

    void Start()
    {
        stemina.maxValue = GAMEMANAGER.Instance.Max_value;
        UpdateSteminaDisplay();
    }

    void Update()
    {
        if (pre_stemina + 20 > stemina.maxValue)
        {
            stemina.value = stemina.maxValue;
        }
        else
        {
            stemina.value = GAMEMANAGER.Instance.pre_stemina + 20;
        }
        ChangeSliderImageAlpha();
    }


    public void pre_stemina_update(){
        pre_stemina = GAMEMANAGER.Instance.pre_stemina + 20;
    }












    void UpdateSteminaDisplay()
    {
        stemina.value = GAMEMANAGER.Instance.stemina;
    }

    void ChangeSliderImageAlpha()
    {
        float currentAlpha = sliderImage.color.a;

        if (increasingAlpha)
        {
            currentAlpha += alphaChangeSpeed * Time.deltaTime;
            if (currentAlpha >= maxAlpha)
            {
                currentAlpha = maxAlpha;
                increasingAlpha = false;
            }
        }
        else
        {
            currentAlpha -= alphaChangeSpeed * Time.deltaTime;
            if (currentAlpha <= minAlpha)
            {
                currentAlpha = minAlpha;
                increasingAlpha = true;
            }
        }
        Color newColor = sliderImage.color;
        newColor.a = currentAlpha;
        sliderImage.color = newColor;
    }
}
