using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : Singleton<SceneTransitionManager>
{
    public FadeScreen fadeScreen;

    // initialize
    void Start()
    {
        // load level with the name ....
        StartCoroutine(GoToSceneAsyncRoutine("Time Room"));

    }


    // load 
    public void GoToSceneAsync(string sceneName) //Load level...
    {
        StartCoroutine(GoToSceneAsyncRoutine(sceneName));
    }


    public IEnumerator GoToSceneAsyncRoutine(string sceneName)
    {
        fadeScreen.FadeIn();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);
       
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        operation.allowSceneActivation = false;

        float timer = 0;
        while(timer <= fadeScreen.fadeDuration && !operation.isDone)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        operation.allowSceneActivation = true;

        StartCoroutine(UnloadLevels(sceneName));
    }

    // unload all levels except "Exception" and the VRMain Scene (Persistance) 
    private IEnumerator UnloadLevels(string exception)
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);

        for (int i = 0; i < SceneManager.sceneCount; i ++)
        {
            if(SceneManager.GetSceneAt(i).name != exception && SceneManager.GetSceneAt(i).name != "Persistance")
            {
                SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(i).name);
            }

        }
    }
}
