using UnityEngine;

public class BuffCadencia : MonoBehaviour
{
    [SerializeField] private float duracionBuff = 5f;
    [SerializeField] private float velocidadRotacion = 100f;

    void Update()
    {
        
        transform.Rotate(Vector3.forward * velocidadRotacion * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           
            Jugador jugador = other.GetComponent<Jugador>();

            if (jugador != null)
            {
                jugador.AplicarBuffCadencia(duracionBuff);
            }

       
            gameObject.SetActive(false);
        }
    }
}