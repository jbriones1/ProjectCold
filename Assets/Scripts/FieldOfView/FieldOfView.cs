﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] Player player;
    private Mesh mesh;
    private float fov;
    private Vector3 origin;
    private float startingAngle;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        fov = 360f;
        origin = Vector3.zero;
    }

    void LateUpdate()
    {
        int rayCount = 360;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;
        float viewDistance = player.Health * 0.08f + 1f;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1]; // Two rays vertices, one on angle 0 and one on the origin
        Vector2[] uv = new Vector2[vertices.Length]; // Equal to the amount of triangles
        int[] triangles = new int[rayCount * 3]; // States what points the triangles have

        vertices[0] = origin;
        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex = Vector3.zero;

            // If this hits a wall
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, Utilities.GetVectorFromAngle(angle), viewDistance, layerMask);

            if (raycastHit2D.collider == null)
            {
                // No hit
                vertex = origin + Utilities.GetVectorFromAngle(angle) * viewDistance;
            } else {
                // Hit object
                vertex = raycastHit2D.point;
            }

            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }
            vertexIndex++;

            angle -= angleIncrease;
        }

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.bounds = new Bounds(origin, Vector3.one * 1000f);
    }

    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetAimDirection(float angle)
    {
        startingAngle = angle;
    }
}

