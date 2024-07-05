using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something entered the trigger area."); 

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger area."); 
            TransitionManager.instance.SwitchScene(sceneName);
        }
    }
}
