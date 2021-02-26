using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class footballer : MonoBehaviour
{
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] GameObject BallPrefab;
    [SerializeField] float ballSpeed = 15f;
    [SerializeField] float ShootTime = 2f;

    Vector2 randomPosition;

    public float xrange = 2f;

    float xMin, xMax, yMin, yMax;

    float padding = 0.5f;

    bool isShoot = false;
    
    Coroutine shootCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        setUpBorder();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();    
    }

    private void setUpBorder()
    {
        //setup of bounderies of movement according to camera
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0.09f, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 0.91f, 0)).y - padding;
    }

    private void Move()
    {
        //deltaX is the change of the x-axis of the player 
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        //deltaY is the change of the y-axis of the player ship
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        //newXPos= current position on x + differece moved in x-axis
        var newXPos = transform.position.x + deltaX;

        //newXPos= current position on y + differece moved in y-axis
        var newYPos = transform.position.y + deltaY;

        newXPos = Mathf.Clamp(newXPos, xMin, xMax);
        newYPos = Mathf.Clamp(newYPos, yMin, yMax);

        //moves the Player on the x-axis
        this.transform.position = new Vector2(newXPos, newYPos);
    }

    private void Shoot()
    {
        //when shoot is called spawn a ball 
        if (Input.GetButtonDown("Fire1"))
        {
            if (!isShoot)
            {
                shootCoroutine = StartCoroutine(ShootContinuously());
                isShoot = true;
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(shootCoroutine);
            isShoot = false;
        }
    }

    private IEnumerator ShootContinuously()
    {
        while (true)
        {
            GameObject Ball = Instantiate(BallPrefab, new Vector3(transform.position.x, (float)transform.position.y-1), Quaternion.identity) as GameObject;
            //give ball a velocity in the y-axis
            Ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, ballSpeed);
            float x = Random.Range(-2, 2) == 0 ? Random.Range(-2f,2f) : Random.Range(-2f,2f);

            yield return new WaitForSeconds(ShootTime);
        }
    }
}


