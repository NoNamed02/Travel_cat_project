using UnityEngine;

public class logo_move : MonoBehaviour
{
    // 시작 위치와 목표 위치
    private Vector3 startPos = new Vector3(0f, 2300f, 0f); // 시작 위치 (x는 0, y는 2300)
    private Vector3 targetPos = new Vector3(0f, 1000f, 0f); // 목표 위치 (x는 0, y는 1000)

    // 이동 시간과 속도
    public float moveTime = 1f; // 이동하는 데 걸리는 시간

    // Update is called once per frame
    void Update()
    {
        // 보간을 사용하여 현재 위치를 업데이트
        float t = Mathf.Clamp01(Time.deltaTime / moveTime); // 보간 시간을 계산하고 0에서 1 사이로 클램프
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, t); // 보간된 위치로 이동
    }

    // Start is called before the first frame update
    void Start()
    {
        // 시작할 때 초기 위치 설정
        transform.localPosition = startPos;
    }
}
