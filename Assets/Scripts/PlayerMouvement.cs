using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    [SerializeField] private float vitesse = 5;
    [SerializeField] private GameObject deathAnimation;
    private Rigidbody2D rb;
    private Vector2 direction;
    private Vector2 lastDirection;
    private Animator anim;
    private bool enControle = true;
    [SerializeField]private GameObject roti;

    // Start is called before the first frame update
    void Start()
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
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        enControle = false;
        Destroy(this.gameObject);
        GameObject animation = Instantiate(deathAnimation, transform.position,Quaternion.identity);
        GameObject pouletRoti = Instantiate(roti, transform.position,Quaternion.identity);
        StartCoroutine(FinAnimation(animation));
        
        
    }

    private IEnumerator FinAnimation(GameObject deathAnimation)
    {
        yield return new WaitForSeconds(5f);
        Destroy(deathAnimation);
        
        
    }
}
