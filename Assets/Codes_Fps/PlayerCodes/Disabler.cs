using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disabler : MonoBehaviourPunCallbacks
{
    public PhotonView Pv;
    [Space]
    public Move _move;
    public Players _players;
    public PhysicsCont _physicsCont;
    public PlayerColliders _playerColliders;
    public GameObject _camHolder;
    public TargetPos _targetPos;
    public List<Shoot> ShotScripts;

    void Update()
    {
        if (!photonView.IsMine)
        {
            _players.enabled = false;
            _move.enabled = false;
            _physicsCont.enabled = false;
            _playerColliders.enabled = false;
            _camHolder.SetActive(false);
            _targetPos.enabled=false;
            for (int i = 0; i < ShotScripts.Count; i++)
            {
                ShotScripts[i].enabled=false;
            }
        }
    }
}
