using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class VidaPool : MonoBehaviour
{
    public static VidaPool Instance;

    [Header("Configuración")]
    [SerializeField] private GameObject vidaPrefab;
    [SerializeField] private int vidasIniciales = 5; 

    private List<GameObject> poolVidas = new List<GameObject>();

    private void Awake() => Instance = this;

    void Start()
    {
      
        for (int i = 0; i < vidasIniciales; i++)
        {
            GameObject icono = Instantiate(vidaPrefab, transform);
            poolVidas.Add(icono);
        }
    }

    public void RestarVidaVisual()
    {
       
        for (int i = poolVidas.Count - 1; i >= 0; i--)
        {
            if (poolVidas[i].activeSelf)
            {
                poolVidas[i].SetActive(false);
                break;
            }
        }
    }

    public void SumarVidaVisual()
    {
        
        for (int i = 0; i < poolVidas.Count; i++)
        {
            if (!poolVidas[i].activeSelf)
            {
                poolVidas[i].SetActive(true);
                return; 
            }
        }

       
        GameObject nuevoIcono = Instantiate(vidaPrefab, transform);
        poolVidas.Add(nuevoIcono);
    }
}