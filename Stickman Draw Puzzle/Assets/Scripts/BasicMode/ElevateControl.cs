using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevateControl : MonoBehaviour
{
    float speed = 0.2f;
    public Transform maxUp;
    public Transform maxDown;

    BasicModeGC basicModeGC;

    // Start is called before the first frame update
    void Start()
    {
        basicModeGC = GameObject.Find("MainUI").GetComponent<BasicModeGC>();
    }

    // Update is called once per frame
    void Update()
    {
        Elevate();
    }

    public void Elevate()
    {
        if (basicModeGC.up == true)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, maxUp.position, speed * Time.deltaTime);
        }
        if (basicModeGC.down == true)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, maxDown.position, speed * Time.deltaTime);
        }
    }
}
