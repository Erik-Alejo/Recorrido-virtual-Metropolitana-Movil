using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI; // Asigna el panel del menú de pausa
    public GameObject player; // Asigna el Player (para desactivar su control)
    private bool isPaused = false;

    void Update()
    {
        // Si quieres pausar también con la tecla ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Congela todo el tiempo del juego
        isPaused = true;

        if (player != null)
            player.GetComponent<CharacterController>().enabled = false; // Desactiva movimiento
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Restaura el tiempo del juego
        isPaused = false;

        if (player != null)
            player.GetComponent<CharacterController>().enabled = true; // Reactiva movimiento
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Restaura el tiempo antes de cambiar de escena
        SceneManager.LoadScene("MenuPrincipal"); // Usa el nombre real de tu escena del menú
    }
}
