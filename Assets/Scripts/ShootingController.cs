using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject prefabBullet;
    public GameObject fireHole;
    public float bulletSpeed;
    public GameObject linePrefab;

    private Rigidbody2D rigidbody;

    public Camera cam;
    Vector3 mousePos;

    public float spray;

    private void Start() {
        spray = 0.1f;
        
    }

    void Update()
    {


        if (Input.GetMouseButton(0)) {
            Snipe();
        }

        if(Input.GetMouseButtonUp(0)) {
            Fire();
        }
    }

    void Snipe() {
        spray -= 0.02f * Time.deltaTime;
        if(spray < 0) {
            spray = 0;
        } 
    }


    void Fire() {

        GameObject bullet = Instantiate(prefabBullet, fireHole.transform.position, fireHole.transform.rotation);
        Rigidbody2D rigidbodyBullet = bullet.GetComponent<Rigidbody2D>(); 
        Vector2 shootingVec = fireHole.transform.right;

        shootingVec.x = Random.Range(shootingVec.x + spray, shootingVec.x - spray);
        shootingVec.y = Random.Range(shootingVec.y + spray, shootingVec.y - spray);
        
        rigidbodyBullet.AddForce(shootingVec * bulletSpeed, ForceMode2D.Impulse);
        spray = 0.1f;
    }
}
