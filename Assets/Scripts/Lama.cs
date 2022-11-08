using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lama : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rig;
    private bool walking = false;
    private Vector2 direction;
    public GameObject cible;
    private Vector2 visionDirection;
    public float distanceVision = 5;
    public LayerMask masqueRaycast;
    public float speed = 3;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (walking)
        {
            anim.SetFloat("Speed", direction.magnitude);
            anim.SetFloat("Horizontal", direction.x);
            anim.SetFloat("Vertical", direction.y);
            rig.velocity = direction * speed;
        }
        else
        {
            rig.velocity = Vector2.zero;
            anim.SetFloat("Speed", 0.0f);
            
        }
    }

    private void FixedUpdate()
    {
        visionDirection = cible.transform.position - transform.position;
        visionDirection.Normalize();
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, visionDirection, distanceVision, masqueRaycast);
        if (hit.collider != null)
        {
            walking = false;
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Joueur"))
            {
                if (hit.collider.gameObject.GetComponent<PlayerMouvement>().enControle)
                {
                    direction = visionDirection;
                    walking = true;
                }
               
            }
        }
        else
        {
            walking = false;
        }

        


    }
}
