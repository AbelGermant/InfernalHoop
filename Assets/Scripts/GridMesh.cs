using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class GridMesh : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize;
    [SerializeField] float gridSpacing;

    void Awake()
    {
        MeshFilter filter = gameObject.GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        List<Vector3> verticies = new List<Vector3>();

        List<int> indicies = new List<int>();
        float xMin = gridSpacing * gridSize.x / 2f;
        float zMin = gridSpacing * gridSize.y / 2f;

        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                float x1 = i * gridSpacing - xMin;
                float x2 = (i + 1) * gridSpacing - xMin;
                float z1 = j * gridSpacing - zMin;
                float z2 = (j + 1) * gridSpacing - zMin;

                if (i != gridSize.x)
                {
                    verticies.Add(new Vector3(x1, 0, z1));
                    verticies.Add(new Vector3(x2, 0, z1));
                }

                if (j != gridSize.y)
                {
                    verticies.Add(new Vector3(x1, 0, z1));
                    verticies.Add(new Vector3(x1, 0, z2));
                }
            }
        }

        int indicesCount = verticies.Count;
        for (int i = 0; i < indicesCount; i++)
        {
            indicies.Add(i);
        }

        mesh.vertices = verticies.ToArray();
        mesh.SetIndices(indicies.ToArray(), MeshTopology.Lines, 0);
        filter.mesh = mesh;
    }
}