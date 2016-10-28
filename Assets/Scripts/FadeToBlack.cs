using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour {
    Image fader;
	// Use this for initialization
	void Start () {
        FadeOut();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public IEnumerator FadeIn()
    {
        StopCoroutine("FadeOut");
        fader.color = Color.black;
        while (fader.color.a > 0)
        {
            fader.color = Color.Lerp(fader.color, Color.clear, 1 * Time.deltaTime);
            if (fader.color.a < 0.02f)
                fader.color = Color.clear;
            yield return null;
        }
    }

    public IEnumerator FadeOut()
    {
        StopCoroutine("FadeIn");
        fader.color = Color.clear;
        while (fader.color.a < 1)
        {
            fader.color = Color.Lerp(fader.color, Color.black, 1 * Time.deltaTime);
            if (fader.color.a > 0.98f)
                fader.color = Color.black;
            yield return null;
        }
    }
}
