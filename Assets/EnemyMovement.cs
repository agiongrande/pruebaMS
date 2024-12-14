using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    int speed = 5;
    GameObject player;
    [SerializeField] int distanceToFollow;
    [SerializeField] int health = 5;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);

        //transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);

        if (Vector3.Distance(player.transform.position, transform.position) < distanceToFollow)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;

            transform.Translate(direction * Time.deltaTime * speed, Space.World);
        }

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);  //Bala
            health = health - 1;
            if(health == 0)
            {
                
                health = 5;            //Este objeto (enemigo)
            }    
            
        }
    }


}
