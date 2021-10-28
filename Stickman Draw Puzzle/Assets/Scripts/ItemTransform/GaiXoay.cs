using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaiXoay : MonoBehaviour
{
    public TempDrawLine drawLine;

    // Start is called before the first frame update
    void Start()
    {
        drawLine = GameObject.Find("Draw Line").GetComponent<TempDrawLine>();
    }

    // Update is called once per frame
    void Update()
    {
        if (drawLine.line == null)
        {
            this.transform.Rotate(Vector3.back * 30 * Time.deltaTime);
        }
    }
}
