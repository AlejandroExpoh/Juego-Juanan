using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    private Mesh mesh;
    private Vector3 origin;
    private float startinangle;
    private float fov;
    public float viewDistance;
    public static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        fov = 90f;
        viewDistance = 15f;
        origin = Vector3.zero;
    }


    private void LateUpdate()
    {
        int rayCount = 1000;
        float angle = startinangle;
        float angleIncrease = fov / rayCount;
      

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, layerMask);
            if (raycastHit2D.collider == null)
            {
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
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


        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.bounds = new Bounds(origin, Vector3.one * 1000f);

    }

    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetAimDirection (Vector3 aimDirection)
    {
        startinangle = GetAngleFromVectorFloat(aimDirection) + 90f - fov / 2f; ;
    }

    //public void SetFov(float fov)
    //{
    //    this.fov = fov;
    //}

    //public void SetViewDistance(float viewDistance)
    //{
    //    this.viewDistance = viewDistance;
    //}

}
    

