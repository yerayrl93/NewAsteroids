using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Configuración de Nivel")]
    public int nivelActual = 1;
    public int asteroidesBase = 2;
    public float multiplicadorVelocidad = 1f;
    private int puntos = 0;
    private bool cambiandoDeNivel = false; //ARREGLAMOS BUG DE LOS NIVELES

    [Header("Interfaz (UI)")]
    [SerializeField] private TextMeshProUGUI textoNivel;
    [SerializeField] private TextMeshProUGUI textoPuntos;
    private AsteroideSpawner spawner;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        spawner = FindFirstObjectByType<AsteroideSpawner>();
        StartCoroutine(IniciarNuevoNivel());
    }

    public void GanarPuntos(int cantidad)
    {
        puntos += cantidad;
        textoPuntos.text = "SCORE: " + puntos;
    }

    public IEnumerator IniciarNuevoNivel()
    {
        cambiandoDeNivel = true; 

        textoNivel.text = "NIVEL " + nivelActual;
        textoNivel.gameObject.SetActive(true);

        Jugador player = FindFirstObjectByType<Jugador>();
        if (player != null) player.ActivarEscudoTemporal(3f);

        yield return new WaitForSeconds(2f);
        textoNivel.gameObject.SetActive(false);

        int cantidadASpawnear = asteroidesBase + nivelActual;
        for (int i = 0; i < cantidadASpawnear; i++)
        {
            if (spawner != null) spawner.SpawnIndividual();
        }

      
        yield return new WaitForSeconds(1f);
        cambiandoDeNivel = false;
    }

    public void CheckNivelCompletado()
    {
       
        if (cambiandoDeNivel) return;

    
        StartCoroutine(ValidarEnemigosCorrutina());
    }

    private IEnumerator ValidarEnemigosCorrutina()
    {
       
        yield return new WaitForEndOfFrame();

      
        GameObject[] asteroides = GameObject.FindGameObjectsWithTag("Asteroide");
        int contadorAsteroides = 0;
        foreach (GameObject ast in asteroides)
        {
            if (ast.activeInHierarchy) contadorAsteroides++;
        }

      
        GameObject[] naves = GameObject.FindGameObjectsWithTag("EnemigoNave");
        int contadorNaves = 0;
        foreach (GameObject nave in naves)
        {
          
            if (nave.activeInHierarchy) contadorNaves++;
        }

     
        if (contadorAsteroides == 0 && contadorNaves == 0 && !cambiandoDeNivel)
        {
            cambiandoDeNivel = true;
            nivelActual++;

        
            if (multiplicadorVelocidad < 2.5f) multiplicadorVelocidad += 0.15f;

            StartCoroutine(IniciarNuevoNivel());
        }
    }

    public void Morir()
    {
        PlayerPrefs.SetInt("PuntajeFinal", puntos);
        PlayerPrefs.SetInt("NivelFinal", nivelActual);
        SceneManager.LoadScene("Final");
    }
}