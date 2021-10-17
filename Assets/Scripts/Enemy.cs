using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Enemy : MonoBehaviour
{
    PlayerController[] players;
    PlayerController nearestPlayer;
    public float speed = 1.5f;
    GameObject score;
    public GameObject deathFX;
    PhotonView view;
    float minDist = 1000.0f;
    int minDistIndex = 0;
    void Start()
    {
        view = GetComponent<PhotonView>();
        players = FindObjectsOfType<PlayerController>();
        score = GameObject.FindGameObjectWithTag("Score");
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        for( i=0;i<players.Length;i++)
        {
             float dist = Vector2.Distance(transform.position,players[i].transform.position);
             if(dist<minDist)
             {
                 minDist = dist;
                 minDistIndex = i;
             }
        }
        nearestPlayer = players[minDistIndex]; 
        if(nearestPlayer!=null)
        {
            transform.position = Vector2.MoveTowards(transform.position,nearestPlayer.transform.position,speed*Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(PhotonNetwork.IsMasterClient)
        {
            if(collision.tag == "GoldenRay")
            {
                
                view.RPC("SpawnParticle",RpcTarget.All);
                PhotonNetwork.Destroy(this.gameObject);
                CameraShake.Instance.ShakeCamera(6.0f,0.6f);
                (score.GetComponent<Score>()).AddScore();
            }
        }

    }
    [PunRPC]
    void SpawnParticle()
    {
        Instantiate(deathFX, transform.position, Quaternion.identity);
    }
}
