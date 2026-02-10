using UnityEngine;

[RequireComponent(typeof(Renderer), typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    public float SplitChance { get; private set; } = 1.0f;

    public void Init(float splitChance, Vector3 scale, Color color)
    {
        SplitChance = splitChance;
        transform.localScale = scale;
        GetComponent<Renderer>().material.color = color;
    }

    public void ReduceSplitChance()
    {
        SplitChance /= 2f;
    }
}
