using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineInsideWater : MonoBehaviour
{
    Rigidbody2D thisRb;

    // Start is called before the first frame update
    void Start()
    {
        thisRb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.thisRb.bodyType == RigidbodyType2D.Dynamic)
        {
            thisRb.velocity = new Vector2(0, 1f);
        }
    }
}
