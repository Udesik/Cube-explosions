using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 500f;
    [SerializeField] private float _explosionRadius = 5f;

    public void Explode(Vector3 position, IEnumerable<Rigidbody> targets)
    {
        foreach (Rigidbody rb in targets)
        {
            rb.AddExplosionForce(_explosionForce, position, _explosionRadius);
        }
    }
}
