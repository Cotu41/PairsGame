using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Projectile : MonoBehaviour
{

    public bool isRed = false;
    public float speed = 1;

    public Color redShade, blueShade;

    Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        isRed = (Random.value > 0.5f);
        GetComponent<SpriteRenderer>().color = isRed ? redShade : blueShade;
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            //transform.position = Vector2.Lerp(transform.position, target, Time.deltaTime * speed);
        }
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
                print("samecolor");
        }
    }
}
