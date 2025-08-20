using UnityEngine;
using System.Collections.Generic;

public class CheckTerrain : MonoBehaviour
{
    [SerializeField] private Vector3 coneDirection = Vector3.forward;
    [SerializeField] private float coneAngle = 45f;
    [SerializeField] private float rayLength = 5f;

    private List<Vector3> coneDirections = new List<Vector3>();

    void Start()
    {

        GenerateConeDirections(coneDirection.normalized, 400);
    }

    void Update()
    {
        DrawCone(transform.position, coneDirections, rayLength);
    }

    void GenerateConeDirections(Vector3 direction, int rayCount)
    {
        coneDirections.Clear();

        int rings = 10; 
        int segmentsPerRing = rayCount / rings;

        Quaternion toDirection = Quaternion.FromToRotation(Vector3.forward, direction.normalized);
        float maxAngle = coneAngle;

        for (int ring = 0; ring < rings; ring++)
        {
            float ringAngle = Mathf.Lerp(0f, maxAngle, (float)ring / (rings - 1));
            for (int seg = 0; seg < segmentsPerRing; seg++)
            {
                float azimuth = 360f * seg / segmentsPerRing;

                Quaternion rot = Quaternion.Euler(ringAngle * Mathf.Sin(azimuth * Mathf.Deg2Rad),
                                                  ringAngle * Mathf.Cos(azimuth * Mathf.Deg2Rad),
                                                  0f);

                Vector3 localDir = rot * Vector3.forward;
                Vector3 worldDir = toDirection * localDir.normalized;

                coneDirections.Add(worldDir);
            }
        }
    }

    void DrawCone(Vector3 origin, List<Vector3> directions, float length)
    {
        foreach (Vector3 dir in directions)
        {
            Debug.DrawRay(origin, dir * length, Color.red);
        }
    }
}
