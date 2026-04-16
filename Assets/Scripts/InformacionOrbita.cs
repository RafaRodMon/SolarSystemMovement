using UnityEngine;

[CreateAssetMenu(fileName = "OrbitData", menuName = "SolarSystem/OrbitData")]
public class OrbitData : ScriptableObject
{
    public float semiMajorAxis = 20f;
    public float semiMinorAxis = 18f;
    public float orbitalPeriod = 365f;
    public float orbitalInclination = 0f;
    public float initialAngle = 0f;
}