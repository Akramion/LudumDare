using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject prefabBullet;
    public GameObject fireHole;
    public float bulletSpeed;

    private Rigidbody2D rigidbody;

    public Camera cam;
    Vector2 mousePos;

    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>(); 
    }
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0)) {

        }

        if(Input.GetMouseButtonUp(0)) {
            Fire();
        }
    }

    void Snipe() {

    }


    void Fire() {
        Vector2 lookDir = mousePos - rigidbody.position;

        GameObject bullet = Instantiate(prefabBullet, fireHole.transform.position, fireHole.transform.rotation);
        Rigidbody2D rigidbodyBullet = bullet.GetComponent<Rigidbody2D>(); 

        rigidbodyBullet.AddForce(fireHole.transform.up * bulletSpeed, ForceMode2D.Impulse);
        
    }
}
