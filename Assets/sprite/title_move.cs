using UnityEngine;

public class title_move : MonoBehaviour
{
    public RectTransform rect_image;

    void Start()
    {
        rect_image = GetComponent<RectTransform>();

        Vector3 startPos = new Vector3(-1200f, rect_image.localPosition.y, rect_image.localPosition.z);
        rect_image.localPosition = startPos;
    }
    void Update()
    {
        Vector3 targetPos = new Vector3(-253f, rect_image.localPosition.y, rect_image.localPosition.z);
        
        float moveSpeed = 2f;
        rect_image.localPosition = Vector3.Lerp(rect_image.localPosition, targetPos, Time.deltaTime * moveSpeed);
    }
}
