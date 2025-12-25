using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class BoxController : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public int _splitChance = 200;

    private void Start()
    {
        _splitChance /= 2;
        RandomizeColor();
    }

    private void OnMouseUpAsButton()
    {
        if (Random.Range(0, 101) <= _splitChance)
        {
            int numCubesToSpawn = Random.Range(2, 7);

            for (int i = 0; i < numCubesToSpawn; i++)
            {
                SpawnNewCube(transform.position);
            }
        }

        Destroy(gameObject);
    }

    private void SpawnNewCube(Vector3 position)
    {
        GameObject newCube = Instantiate(_cubePrefab, position + Random.insideUnitSphere * 0.5f, Quaternion.identity);

        newCube.transform.localScale = transform.localScale / 2f; // уменьшение размера
        newCube.AddComponent<Rigidbody>();
        newCube.GetComponent<Rigidbody>().mass = transform.GetComponent<Rigidbody>().mass / 2f; // изменение массы
        newCube.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, position, 1f); // ¬зрывна€ сила
    }

    private void RandomizeColor()
    {
        Renderer renderer = GetComponent<Renderer>();
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        renderer.material.color = randomColor;
    }
}
