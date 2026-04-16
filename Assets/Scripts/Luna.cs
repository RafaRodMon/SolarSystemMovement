using UnityEngine;

public class Moon : CelestialBody
{
    [Header("Datos Orbitales")]
    public OrbitData orbitData;

    public Transform parentPlanet;   // Asigna la Tierra en el Inspector
    public float rotationPeriod = 27f;
    public float timeScale = 10f;

    private float currentAngle;

    protected override void Start()
    {
        base.Start();
        currentAngle = orbitData.initialAngle * Mathf.Deg2Rad;
    }

    public override void UpdateMovement()
    {
        if (parentPlanet == null) return;

        float angularSpeed = (2f * Mathf.PI) / orbitData.orbitalPeriod;
        currentAngle += angularSpeed * Time.deltaTime * timeScale;

        float x = orbitData.semiMajorAxis * Mathf.Cos(currentAngle);
        float z = orbitData.semiMinorAxis * Mathf.Sin(currentAngle);

        transform.position = parentPlanet.position + new Vector3(x, 0f, z);
        transform.Rotate(Vector3.up, (360f / rotationPeriod) * Time.deltaTime * timeScale, Space.Self);
    }
}