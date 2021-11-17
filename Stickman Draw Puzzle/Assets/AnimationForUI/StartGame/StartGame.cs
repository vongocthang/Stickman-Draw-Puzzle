using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public float timeStopRotate;
    public float rotateSpeed;
    public GameObject start_button;
    public GameObject temp_box;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StopRotate(timeStopRotate));
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }

    IEnumerator StopRotate(float second)
    {
        yield return new WaitForSeconds(second);

        temp_box.SetActive(false);
        start_button.SetActive(true);
        this.GetComponent<StartGame>().enabled = false;
    }


}
