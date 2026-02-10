using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    public List<Cube> SpawnSplittedCubes(Cube parentCube)
    {
        int count = Random.Range(2, 7);
        List<Cube> newCubes = new List<Cube>();
        Vector3 newScale = parentCube.transform.localScale / 2f;

        for (int i = 0; i < count; i++)
        {
            Cube newCube = Instantiate(_cubePrefab, parentCube.transform.position, Quaternion.identity);
            
            Color randomColor = new Color(Random.value, Random.value, Random.value);
            newCube.Init(parentCube.SplitChance / 2f, newScale, randomColor);
            
            newCubes.Add(newCube);
        }
        
        return newCubes;
    }
    
    public void DestroyCube(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}
