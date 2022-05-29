using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstatiateExample : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    public Cards SelectedCard;
    public Transform[] single;
    public Transform[] blueTeam;
    public Transform[] redTeam;
    public List<GameObject> AllPlayers;
    public Transform FinalSpawnPos;
    public GunsStat gun;
    public int _myId;

    private void Awake()
    {
       GameObject _PlayerSelection = MasterManager.NetworkInstantiate(_prefab, transform.position, Quaternion.identity);
        _PlayerSelection.GetComponent<Players>().Cards=MasterManager.card;
        _PlayerSelection.GetComponent<Players>().guns = MasterManager.gunStat;

    }
    public void SwitchMode(int Number)
    {
        switch (Number)
	    {
            case 1:
                SpawnMode(_prefab, blueTeam,1);
                break;
            case 2:
                SpawnMode(_prefab, redTeam,2);
                break;
            case 3:
                SpawnMode(_prefab, single,3);
                break;
            default:
            break;
        }
    }
    void SpawnMode(GameObject toSpawn,Transform[] WhereToSpawn,int _myId)
    {

        for (int spawnPos = 0; spawnPos < WhereToSpawn.Length; spawnPos++)
        {
            FinalSpawnPos = WhereToSpawn[spawnPos];
        }
        GameObject _PlayerSelection = MasterManager.NetworkInstantiate(toSpawn, FinalSpawnPos.position, FinalSpawnPos.rotation);
        _PlayerSelection.GetComponent<Players>().Cards = MasterManager.card;
        _PlayerSelection.GetComponent<Players>().guns = MasterManager.gunStat;
        _PlayerSelection.GetComponent<TeamViewer>().myId = _myId;
        AllPlayers.Add(_PlayerSelection);
    }

    
}
