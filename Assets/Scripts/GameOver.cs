using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class GameOver : MonoBehaviour
{
    public Text scoreDisplay;
    public GameObject restartButton;
    public GameObject waitingText;
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        scoreDisplay.text = FindObjectOfType<Score>().score.ToString();
        Debug.Log("Score"+ FindObjectOfType<Score>().score.ToString());
        if(PhotonNetwork.IsMasterClient == false)
        {
            restartButton.SetActive(false);
            waitingText.SetActive(true);
        }
        PhotonNetwork.MinimalTimeScaleToDispatchInFixedUpdate = 0.01f;
        Time.timeScale = 0.02f;
    }
    public void OnClickReturn()
    {
        Time.timeScale = 1f;
        PhotonNetwork.LeaveLobby();
        PhotonNetwork.LoadLevel("Main Menu");

    }
    public void OnClickRestart()
    {
        view.RPC("RestartRPC",RpcTarget.All);
    }
    [PunRPC]
    void RestartRPC()
    {
        Time.timeScale = 1f;
        PhotonNetwork.LoadLevel("Game");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
