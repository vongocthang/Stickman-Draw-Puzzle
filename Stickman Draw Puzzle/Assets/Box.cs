using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject woodAudios;

    public float timeLine;

    // Start is called before the first frame update
    void Start()
    {
        woodAudios = GameObject.Find("Wood Audios");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (timeLine + 0.5f < Time.time)
        {
            timeLine = Time.time;

            int ran = Random.Range(1, 3);

            woodAudios.transform.GetChild(ran).GetComponent<AudioSource>().Play();
        }
    }
}
