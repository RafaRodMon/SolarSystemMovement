using UnityEngine;

public abstract class CelestialBody : MonoBehaviour
{
    [Header("Datos del Cuerpo Celeste")]
    public string bodyName;
    public float scale = 1f;

    // Método abstracto que cada subclase implementa
    public abstract void UpdateMovement();

    protected virtual void Start()
    {
        transform.localScale = Vector3.one * scale;
    }

    void Update()
    {
        UpdateMovement();
    }
}