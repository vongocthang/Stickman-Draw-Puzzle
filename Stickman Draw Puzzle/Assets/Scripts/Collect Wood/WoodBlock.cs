using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBlock : MonoBehaviour
{
    public CollectWoodGC collectWood;
    public int woodMax;

    // Start is called before the first frame update
    void Start()
    {
        collectWood = GameObject.Find("MainUI").GetComponent<CollectWoodGC>();
        woodMax = GameObject.FindGameObjectsWithTag("Wood").Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Truck")
        {
            
            collectWood.countWood++;
            if (collectWood.countWood == woodMax)
            {
                collectWood.timeLine = Time.time;
                collectWood.beginCountTime = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Truck")
        {
            if (collectWood.countWood == woodMax)
            {
                collectWood.beginCountTime = false;
            }
            collectWood.countWood--;
        }
    }
}
