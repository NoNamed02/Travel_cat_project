using UnityEngine;

public class touch_to_start : MonoBehaviour
{
    // 최소 스케일
    public float minScale = 1.5f;
    // 최대 스케일
    public float maxScale = 1.8f;
    // 스케일 변경 속도
    public float scaleSpeed = 8f;

    // Update is called once per frame
    void Update()
    {
        // PingPong 함수를 사용하여 스케일 값을 설정
        float scale = Mathf.PingPong(Time.time * scaleSpeed, maxScale - minScale) + minScale;
        
        // 현재 GameObject의 스케일을 변경
        transform.localScale = new Vector3(scale, scale, 1f);
    }
}
