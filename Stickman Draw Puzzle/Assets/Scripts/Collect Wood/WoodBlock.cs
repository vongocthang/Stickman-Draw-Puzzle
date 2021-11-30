using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBlock : MonoBehaviour
{
    public CollectWoodGC collectWood;
    public int woodMax;

    public GameObject woodAudios;

    public float timeLine;

    // Start is called before the first frame update
    void Start()
    {
        collectWood = GameObject.Find("MainUI").GetComponent<CollectWoodGC>();
        woodMax = GameObject.FindGameObjectsWithTag("Wood").Length;

        woodAudios = GameObject.Find("Wood Audios");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Truck")
        {
            collectWood.countWood++;
            if (woodMax >= 5)
            {
                if (collectWood.countWood >= woodMax / 2 +1)
                {
                    collectWood.timeLine = Time.time;
                    collectWood.beginCountTime = true;
                }
            }
            else
            {
                if (collectWood.countWood == woodMax)
                {
                    collectWood.timeLine = Time.time;
                    collectWood.beginCountTime = true;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Truck")
        {
            collectWood.countWood--;
            if (woodMax >= 5)
            {
                if (collectWood.countWood < woodMax / 2 + 1)
                {
                    collectWood.beginCountTime = false;
                }
            }
            else
            {
                if (collectWood.countWood < woodMax)
                {
                    collectWood.timeLine = Time.time;
                    collectWood.beginCountTime = false;
                }
            }
        }
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
