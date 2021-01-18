using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 15f;

    float xMin, xMax;
    float padding = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        setUpMoveBounderies();
    }

    // Update is called once per frame
    void Update()
    {
        Move();       
    }

    private float AddNumbers(float n1, float n2, float n3)
    {
        return n1 + n2;
    }

    private void setUpMoveBounderies()
    {
        //setup of bounderies of movement according to camera
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0.09f, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(0.95f, 0, 0)).x - padding;
    }

    private void Move()
    {
        //deltaX is the change of the x-axis of the player 
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        //newXPos= current position on x + differece moved in x-axis
        var newXPos = transform.position.x + deltaX;

        newXPos = Mathf.Clamp(newXPos, xMin, xMax);

        //moves the Player on the x-axis
        this.transform.position = new Vector2(newXPos, transform.position.y);
    }
}


