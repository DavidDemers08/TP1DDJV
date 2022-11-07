using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FonduAuNoir : MonoBehaviour
{
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        StartFadeIn();
    }

    private void StartFadeIn()
    {
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        Color col = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        sprite.color = col;
        for (float a = 1.0f; a > 0.0f; a -= 0.05f)
        {
            col.a = a;
            sprite.color = col;
            yield return new WaitForSeconds(.02f);
        }
        col.a = 0.0f;
        sprite.color = col;
    }

    public IEnumerator FadeOut()
    {
        Color col = new(0.0f, 0.0f, 0.0f, 1.0f);
        sprite.color = col;
        for (float a = 0; a < 1; a += 0.05f)
        {
            col.a = a;
            sprite.color = col;
            yield return new WaitForSeconds(.02f);
        }
        col.a = 1f;
        sprite.color = col;

        SceneManager.LoadScene(0);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
