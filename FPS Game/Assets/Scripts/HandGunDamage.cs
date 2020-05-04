﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunDamage : MonoBehaviour

{
    public int DamageAmount;
    public float TargetDistance;
    public float AllowedRange = 15.0f;

    public RaycastHit hit;
    public GameObject TheBullet;
    public GameObject TheBlood;
    public GameObject TheBloodGreen;


    void Start()
    {
        DamageAmount = 5;
        
    }
    void Update()
    {
        if (GlobalAmmo.LoadedAmmo >= 1)
        {


            if (Input.GetButtonDown("Fire1"))
            {
                RaycastHit Shot;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
                {
                    TargetDistance = Shot.distance;
                    if (TargetDistance < AllowedRange)
                    {
                        
                        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
                        {
                            if (hit.transform.tag == "Zombie")
                            {
                                Instantiate(TheBlood, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                            }
                            if (hit.collider.tag == "ZombieHead")
                            {
                                DamageAmount = 10;
                                Instantiate(TheBlood, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                            }

                            if (hit.transform.tag == "Spider")
                            {
                                Instantiate(TheBloodGreen, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                            }
                            
                            if(hit.transform.tag == "Untagged") 
                            {

                                Instantiate(TheBullet, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                            }

                        }
                        Shot.transform.SendMessage("DeductPoints", DamageAmount, SendMessageOptions.DontRequireReceiver);
                        DamageAmount = 5;
                    }
                }
            }
        }
    }
}
    


