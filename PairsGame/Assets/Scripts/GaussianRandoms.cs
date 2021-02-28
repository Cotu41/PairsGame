using System.Collections;
using UnityEngine;



/*
 * My nice little Gaussian random class :)
 * 
 * Basically this guy can give you randoms that center around an average you can specify. You can also specify standard deviation, maximum, and minimum- if that's your cup of tea.
 * 
 * Original implementation was by Alan Zucconi, I just McStole it because it's crazy useful
 */
public class GaussianRandoms
{

    public static float NextGaussian()
    {
        float v1, v2, s;
        do
        {
            v1 = 2.0f * Random.Range(0f, 1f) - 1.0f;
            v2 = 2.0f * Random.Range(0f, 1f) - 1.0f;
            s = v1 * v1 + v2 * v2;
        } while (s >= 1.0f || s == 0f);
        s = Mathf.Sqrt((-2.0f * Mathf.Log(s)) / s);
        return v1 * s;
    }

    public static float NextGaussian(float mean, float standard_deviation)
    {
        return mean + NextGaussian() * standard_deviation;
    }

    public static float NextGaussian(float mean, float standard_deviation, float min, float max)
    {
        float x;
        do
        {
            x = NextGaussian(mean, standard_deviation);
        } while (x < min || x > max);
        return x;
    }

}
