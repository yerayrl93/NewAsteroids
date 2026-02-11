using System.Collections.Generic;
using UnityEngine;

public class BalaPool : MonoBehaviour
{
    public static BalaPool Instance;

    [Header("Configuración")]
    [SerializeField] private GameObject balaPrefab;
    [SerializeField] private int tamañoInicial = 20;

    private List<GameObject> poolDeBalas = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
       
        for (int i = 0; i < tamañoInicial; i++)
        {
            CrearNuevaBala();
        }
    }

    private GameObject CrearNuevaBala()
    {
        GameObject bala = Instantiate(balaPrefab);
        bala.SetActive(false); 
        poolDeBalas.Add(bala);
        return bala;
    }

    public GameObject GetBala()
    {
        
        foreach (GameObject bala in poolDeBalas)
        {
            if (!bala.activeInHierarchy)
            {
                return bala;
            }
        }

        
        return CrearNuevaBala();
    }
}