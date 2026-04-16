using UnityEngine;

public class Star : CelestialBody
{
    [Header("Rotación de la Estrella")]
    public float rotationSpeed = 2f;

    protected override void Start()
    {
        base.Start();
        bodyName = "Sol";
    }

    public override void UpdateMovement()
    {
        // El Sol solo rota sobre sí mismo
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);
    }
}