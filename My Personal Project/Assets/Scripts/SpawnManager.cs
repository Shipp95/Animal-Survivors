using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static int waveNumber;
    int animalCount;
    [SerializeField] GameObject[] animalTypes;
    [SerializeField] GameObject powerUp;
    [SerializeField] GameObject gold;
    [SerializeField] GameObject player;
    GameObject[] AnimalArray;

    // Start is called before the first frame update
    void Start()
    {
        //when the game starts, the spawn manager will start creating power ups and spawn 1 enemy for wave nr 1
        player = GameObject.Find("Player");
        waveNumber = 1;
        InvokeRepeating("SpawnPowerUp", 5, 5);
        SpawnAnimal(1);
        
    }

    // Update is called once per frame
    void Update()
    {
        //check how many enemies is currently in the game, if player is alive and there are no more enemies, spawn next wave
        animalCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        
        if (animalCount == 0 && Player.health > 1)
        {
            waveNumber++;
            SpawnAnimal(waveNumber);

        }
        if (Player.health < 1)
        {
            DestroyAnimals();
        }
    }
    void SpawnAnimal(int howMany)   //create a random position and spawn an animal
    {
            for (int i = 0; i < howMany; i++)
            {
                int whatAnimal;
                Vector3 spawnPosition;
                spawnPosition = new Vector3(Random.Range(-25, 25), 0.5f, Random.Range(-25, 25));
                whatAnimal = Random.Range(0, animalTypes.Length);
                Instantiate(animalTypes[whatAnimal], spawnPosition, animalTypes[whatAnimal].transform.rotation);
        }
    }
    void SpawnPowerUp() //spawn a power up in random position depending on player's health
    {
        Vector3 spawnPosition;
        spawnPosition = new Vector3(Random.Range(-17, 17), 2f, Random.Range(-17, 17));
        if (Player.health < 3)
        {
            Instantiate(powerUp, spawnPosition, powerUp.transform.rotation);
        }
        else if (Player.health == 3)
        {
            Instantiate(gold, spawnPosition, powerUp.transform.rotation);
        }
    }
    void DestroyAnimals() // create an array with every animal and destroy them
    {
        AnimalArray = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject animal in AnimalArray)
        {

            Destroy(animal);
        }
    }
}
