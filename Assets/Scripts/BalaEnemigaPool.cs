using System.Collections.Generic;
using UnityEngine;

public class BalaEnemigaPool : MonoBehaviour
{

    public static BalaEnemigaPool Instance;

    [Header("Configuración del Pool")]
    [SerializeField] private GameObject prefabBalaEnemiga;
    [SerializeField] private int tamanoInicial = 10;

    private List<GameObject> poolDeBalas = new List<GameObject>();

    private void Awake()
    {
        
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
    
        for (int i = 0; i < tamanoInicial; i++)
        {
            CrearNuevaBala();
        }
    }

    private GameObject CrearNuevaBala()
    {
        GameObject bala = Instantiate(prefabBalaEnemiga);
        bala.SetActive(false);
       
        bala.transform.SetParent(this.transform);
        poolDeBalas.Add(bala);
        return bala;
    }

    public GameObject GetBalaEnemiga()
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