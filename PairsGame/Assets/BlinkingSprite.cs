using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BlinkingSprite : MonoBehaviour
{
    public Color a, b;
    public AnimationCurve blinkCurve;

    SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while(true)
        {
            renderer.color = Color.Lerp(a, b, blinkCurve.Evaluate(Time.time));
            yield return null;
        }
    }
}
