using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour


{
    [SerializeField] DynamicJoystick joystick;

    [SerializeField] float smoothRotation = 0.1f;

    [SerializeField] LayerMask enviroLayerMask;

    [SerializeField] GameObject BoltPrefab;

    [SerializeField] GameObject boltContainer;

    [SerializeField] float fireRate;

    [SerializeField] GameObject viseur;

    Vector3 aimDirection;

    Rigidbody rb;
    GameManager gameManager;

    bool canShoot = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();

       // aimDirection = boltContainer.transform.forward;

    }
    void Start()
    {
       
    }

  

    void Update()
    {
        // Controles au joystick
        if(joystick.Direction.magnitude > 0)
        {
            viseur.SetActive(true);
            aimDirection = new Vector3(joystick.Direction.x * -1, 0f, joystick.Direction.y * -1).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection * 1, smoothRotation);
            canShoot = true;

        }
        else
        {
            if (canShoot == true)
            {
                Shoot();

                canShoot = false;
            }
       

        }

     
    }

 
    private void FixedUpdate()
    {

       
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(BoltPrefab, boltContainer.transform);
        //bullet.transform.position = new Vector3(0, 0, 0);
        bullet.GetComponent<Bolt>().ShootDirection(aimDirection);

        viseur.SetActive(false);

        gameObject.transform.forward = new Vector3(0,0,0);
    }


}
