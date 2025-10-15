using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePortal : MonoBehaviour
{
    //[Header("Scene transition settings")]
    public string targetSceneName;
    public string targetSpawnPointName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneTransitionManager.Instance.LoadScene(targetSceneName, targetSpawnPointName);
        }

    }
}
