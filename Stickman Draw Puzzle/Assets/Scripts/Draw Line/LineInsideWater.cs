using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineInsideWater : MonoBehaviour
{
    Rigidbody2D thisRb;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        thisRb = this.GetComponent<Rigidbody2D>();
        speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.thisRb.bodyType == RigidbodyType2D.Dynamic)
        {
            speed = Mathf.Lerp(speed, 1f, 1 * Time.deltaTime);
            thisRb.velocity = new Vector2(0, speed);
        }
    }
}
