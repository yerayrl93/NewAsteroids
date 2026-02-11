using UnityEngine;

public class Bala : MonoBehaviour
{
    [Header("Ajustes de Bala")]
    [SerializeField] private float velocidad = 15f;
    [SerializeField] private float tiempoVida = 2f;

    private Rigidbody2D rb;

    private void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
   
        if (rb != null)
        {
            rb.linearVelocity = transform.up * velocidad;
        }

  
        Invoke("Desactivar", tiempoVida);
    }

    private void OnDisable()
    {
   
        CancelInvoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.CompareTag("Asteroide") || collision.CompareTag("EnemigoNave") || collision.CompareTag("BalaEnemigo"))
        {
            Desactivar();
        }
    }

    private void Desactivar()
    {
       
        gameObject.SetActive(false);
    }
}