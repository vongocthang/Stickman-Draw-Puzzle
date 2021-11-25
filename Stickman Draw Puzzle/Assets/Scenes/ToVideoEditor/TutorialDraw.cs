using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDraw : MonoBehaviour
{
    public Transform[] points;
    public int location = 0;
    public float speed;
    public Transform hand;

    // Start is called before the first frame update
    void Start()
    {
        hand = transform.GetChild(0).gameObject.transform;
        points = new Transform[transform.childCount - 1];
        for(int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i + 1);
        }
        hand.transform.position = points[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        AutoDrawLine();
    }

    public void AutoDrawLine()
    {
        
        if(Vector2.Distance(hand.transform.position, points[location].position) == 0)
        {
            if (location == points.Length - 1)
            {
                hand.gameObject.SetActive(false);
                StartCoroutine(StartAgain());
            }
            else
            {
                location++;
            }
        }
        else
        {
            hand.transform.position = Vector2.MoveTowards(hand.transform.position,
            points[location].position, speed * Time.deltaTime);
        }
    }

    IEnumerator StartAgain()
    {
        yield return new WaitForSeconds(1f);

        location = 0;
        hand.transform.position = points[location].position;
        hand.gameObject.SetActive(true);
    }
}
