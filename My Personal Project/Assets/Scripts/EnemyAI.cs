using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] int hp;
    [SerializeField] float speed;
    [SerializeField] int pointsValue;
    [SerializeField] GameObject player;
    [SerializeField] Rigidbody enemyRb;
    [SerializeField] ParticleSystem explosion;

    void Start()
    {
        //enemy's speed increases with every wave based on wave number
        speed = speed + 0.3f*SpawnManager.waveNumber;
        //ignore collision between other enemies
        Physics.IgnoreLayerCollision(3, 3);

        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Define a vector towards player and move in this direction. The vector is normalized
        //in order to make movement speed independent from distance between objects.
        Vector3 playerDirection = (player.transform.position - gameObject.transform.position).normalized;
        transform.Translate(playerDirection * speed * Time.deltaTime, Space.World);
        
        if(hp < 1) 
        { 
            Die(); 
        }
    }
    private void LateUpdate()
    {
        transform.LookAt(player.transform);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            DealDmg();
            //when enemy collides with the player, deal damage to the player and bounce back the enemy
            Vector3 bounceDirection = transform.forward;
            bounceDirection.y = 0;
            transform.Translate((-bounceDirection)*5);


        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //colision with projectiles plays a sound effect unique to each enemy and turns them red for a brief moment
        if (other.gameObject.CompareTag("Projectile"))
        {
            GetComponent<AudioSource>().Play();
            hp--;
            StartCoroutine(Oof());
            Destroy(other.gameObject);
        }
    }


    private void DealDmg()
    {
        Player.health--;
    }
    void Die()
    {
        //add points to player, create explosion particle that dissapears after 0,5 second
        Player.score = Player.score + pointsValue;
        Instantiate(explosion,gameObject.transform.position,gameObject.transform.rotation);
        Destroy(gameObject);

    }
    IEnumerator Oof()
    {
        //change color to red and go back to original after fixed time
        Color initial = GetComponentInChildren<Renderer>().material.color;
        GetComponentInChildren<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(.5f);
        GetComponentInChildren<Renderer>().material.color = initial;
    }
}
