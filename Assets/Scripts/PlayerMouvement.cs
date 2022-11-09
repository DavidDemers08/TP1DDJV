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
    private bool celebGauche = false;
    private bool celebDroite = false;


    public bool enControle = true;
    private int index;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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

        if (celebGauche)
        {
            rb.velocity = new Vector2(-1, 0) * vitesse;
        }

        if (celebDroite)
        {
            rb.velocity = new Vector2(0.5f, 0) * vitesse;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ennemi"))
        {
            DeathSequence();
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Oeuf"))
        {
            StartCoroutine(NextLevel());
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("DouzaineOeuf"))
        {
            StartCoroutine(Celebration());
        }

    }

    private IEnumerator NextLevel()
    {
        StartCoroutine(FindObjectOfType<FonduAuNoir>().FadeOut());
        yield return new WaitForSeconds(1);
        index = SceneManager.GetActiveScene().buildIndex;
        index++;

        SceneManager.LoadScene(index);
    }

    public void LaserHit()
    {
        if (!enControle)
        {
            return;
        }
        DeathSequence();
    }

    private void DeathSequence()
    {
        enControle = false;
        Instantiate(deathAnimation, transform.position, Quaternion.identity);
        StartCoroutine(Death());
    }

    private IEnumerator Celebration()
    {
        enControle = false;

        anim.SetFloat("Vitesse", 1);
        anim.SetFloat("Horizontal", -1);
        celebGauche = true;
        yield return new WaitForSeconds(1f);
        anim.SetFloat("Vitesse", 0);
        anim.SetFloat("LastH", -1);
        celebGauche = false;
        yield return new WaitForSeconds(1f);
        anim.SetFloat("Vitesse", 1);
        anim.SetFloat("Horizontal", 1);
        celebDroite = true;
        yield return new WaitForSeconds(1f);
        anim.SetFloat("Vitesse", 0);
        anim.SetFloat("LastH", 1);
        celebDroite = false;
        yield return new WaitForSeconds(1f);
        anim.SetFloat("LastH", 0);
        anim.SetFloat("LastV", -1);
        StartCoroutine(FadeIN());

    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("Dead", true);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);

    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(FindObjectOfType<FonduAuNoir>().FadeOut());
        
    }

    private IEnumerator FadeIN()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(FindObjectOfType<FonduAuNoir>().FadeIn());
        SceneManager.LoadScene(0);
    }
}
