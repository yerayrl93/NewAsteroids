using UnityEngine;

public class balaEnemiga : MonoBehaviour
{
    [SerializeField] private float tiempoDeVida = 4f;

    private void OnEnable()
    {
        
        Invoke("Desactivar", tiempoDeVida);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      
        if (other.CompareTag("Asteroide") || other.CompareTag("EnemigoNave")) return;

        if (other.CompareTag("Player"))
        {
            Jugador scriptJugador = other.GetComponent<Jugador>();
            if (scriptJugador != null) scriptJugador.TomarDaño();
            Desactivar();
        }

        if (other.CompareTag("Limite"))
        {
            Desactivar();
        }
    }

    private void Desactivar()
    {
        gameObject.SetActive(false);
    }
}