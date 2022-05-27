using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disabler : MonoBehaviourPunCallbacks
{
   
    [Space]
    public Move _move;
    public Players _players;
    public PhysicsCont _physicsCont;
    public PlayerColliders _playerColliders;
    public GameObject _cam;
    public TargetPos _targetPos;
    public List<Shoot> ShotScripts;
    public List<GameObject> ToDisable;

    void Start()
    {
        if (photonView.IsMine)
        {
            _players.enabled = true;
            _move.enabled = true;
            _physicsCont.enabled = true;
            _playerColliders.enabled = true;
            _cam.GetComponent<Camera>().enabled = true;
            _cam.GetComponent<AudioListener>().enabled = true;
            _targetPos.enabled = true;
            for (int i = 0; i < ShotScripts.Count; i++)
            {
                ShotScripts[i].enabled = true;
            }
            for (int i = 0; i < ToDisable.Count; i++)
            {
                ToDisable[i].SetActive(true);

            }
        }
        else
        {
            _players.enabled = false;
            _move.enabled = false;
            _physicsCont.enabled = false;
            _playerColliders.enabled = false;
            _cam.GetComponent<Camera>().enabled = false;
            _cam.GetComponent<AudioListener>().enabled = true;
            _targetPos.enabled = false;
            for (int i = 0; i < ShotScripts.Count; i++)
            {
                ShotScripts[i].enabled = false;
            }
            for (int i = 0; i < ToDisable.Count; i++)
            {
                ToDisable[i].SetActive(false);
            }
        }
    }
}
