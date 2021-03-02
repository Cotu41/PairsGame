using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



[RequireComponent(typeof(SpriteRenderer))]
public class HeartIndicator : MonoBehaviour
{
    public static float hearts = 1;
    public float starting_hearts = 4;

    public delegate void HealthAction();
    public static event HealthAction OnPlayerDeath;

    bool hit_zero = false;

    float width_per_heart;
    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        hearts = starting_hearts;
        renderer = GetComponent<SpriteRenderer>();
        if (!renderer.drawMode.Equals(SpriteDrawMode.Tiled))
            Debug.LogWarning("Warning: This sprite isn't in tiled mode. You kinda need that.");
        else
        {
            width_per_heart = renderer.size.x;
            renderer.size = new Vector2(hearts * width_per_heart, renderer.size.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (hearts < 0) hearts = 0; // clamp it at 0
        if (hearts == 0 && !hit_zero)
            OnPlayerDeath?.Invoke(); // sends out an event that the player is out of health

        if (Input.GetKeyDown(KeyCode.KeypadPlus))
            hearts++;
        else if (Input.GetKeyDown(KeyCode.KeypadMinus))
            hearts--;
    }

    private void OnGUI()
    {
        if (renderer.drawMode.Equals(SpriteDrawMode.Tiled))
            renderer.size = new Vector2(hearts * width_per_heart, renderer.size.y);

    }
}
