using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMouvement : MonoBehaviour
{
    [SerializeField] private float vitesse = 5;
    [SerializeField] private GameObject deathAnimation;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 direction;
    private bool deathAnimFinished = false;

    private bool enControle = true;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Loop");
        Debug.Log(enControle);
        if (enControle)
        {
            anim.SetFloat("Horizontal", direction.x);
            anim.SetFloat("Vertical", direction.y);
            anim.SetFloat("Vitesse", direction.sqrMagnitude);


            direction.x = Input.GetAxisRaw("Horizontal");
            direction.y = Input.GetAxisRaw("Vertical");



            if (direction.sqrMagnitude > 0.1)
            {
                anim.SetFloat("LastH", direction.x);
                anim.SetFloat("LastV", direction.y);
            }

            direction.Normalize();
            rb.velocity = direction * vitesse;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DeathSequence();
    }

    private void DeathSequence()
    {
        enControle = false;
        Instantiate(deathAnimation, transform.position, Quaternion.identity);
        StartCoroutine(Death());
        
       
        
    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("Dead", true);
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(FindObjectOfType<FonduAuNoir>().FadeOut());
    }
}
