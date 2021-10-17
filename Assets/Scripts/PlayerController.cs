using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public float speed = 2.0f;
    float resetSpeed;
    public float dashSpeed;
    public float dashTime;

    PhotonView view;
    Health healthscript;
    LineRenderer line;
    public float minX,minY,maxX,maxY;
    public Text nameDisplay;
    public GameObject deathFX;
    void Start()
    {
        resetSpeed = speed;
        view = GetComponent<PhotonView>();
        healthscript = FindObjectOfType<Health>();
        line = FindObjectOfType<LineRenderer>();
        if(view.IsMine)
        {
            nameDisplay.text = PhotonNetwork.NickName;
        }
        else
        {
            nameDisplay.text = view.Owner.NickName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(view.IsMine)
        {
            Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
            transform.position += (Vector3)moveInput.normalized * speed * Time.deltaTime;
            line.SetPosition(0,transform.position);
            Wrap();
            if(Input.GetKeyDown(KeyCode.Space)&&moveInput!= Vector2.zero)
            {
                StartCoroutine(Dash());
            }
        }
        else
        {
            line.SetPosition(1,transform.position);
        }
        
    }
    IEnumerator Dash()
    {
        speed = dashSpeed;
        yield return new WaitForSeconds(dashTime);
        speed = resetSpeed;
    }
    void Wrap()
    {
        if(transform.position.x<minX)
        {
            transform.position = new Vector2(maxX,transform.position.y);
        }
        if(transform.position.x>maxX)
        {
            transform.position = new Vector2(minX,transform.position.y);
        }
        if(transform.position.y<minY)
        {
            transform.position = new Vector2(transform.position.x,maxY);
        }
        if(transform.position.y>maxY)
        {
            transform.position = new Vector2(transform.position.x,minY);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(view.IsMine)
        {
            if(collision.tag == "Enemy")
            {
                view.RPC("SpawnParticle",RpcTarget.All);
                healthscript.TakeDamage();
                CameraShake.Instance.ShakeCamera(2.0f,0.4f);
            }
            
        }
    }
    [PunRPC]
    void SpawnParticle()
    {
        Instantiate(deathFX, transform.position, Quaternion.identity);
    }
}
