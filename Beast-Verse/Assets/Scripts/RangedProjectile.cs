using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedProjectile : MonoBehaviour
{

    public float damage;
    public GameObject target;

    public bool targetSet;
    public string targetType;
    public float velocity = 5;
    public bool stopProjectile;


    // Update is called once per frame
    void Update()
    {
        if(target){
            if(target == null){
                Destroy(gameObject);
            }
        }
    }
}
