using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private VolumetricLines.VolumetricLineBehavior laser;
    private float angle;
    private float rayon;
    // Start is called before the first frame update
    void Start()
    {
        laser = GetComponent<VolumetricLines.VolumetricLineBehavior>();
        laser.StartPos = new Vector3(0.0f, 0, 0.0f);
        laser.EndPos = new Vector3(0f, 5, 0.0f);

        rayon = 5;

    }

    // Update is called once per frame
    void Update()
    {
        angle += 0.005f;
        if (angle >= 360)
        {
            angle = 0;
        }
        Debug.Log(angle);

        laser.EndPos = new Vector2(rayon * Mathf.Sin(angle), rayon * Mathf.Cos(angle));

        RaycastHit2D hit = Physics2D.Raycast(laser.StartPos, laser.EndPos,rayon);

        if (hit.collider != null)
        {
            laser.EndPos = hit.point;
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Joueur"))
            {
                hit.collider.gameObject.GetComponent<PlayerMouvement>().LaserHit();
            }
        }

        

        Debug.DrawLine(laser.StartPos, laser.EndPos);
    }
}
