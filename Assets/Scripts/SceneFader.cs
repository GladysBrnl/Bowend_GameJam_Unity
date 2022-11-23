using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image img;

    public AnimationCurve curve;

    private void Start()
    {
        StartCoroutine (FadeIn());
    }


    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    //FadeIn = écran noir vers scene (Disparition de l'écran noir)
    IEnumerator FadeIn()
    {
        float t = 1f;

        while(t > 0f)
        {
            t -= Time.deltaTime;

            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            //saute une frame : réduire le temps petit à petit
            yield return 0;
        }
    }

    //FadeOut =  scene vers écran noir (apparition de l'écran noir)
    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;

            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            //saute une frame : réduire le temps petit à petit
            yield return 0;
        }
         // le code ci dessous ne se lit que lorsque le fondu est terminé 
         SceneManager.LoadScene(scene);
    }

}
