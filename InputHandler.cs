using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static event Action<Cube> OnCubeClicked;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out Cube cube))
                {
                    OnCubeClicked?.Invoke(cube);
                }
            }
        }
    }
}
