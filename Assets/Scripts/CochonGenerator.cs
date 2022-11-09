using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CochonGenerator : MonoBehaviour
{
    public GameObject Cochon;
    private float accumulateurTemps = 0.0f;
    public float tempsdistance = 10.0f;

    void Start()
    {
        Transform monCochon = Instantiate(Cochon, transform.position, Quaternion.identity).transform;
        Physics2D.IgnoreCollision(monCochon.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        accumulateurTemps += Time.fixedDeltaTime;

        if (accumulateurTemps > tempsdistance)
        {
            Transform monCochon = Instantiate(Cochon, transform.position, Quaternion.identity).transform;
            Physics2D.IgnoreCollision(monCochon.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());

            accumulateurTemps = 0.0f;
            float ratio = (Time.time + 5.0f) / 5.0f;
        }
    }
}
