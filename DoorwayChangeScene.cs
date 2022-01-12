using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorwayChangeScene : MonoBehaviour
{

    //public string SceneName;

    public string sceneName;
    public GameObject TeleportSpot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneTransitionManager.Instance.GoToSceneAsync(sceneName);
            other.gameObject.transform.position = TeleportSpot.transform.position;
            //StartCoroutine(SceneTransitionManager.sceneTManager.GoToSceneAsyncRoutine(sceneIndex));
        }

    }

}
