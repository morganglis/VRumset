using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1.75f;

    IEnumerator LoadLevel(string name)  // The level loader method takes a scene name as a string as a parameter
    {
        transition.SetTrigger("Start"); // Set our transition trigger

        yield return new WaitForSeconds(transitionTime);    // Gives a bit of time for the transition to occur

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);   // Load our scene

        while (!asyncLoad.isDone)   // Returns null until our scene has finished loading
        {
            yield return null;
        }
    }

    public void changeScene(string name)    // The change scene method starts a coroutine that takes in our load level method passed with a name of a scene as a string
    {
        StartCoroutine(LoadLevel(name));
    }
}
