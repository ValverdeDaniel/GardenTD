using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float rotationSpeed = 360f;
    [SerializeField] float damage = 50;

    //[SerializeField] float speedOfSpin = 360f;
    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity += new Vector2(moveSpeed, 0);
    }

    void Update()
    {
        //transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        //transform.Rotate(0, 0, speedOfSpin * Time.deltaTime);

        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));

    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();
        
        if(attacker && health)
        {            
            //reduce health
            health.DealDamage(damage);
            Destroy(gameObject);
        }

    }

}
