using System.Collections.Generic;
using UnityEngine;

public class Explosions : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 500f;
    [SerializeField] private float _explosionRadius = 5f;

    public void Explode(Vector3 position, List<Cube> cubesToPush)
    {
        foreach (Cube cube in cubesToPush)
        {
            if (cube.TryGetComponent(out Rigidbody rb))
            {
                rb.AddExplosionForce(_explosionForce, position, _explosionRadius);
            }
        }
    }
}
