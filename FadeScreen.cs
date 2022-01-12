using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    public bool fadeOnStart = true;
    // establishing the variables.
    public float fadeDuration = 2f;
    public Color fadeColor;
    private Renderer rend;

     void Start()
    {
        //at the start of this script rend will grab the Renderer components
        rend = GetComponent<Renderer>();
        if(fadeOnStart)
        {
            FadeIn();
        }

    }

    // run the function Fade In
    public void FadeIn()
    {
        //in the function fade in, variable 1,0 are inserted
        Fade(0, 1);
    }

    public void FadeOut()
    {
        //in the function fade out, variable 0,1 are inserted
        Fade(1, 0);

    }

    // fade function that takes in two numbers for alpha in and out. 
    public void Fade(float alphaIn, float alphaOut)
    {
        //system will start a couroutine called faderoutine that takes in variable alphaIn & alphaout
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    // Ienumerator function takes two float variables. 
    public IEnumerator FadeRoutine(float alphaIn, float alphaout)
    {
        // setting timer to 0
        float timer = 0;
        //while the timer is less than or equal to fade duration variable
        while(timer <= fadeDuration)
        {
            // variable "newColoer" will equal the fadeColor.
            Color newColor = fadeColor;
            //the newColoer alpha will then go through a Lerp function that takes in a value of 0 or 1
            newColor.a = Mathf.Lerp(alphaIn, alphaout, timer / fadeDuration);
            // rend the new material
            rend.material.SetColor("_Color", newColor);
            // increase the timer
            timer += Time.deltaTime;
            yield return null;

        }
        // at the end of the loop, newcolor2 will equal the final fadecoloer
        Color newColor2 = fadeColor;
        // accessing the alpha value of the newcolor2
        newColor2.a = alphaout;
        // displaying the newcoloer2 coloer. 
        rend.material.SetColor("_Color", newColor2);

    }


}
