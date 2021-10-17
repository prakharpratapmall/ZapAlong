using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class Health : MonoBehaviour
{
    PhotonView view;
    public GameObject gameOver;
    public int health = 10;
    public Text healthDisplay;
    // Start is called before the first frame update
    public void TakeDamage()
    {
        view.RPC("TakeDamageRPC",RpcTarget.All);
    }
    public void HealthUp()
    {
        view.RPC("HealthUpRPC",RpcTarget.All);
    }
    [PunRPC]
    void TakeDamageRPC()
    {
        health--;
        if(health<=0)
        {
            gameOver.SetActive(true);
        }
        healthDisplay.text = health.ToString();
    }
    [PunRPC]
    void HealthUpRPC()
    {
        if(health<10)
        health++;
        healthDisplay.text = health.ToString();
    }
    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
