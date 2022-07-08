using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionFade : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoad = 6f;
    [SerializeField]
    private string sceneNameToLoad;

    private float timeElapsed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if(timeElapsed>delayBeforeLoad){
            SceneManager.LoadScene(sceneNameToLoad);
        } 
    }
}
