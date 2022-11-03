using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    [SerializeField] private float vitesse = 5;
    private Rigidbody2D rb;
    private Vector2 direction;
    private Vector2 lastDirection;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Horizontal", direction.x);
        anim.SetFloat("Vertical", direction.y);
        anim.SetFloat("Vitesse", direction.sqrMagnitude);


        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        Debug.Log(direction.x);
        Debug.Log(direction.y);

        if (direction.sqrMagnitude > 0.1)
        {
            anim.SetFloat("LastH", direction.x);
            anim.SetFloat("LastV", direction.y);
        }

        rb.velocity = direction * vitesse;
    }
}
