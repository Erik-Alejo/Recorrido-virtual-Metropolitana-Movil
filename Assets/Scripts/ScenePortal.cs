using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePortal : MonoBehaviour
{
    public string sceneToLoad;
    private bool isTransitioning = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTransitioning)
        {
            isTransitioning = true;

            // Busca FadeManager en la escena actual
            FadeManager fade = FindObjectOfType<FadeManager>();
            if (fade != null)
            {
                StartCoroutine(fade.FadeOutAndLoad(sceneToLoad));
            }
            else
            {
                Debug.LogWarning("No FadeManager found in the scene!");
                // Por seguridad, carga la escena sin fade
                StartCoroutine(LoadWithoutFade());
            }
        }
    }

    private IEnumerator LoadWithoutFade()
    {
        yield return new WaitForSeconds(2f); // Espera 1 segundo antes de cambiar
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
    }
}
