using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstatiateExample : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject _prefab,_redTeam;
    public GameObject bullet;
    public Cards SelectedCard;
    public Transform[] single;
    public Transform[] blueTeam;
    public Transform[] redTeam;
    
    //public List<GameObject> AllPlayers;
    public Transform FinalSpawnPos;
    public GunsStat gun;
    public static int _myId;
   
    

    private void Awake()
    {
        //GameObject _PlayerSelection = MasterManager.NetworkInstantiate(_prefab, transform.position, Quaternion.identity);
        // _PlayerSelection.GetComponent<Players>().Cards=MasterManager.card;
        // _PlayerSelection.GetComponent<Players>().guns = MasterManager.gunStat;
        // _myId = MasterManager.teamNumber;
        _myId = MasterManager.nextPlayersTeam;
 
        if (_myId==1)
        {
            SpawnMode(_prefab, blueTeam, 1);
            
        }
        if(_myId==2)
        {
            SpawnMode(_redTeam, redTeam, 1);
           
        }
    

    }
    public void Start()
    {
        
    }
    public void Respawnblue()
    {
        SpawnMode(_prefab, blueTeam, 1);
    }
    public void RespawnRed()
    {
        SpawnMode(_redTeam, redTeam, 2);
    }
    public void SpawnMode(GameObject toSpawn,Transform[] WhereToSpawn,int _myId)
    {
        
        for (int spawnPos = 0; spawnPos < WhereToSpawn.Length; spawnPos++)
        {

            FinalSpawnPos = WhereToSpawn[spawnPos];
         
            
        }
        GameObject _PlayerSelection = MasterManager.NetworkInstantiate(toSpawn, FinalSpawnPos.position, FinalSpawnPos.rotation);
        _PlayerSelection.GetComponent<Players>().Cards = MasterManager.card;
        _PlayerSelection.GetComponent<Players>().guns = MasterManager.gunStat;
        _PlayerSelection.GetComponent<TeamViewer>().myTeam = _myId;
       

        //AllPlayers.Add(_PlayerSelection);
    }

    public static void UpdateTeam()
    {
        if (_myId == 1)
        {
            _myId = 2;
        }
        else
        {
            _myId = 1;
        }
    }

   
}
