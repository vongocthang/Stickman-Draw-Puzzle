using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

public class GravityCar : MonoBehaviour
{
    public GameObject forwardWheel;
    public GameObject backWheel;

    public SkeletonAnimation skeletonAnim;
    public int countAnim = 1;
    public float countTime;

    FixedJoystick joy;


    // Start is called before the first frame update
    void Start()
    {
        joy = GameObject.FindObjectOfType<FixedJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector2 a = new Vector2(0, 0);
        Vector2 b = joy.Direction;
        float canhHuyen = Vector2.Distance(a, b);
        float canhKe = a.y - b.y;
        float goc = (float)(canhKe / canhHuyen) * Mathf.Rad2Deg;

        //forwardWheel.transform.rotation = Quaternion.Euler(0, 0, goc);
 
        Debug.Log(goc);

        //Animation
        if (joy.Direction.x <= 0)
        {
            skeletonAnim.AnimationName = "Forward";
            goc += 180;
            forwardWheel.transform.rotation = Quaternion.Euler(0, 0, goc);
        }
        else
        {
            skeletonAnim.AnimationName = "Backward";
            //goc -= 30;
            //goc -= 180;
            forwardWheel.transform.rotation = Quaternion.Euler(0, 0, -goc);
        }
        


        if (joy.Direction == new Vector2(0,0))
        {
            //Animation
            if (Time.time < countTime + 5)
            {
                skeletonAnim.AnimationName = "Idle " + countAnim.ToString();
            }
            else
            {
                if (countAnim == 3)
                {
                    countAnim = 1;
                    return;
                }
                countAnim++;
                countTime = Time.time;
            }
        }
    }
}
