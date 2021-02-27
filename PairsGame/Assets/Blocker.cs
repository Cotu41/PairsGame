using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[ExecuteInEditMode]
public class Blocker : MonoBehaviour
{

    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode swapkey = KeyCode.Space;

    public float startAngle = 0;
    float angle = 0;
    float radius;
    public bool isRed = false;
    public float moveSpeed = 1;

    public Color redShade, blueShade;

    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        radius = Mathf.Abs((transform.position).magnitude); // distance from zero
        angle = Mathf.Deg2Rad*startAngle;


        if (redShade == null) redShade = Color.red;
        if (blueShade == null) blueShade = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRed) renderer.color = redShade;
        else renderer.color = blueShade;

        if (Input.GetKeyDown(swapkey)) isRed = !isRed;

        if(Input.GetKey(left) || Input.GetKey(right))
        {
            if (Input.GetKey(left)) angle += moveSpeed;
            else angle -= moveSpeed;

            float x = radius * Mathf.Cos(angle);
            float y = radius * Mathf.Sin(angle);

            

            transform.position = new Vector3(x, y, transform.position.z);
        }
    }
}
