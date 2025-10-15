using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;
    private string targetSpawnName;

    private void Awake()
    {
        // Asegurarse de que solo exista una instancia
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Se ejecuta cada vez que una escena nueva se carga
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Método que se llama desde ScenePortal
    public void LoadScene(string sceneName, string spawnPointName)
    {
        targetSpawnName = spawnPointName;
        SceneManager.LoadScene(sceneName);
    }

    // Se ejecuta automáticamente después de cargar una nueva escena
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (string.IsNullOrEmpty(targetSpawnName))
            return;

        // Buscar el punto de aparición y el jugador
        GameObject spawnPoint = GameObject.Find(targetSpawnName);
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // Si ambos existen, reposicionar al jugador
        if (spawnPoint != null && player != null)
        {
            player.transform.position = spawnPoint.transform.position;
            player.transform.rotation = spawnPoint.transform.rotation;
        }
        else
        {
            Debug.LogWarning("Spawn point o Player no encontrado en la escena: " + scene.name);
        }

        // Limpiar para evitar errores en futuras cargas
        targetSpawnName = null;
    }
}
