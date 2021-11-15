using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;

public class GravityCar : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float tempSpeed;

    public GameObject forwardWheel;
    public GameObject backWheel;

    public SkeletonAnimation skeletonAnim;
    public int countAnim = 1;
    public float countTime;

    FixedJoystick joy;

    float tempGoc = 0;
    float goc = 0;


    // Start is called before the first frame update
    void Start()
    {
        joy = GameObject.FindObjectOfType<FixedJoystick>();
        tempGoc = forwardWheel.transform.rotation.z * Mathf.Rad2Deg;
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
        goc = (float)(canhKe / canhHuyen) * Mathf.Rad2Deg;
        

        //Animation
        if (joy.Direction.x < 0)
        {
            if (this.name == "CarLeft")
            {
                skeletonAnim.AnimationName = "Forward";
                goc += 180;
                Quaternion x = forwardWheel.transform.rotation;
                Quaternion y = Quaternion.Euler(0, 0, goc);

                forwardWheel.transform.rotation = Quaternion.Lerp(x, y, 10 * Time.deltaTime);
                backWheel.transform.rotation = Quaternion.Lerp(x, y, 10 * Time.deltaTime);
            }
            else
            {
                skeletonAnim.AnimationName = "Backward";
                //goc += 90;
                Quaternion x = forwardWheel.transform.rotation;
                Quaternion y = Quaternion.Euler(0, 0, goc);
                Debug.Log(goc);
                forwardWheel.transform.rotation = Quaternion.Lerp(x, y, 10 * Time.deltaTime);
                backWheel.transform.rotation = Quaternion.Lerp(x, y, 10 * Time.deltaTime);
            }
            
        }
        if(joy.Direction.x > 0)
        {
            if (this.name == "CarLeft")
            {
                skeletonAnim.AnimationName = "Backward";
                Quaternion x = forwardWheel.transform.rotation;
                Quaternion y = Quaternion.Euler(0, 0, -goc);

                forwardWheel.transform.rotation = Quaternion.Lerp(x, y, 10 * Time.deltaTime);
                backWheel.transform.rotation = Quaternion.Lerp(x, y, 10 * Time.deltaTime);
            }
            else
            {
                skeletonAnim.AnimationName = "Forward";
                goc += 180;
                Quaternion x = forwardWheel.transform.rotation;
                Quaternion y = Quaternion.Euler(0, 0, -goc);

                forwardWheel.transform.rotation = Quaternion.Lerp(x, y, 10 * Time.deltaTime);
                backWheel.transform.rotation = Quaternion.Lerp(x, y, 10 * Time.deltaTime);
            }
        }

        if(joy.Direction != new Vector2(0, 0))
        {
            tempSpeed = Mathf.Lerp(tempSpeed, speed, 1 * Time.deltaTime);
            rb.velocity = new Vector2(joy.Direction.x * tempSpeed * Time.deltaTime,
                joy.Direction.y * tempSpeed * Time.deltaTime);
            //rb.AddForce(new Vector2(joy.Direction.x * speed * Time.deltaTime,
            //    joy.Direction.y * speed * Time.deltaTime));

            //Animation reset lại từ 1
            countAnim = 1;
        }
        if (joy.Direction == new Vector2(0,0))
        {
            tempSpeed = 0;
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
