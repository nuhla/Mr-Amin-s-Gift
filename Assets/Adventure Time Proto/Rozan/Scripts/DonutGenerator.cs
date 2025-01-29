using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class DonutGenerator : MonoBehaviour
{
    public int segments = 24;
    public int ringSegments = 12;
    public float radius = 1f;
    public float thickness = 0.3f;
    public Material chocolateMaterial;
    public Material baseMaterial;

    void Start()
    {
        GenerateDonut();
        ApplyMaterials();
    }

    void GenerateDonut()
    {
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[segments * ringSegments];
        Vector2[] uv = new Vector2[vertices.Length];
        List<int> topEdgeTriangles = new List<int>();
        List<int> bottomTriangles = new List<int>();

        float segmentAngle = Mathf.PI * 2f / segments;
        float ringAngle = Mathf.PI * 2f / ringSegments;

        for (int i = 0; i < segments; i++)
        {
            float segmentTheta = i * segmentAngle;
            Vector3 center = new Vector3(Mathf.Cos(segmentTheta) * radius, 0, Mathf.Sin(segmentTheta) * radius);

            for (int j = 0; j < ringSegments; j++)
            {
                float ringTheta = j * ringAngle;
                Vector3 offset = new Vector3(0, Mathf.Cos(ringTheta) * thickness, Mathf.Sin(ringTheta) * thickness);
                vertices[i * ringSegments + j] = center + offset;
                uv[i * ringSegments + j] = new Vector2((float)i / segments, (float)j / ringSegments);
            }
        }

        for (int i = 0; i < segments; i++)
        {
            for (int j = 0; j < ringSegments; j++)
            {
                int current = i * ringSegments + j;
                int next = i * ringSegments + (j + 1) % ringSegments;
                int nextSegment = ((i + 1) % segments) * ringSegments + j;
                int nextSegmentNext = ((i + 1) % segments) * ringSegments + (j + 1) % ringSegments;

                if (Mathf.Abs(vertices[current].y) < 0.2f || Mathf.Abs(vertices[next].y) < 0.1f || Mathf.Abs(vertices[nextSegment].y) < 0.1f)
                {
                    topEdgeTriangles.Add(current);
                    topEdgeTriangles.Add(nextSegment);
                    topEdgeTriangles.Add(next);

                    topEdgeTriangles.Add(next);
                    topEdgeTriangles.Add(nextSegment);
                    topEdgeTriangles.Add(nextSegmentNext);
                }
                else
                {
                    bottomTriangles.Add(current);
                    bottomTriangles.Add(nextSegment);
                    bottomTriangles.Add(next);

                    bottomTriangles.Add(next);
                    bottomTriangles.Add(nextSegment);
                    bottomTriangles.Add(nextSegmentNext);
                }
            }
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.subMeshCount = 2;

        mesh.SetTriangles(bottomTriangles.ToArray(), 0);
        mesh.SetTriangles(topEdgeTriangles.ToArray(), 1);
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;
    }

    void ApplyMaterials()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if (chocolateMaterial != null && baseMaterial != null)
        {
            renderer.materials = new Material[] { chocolateMaterial, baseMaterial };
        }
        else
        {
            Debug.LogWarning("Please assign both chocolate and base materials in the inspector.");
        }

    }
}
