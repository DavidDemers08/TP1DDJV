using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cochon : MonoBehaviour
{
    public int orientation;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
         anim = GetComponent<Animator>();

        if (orientation == 1)
        {
            anim.SetFloat("Vertical", 1);
        }
        if (orientation == 2)
        {
            anim.SetFloat("Vertical", -1);
        }
        if (orientation == 3)
        {
            anim.SetFloat("Horizontal", 1);
        }
        if (orientation == 4)
        {
            anim.SetFloat("Horizontal", -1);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (orientation == 1)
        {
            transform.Translate(new Vector3(0.0f, 1f * Time.fixedDeltaTime, 0.0f));
        }

        if (orientation == 2)
        {
            transform.Translate(new Vector3(0.0f, -1f * Time.fixedDeltaTime, 0.0f));
        }

        if (orientation == 3)
        {
            transform.Translate(new Vector3(1f * Time.fixedDeltaTime, 0.0f, 0.0f));
        }

        if (orientation == 4)
        {
            transform.Translate(new Vector3(-1f * Time.fixedDeltaTime, 0.0f, 0.0f));
        }

    }
}
