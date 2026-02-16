using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    private void OnEnable()
    {
        _inputHandler.CubeClicked += HandleCubeClick;
    }

    private void OnDisable()
    { 
        _inputHandler.CubeClicked -= HandleCubeClick;
    }

    private void HandleCubeClick(Cube cube)
    {
        float randomValue = Random.value;

        if (randomValue <= cube.SplitChance)
        {
            List<Cube> createdCubes = _spawner.SpawnSplittedCubes(cube);
            IEnumerable<Rigidbody> rigidbodies = createdCubes.Select(c => c.Rigidbody);
            
            _exploder.Explode(cube.transform.position, rigidbodies);
        }

        _spawner.DestroyCube(cube);
    }
}
