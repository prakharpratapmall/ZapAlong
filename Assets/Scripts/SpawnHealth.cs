using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnHealth : MonoBehaviour
{
    public GameObject player;
    public float minX,minY,maxX,maxY;
    float interval = 0f,startInterval = 12f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(interval<=0.0f)
        {
            Vector2 randomPosition = new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY));
            PhotonNetwork.Instantiate(player.name,randomPosition,Quaternion.identity);
            interval = startInterval;
        }
        else
        interval -= Time.deltaTime;
    }
}
