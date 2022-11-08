using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CochonGenerator : MonoBehaviour
{
    public GameObject Cochon;
    private float accumulateurTemps = 0.0f;
    public float tempsdistance = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Cochon, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        accumulateurTemps += Time.fixedDeltaTime;

        if (accumulateurTemps > tempsdistance)
        {
            // chronometre facon vieille ecole frere.
            Instantiate(Cochon, transform.position, Quaternion.identity);
            accumulateurTemps = 0.0f;
            float ratio = (Time.time + 5.0f) / 5.0f;

            //temps = Random.Range(0.3f, 1.0f);
        }


    }
}
