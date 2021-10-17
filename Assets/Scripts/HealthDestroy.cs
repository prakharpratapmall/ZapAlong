using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class HealthDestroy : MonoBehaviour
{
    Health healthscript;
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        healthscript = GetComponent<Health>();
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if(collision.tag == "Player")
            {
                
                //view.RPC("SpawnParticle",RpcTarget.All);
                PhotonNetwork.Destroy(this.gameObject);
                //CameraShake.Instance.ShakeCamera(5.0f,0.4f);
                healthscript.HealthUp();

            }
        }

    }
}
