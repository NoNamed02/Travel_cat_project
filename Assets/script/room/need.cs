using UnityEngine;

public class need : MonoBehaviour
{
    public GameObject self;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Soundmanager.Instance.Playsound("out_btn");
            self.SetActive(false);
        }
    }
}
