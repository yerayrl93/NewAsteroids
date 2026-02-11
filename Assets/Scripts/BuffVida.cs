using UnityEngine;

public class BuffVida : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        Debug.Log("Vida tocada por: " + other.name + " con Tag: " + other.tag);

   
        if (other.CompareTag("Jugador") || other.CompareTag("Player"))
        {
            Jugador jug = other.GetComponent<Jugador>();
            if (jug != null)
            {
                jug.RecuperarVida();
                Debug.Log("¡Vida entregada con éxito!");
            }

            gameObject.SetActive(false); 
        }
    }
}