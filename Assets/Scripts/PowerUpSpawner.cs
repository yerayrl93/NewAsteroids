using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject vidaPrefab;
    public float tiempoMin = 10f; 
    public float tiempoMax = 20f; 
    public float radioSpawn = 8f;

    void Start()
    {
       
        Invoke("SpawnVida", Random.Range(tiempoMin, tiempoMax));
    }

    void SpawnVida()
    {
        
        Vector2 posicionAleatoria = Random.insideUnitCircle * radioSpawn;

        
        Instantiate(vidaPrefab, posicionAleatoria, Quaternion.identity);

     
        Invoke("SpawnVida", Random.Range(tiempoMin, tiempoMax));
    }
}