using System.Collections.Generic;
using UnityEngine;

public class SolarSystemManager : MonoBehaviour
{
    [Header("Colecciones del Sistema Solar")]
    public List<Planet> planets = new List<Planet>();   // Los 8 planetas
    public Star sun;
    public List<Moon> moons = new List<Moon>();

    [Header("Control Global")]
    [Range(0f, 500f)]
    public float globalTimeScale = 10f;
    public bool paused = false;

    void Start()
    {
        // Auto-detecta todos los planetas de la escena
        planets.AddRange(FindObjectsOfType<Planet>());
        moons.AddRange(FindObjectsOfType<Moon>());

        Debug.Log($"Sistema Solar iniciado: {planets.Count} planetas, {moons.Count} lunas.");
    }

    void Update()
    {
        HandleInput();
        SyncTimeScale();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space)) paused = !paused;
        if (Input.GetKey(KeyCode.Equals)) globalTimeScale += 10f * Time.deltaTime;
        if (Input.GetKey(KeyCode.Minus)) globalTimeScale = Mathf.Max(0, globalTimeScale - 10f * Time.deltaTime);
    }

    void SyncTimeScale()
    {
        float scale = paused ? 0f : globalTimeScale;
        foreach (Planet p in planets) p.timeScale = scale;
        foreach (Moon m in moons) m.timeScale = scale;
    }
}