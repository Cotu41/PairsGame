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
    Rigidbody2D body;
    Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        radius = Mathf.Abs((transform.position).magnitude); // distance from zero
        angle = Mathf.Deg2Rad*startAngle;
        collider = GetComponent<Collider2D>();

        if (redShade == null) redShade = Color.red;
        if (blueShade == null) blueShade = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRed)
        {
            renderer.color = redShade;
            gameObject.layer = 11;
        }
        else
        {
            renderer.color = blueShade;
            gameObject.layer = 10;
        }

        if (Input.GetKeyDown(swapkey)) isRed = !isRed;

        if(Input.GetKey(left) || Input.GetKey(right))
        {
            if (Input.GetKey(left)) angle += moveSpeed;
            else angle -= moveSpeed;

            float x = radius * Mathf.Cos(angle);
            float y = radius * Mathf.Sin(angle);

            

            transform.rotation = Quaternion.Euler(0, 0, angle*Mathf.Rad2Deg);
            transform.position = new Vector3(x, y, transform.position.z);
        }

        
    }

    

    
}
