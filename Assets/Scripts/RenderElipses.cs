using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class OrbitRenderer : MonoBehaviour
{
    public OrbitData orbitData;
    public Transform center;
    public int segments = 128;
    public Color color = new Color(1f, 1f, 1f, 0.15f);

    void Start()
    {
        if (center == null)
            center = GameObject.FindGameObjectWithTag("Sun").transform;

        LineRenderer lr = GetComponent<LineRenderer>();
        lr.positionCount = segments + 1;
        lr.loop = true;
        lr.startWidth = lr.endWidth = 0.08f;
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = lr.endColor = color;
        lr.useWorldSpace = true;

        for (int i = 0; i <= segments; i++)
        {
            float angle = (i / (float)segments) * 2f * Mathf.PI;
            float x = orbitData.semiMajorAxis * Mathf.Cos(angle);
            float z = orbitData.semiMinorAxis * Mathf.Sin(angle);
            Vector3 point = Quaternion.Euler(orbitData.orbitalInclination, 0f, 0f) * new Vector3(x, 0f, z);
            lr.SetPosition(i, center.position + point);
        }
    }
}