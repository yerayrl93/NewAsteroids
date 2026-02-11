using UnityEngine;

public class BuffSpawner : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] private GameObject prefabBuff;
    [SerializeField] private float tiempoEntreSpawns = 15f;

    private float limiteX;
    private float limiteY;

    void Start()
    {
   
        Camera cam = Camera.main;
        limiteY = cam.orthographicSize - 1f; 
        limiteX = (limiteY * cam.aspect) - 1f;

      
        InvokeRepeating("SpawnBuffAleatorio", tiempoEntreSpawns, tiempoEntreSpawns);
    }

    void SpawnBuffAleatorio()
    {
        if (prefabBuff == null) return;

      
        float posX = Random.Range(-limiteX, limiteX);
        float posY = Random.Range(-limiteY, limiteY);
        Vector3 posicionSpawn = new Vector3(posX, posY, 0f);

    
        GameObject buff = BuffPool.Instance.GetBuff();
        if (buff != null)
        {
            buff.transform.position = posicionSpawn; 
            buff.SetActive(true);
        }
    }
}