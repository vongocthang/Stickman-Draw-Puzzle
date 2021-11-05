﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    public Vector2 scaleDefault;

    // Start is called before the first frame update
    void Start()
    {
        scaleDefault = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScaleEffectsUp()
    {
        this.transform.localScale = scaleDefault;
    }

    public void ScaleEffectsDown()
    {
        this.transform.localScale = this.transform.localScale * new Vector2(0.8f, 0.8f);
    }
}