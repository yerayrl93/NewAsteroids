using UnityEngine;
using UnityEngine.SceneManagement; 

public class ControladorMenu : MonoBehaviour
{
    
    public void CargarJuego()
    {
        SceneManager.LoadScene("Asteroids");
    }

  
    public void IrAlCine()
    {
        SceneManager.LoadScene("EscenaCine");
    }

  
    public void IrAlMenu()
    {
        SceneManager.LoadScene("Menu"); 
    }

  
    public void SalirDelJuego()
    {
        Debug.Log("Cerrando el juego...");
        Application.Quit();
    }
}