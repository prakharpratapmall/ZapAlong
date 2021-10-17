using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public int score = 0;
    PhotonView view;
    public Text scoreDisplay;
    void Start()
    {
        view = GetComponent<PhotonView>();
    }
    public void AddScore()
    {
        Debug.Log("WTF");
        view.RPC("AddScoreRPC",RpcTarget.All);
    }

    [PunRPC]
    void AddScoreRPC()
    {
        score++;
        scoreDisplay.text = score.ToString();
    }
}
