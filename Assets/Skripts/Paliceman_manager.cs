using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Paliceman_manager : MonoBehaviour
{


    public float speed;
    Animator anim;
    Transform Target;
    [SerializeField]
    int speedUp = 0;
    bool stopRun = false;
    [SerializeField]
    Transform[] points = { };
    private void Start()
    {
        Target = points[0];
        anim = GetComponent<Animator>();
    }

    private void LateUpdate()
    {

        if (!stopRun)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
            if (transform.position == points[0].position)
            {
                Target = points[1];
                speed *= speedUp;
                transform.Rotate(Vector3.up * -90);
                anim.SetInteger("State", 1);
            }
            if (transform.position == points[1].position)
            {
                Target = points[2];
                speed /= speedUp;
                transform.Rotate(Vector3.up * -90);
                anim.SetInteger("State", 0);
            }
            if (transform.position == points[2].position)
            {
                Target = points[3];
                speed *= speedUp;
                transform.Rotate(Vector3.up * -90);
                anim.SetInteger("State", 1);
            }

            if (transform.position == points[3].position)
            {
                stopRun = true;
                anim.SetInteger("State", 2);
            }

        }


    }
}
