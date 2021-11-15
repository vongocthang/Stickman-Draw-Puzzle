using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsUpDown : MonoBehaviour
{
    public float scaleX;
    public float scaleY;

    private void Start()
    {
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
    }

    public void UpEffects()
    {
        this.transform.localScale = new Vector2(scaleX * 1f, scaleY * 1f);
    }

    public void DownEffects()
    {
        this.transform.localScale = new Vector2(scaleX * 0.8f, scaleY * 0.8f);
    }
}
