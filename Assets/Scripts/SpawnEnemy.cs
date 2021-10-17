using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnEnemy : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemy;
    public float startTimeBtwSpawns = 3.0f;
    float timeBtwSpawns;
    // Start is called before the first frame update
    void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if(PhotonNetwork.IsMasterClient == false ||PhotonNetwork.CurrentRoom.PlayerCount<=1)
        return;
        if(timeBtwSpawns<=0)
        {
            Vector3 spawnPosition = spawnPoints[Random.Range(0,spawnPoints.Length)].position;
            PhotonNetwork.Instantiate(enemy.name,spawnPosition,Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
