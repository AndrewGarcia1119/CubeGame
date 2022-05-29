using TMPro;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField]
    Cube cubePrefab;

    public GameObject eventCanvas;
    public TextMeshProUGUI canvasText;

    public void SpawnCube()
    {
        Instantiate(cubePrefab, transform);
    }
}
