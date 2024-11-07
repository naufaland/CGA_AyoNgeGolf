using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreateProceduralCube();
    }

    void CreateProceduralCube()
    {
        // Create a new mesh
        Mesh mesh = new Mesh();

        // Define the vertices of the cube
        Vector3[] vertices = new Vector3[]
        {
            // Front face
            new Vector3(0, 0, 0),
            new Vector3(1, 0, 0),
            new Vector3(1, 1, 0),
            new Vector3(0, 1, 0),

            // Back face
            new Vector3(0, 0, -1),
            new Vector3(1, 0, -1),
            new Vector3(1, 1, -1),
            new Vector3(0, 1, -1)
        };

        // Define the triangles of the cube
        int[] triangles = new int[]
        {
            // Front face
            0, 2, 1,
            0, 3, 2,

            // Top face
            2, 3, 7,
            2, 7, 6,

            // Back face
            5, 7, 4,
            5, 6, 7,

            // Bottom face
            0, 1, 5,
            0, 5, 4,

            // Left face
            0, 7, 3,
            0, 4, 7,

            // Right face
            1, 2, 6,
            1, 6, 5
        };

        // Define the UVs of the cube
        Vector2[] uvs = new Vector2[]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0, 1),

            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0, 1)
        };

        // Assign the vertices, triangles, and UVs to the mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;

        // Recalculate normals for lighting
        mesh.RecalculateNormals();

        // Create a new GameObject and add the mesh components
        GameObject cube = new GameObject("ProceduralCube");
        MeshFilter meshFilter = cube.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = cube.AddComponent<MeshRenderer>();

        // Assign the mesh to the MeshFilter
        meshFilter.mesh = mesh;

        // Assign a material to the MeshRenderer
        meshRenderer.material = new Material(Shader.Find("Standard"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}