using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 25f;
    [SerializeField] float baseSpeed = 15f;

    Rigidbody2D r2d;
    SurfaceEffector2D se2D;
    bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        
        se2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondtoBoost();
        }
        
    }

    public void DisableControl()
    {
        canMove = false;
    }

    private void RespondtoBoost()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            se2D.speed = boostSpeed;
        }
        else
        {
            se2D.speed = baseSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            r2d.AddTorque(torqueAmount);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            r2d.AddTorque(-torqueAmount);
        }
    }
}
