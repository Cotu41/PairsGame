using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(SpriteRenderer))]
public class Projectile : MonoBehaviour
{

    public bool isRed = false;
    public float speed = 1;


    public Color redShade, blueShade;

    Vector2 target;
    SpriteRenderer renderer;
    // Start is called before the first frame update

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();

        isRed = (Random.value > 0.5f);
        if (isRed)
        {
            renderer.color = redShade;
            gameObject.layer = 9;
        }
        else
        {
            renderer.color = blueShade;
            gameObject.layer = 8;
        }
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


        // this code (which destroys projectiles) will only run in play mode. This prevents the ceaseless stacking up of errors in edit mode
#if !UNITY_EDITOR
        if (((Vector2)transform.position - target).magnitude > 100 || ((Vector2)transform.position - target).magnitude < -100) //if we get too far away from origin, die
                Destroy(gameObject);
            else if (((Vector2)transform.position - target).magnitude == 0)
                Destroy(gameObject);
#endif
    }



    public void sendToward(Vector2 point)
    {
        GetComponent<Rigidbody2D>().velocity = (point - (Vector2)transform.position).normalized * speed;

        target = point;
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Blocker output;
        if (collision.gameObject.TryGetComponent<Blocker>(out output))
        {
            if (output.isRed == isRed)
                Destroy(gameObject, 0.150f);
        }
    }
}
