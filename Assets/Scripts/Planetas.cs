using UnityEngine;

public class Planet : CelestialBody
{
    [Header("Datos Orbitales")]
    public OrbitData orbitData;

    [Header("Rotación Propia")]
    public float rotationPeriod = 24f;   // negativo = retrógrada
    public float axialTilt = 0f;

    [Header("Referencia")]
    public Transform orbitCenter;        // Asigna el Sol en el Inspector
    public float timeScale = 10f;

    private float currentAngle;

    protected override void Start()
    {
        base.Start();
        currentAngle = orbitData.initialAngle * Mathf.Deg2Rad;
        // Aplica inclinación axial
        transform.rotation = Quaternion.Euler(axialTilt, 0f, 0f);

        // Si no se asignó el centro, busca por tag
        if (orbitCenter == null)
            orbitCenter = GameObject.FindGameObjectWithTag("Sun").transform;
    }

    public override void UpdateMovement()
    {
        Orbit();
        SelfRotate();
    }

    void Orbit()
    {
        if (orbitCenter == null) return;

        float angularSpeed = (2f * Mathf.PI) / orbitData.orbitalPeriod;
        currentAngle += angularSpeed * Time.deltaTime * timeScale;

        float x = orbitData.semiMajorAxis * Mathf.Cos(currentAngle);
        float z = orbitData.semiMinorAxis * Mathf.Sin(currentAngle);

        Vector3 pos = new Vector3(x, 0f, z);
        pos = Quaternion.Euler(orbitData.orbitalInclination, 0f, 0f) * pos;
        transform.position = orbitCenter.position + pos;
    }

    void SelfRotate()
    {
        float speed = 360f / Mathf.Abs(rotationPeriod);
        float dir = rotationPeriod >= 0 ? 1f : -1f;
        transform.Rotate(Vector3.up, speed * dir * Time.deltaTime * timeScale, Space.Self);
    }
}