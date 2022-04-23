using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolGun : MonoBehaviour,IGuns
{
    public GunsStat gunsStat;
    public int capacity;
    public float reloadTime, repeatTime, range;
    public GameObject gunPrefab;
    public string gunName;
    void Start()
    {
        capacity = gunsStat.capacity;
        reloadTime = gunsStat.reloadTime;
        repeatTime = gunsStat.repeatTime;
        range = gunsStat.range;
        gunName = gunsStat.gunName;
        gunPrefab = gunsStat.gunPrefab;
        GameObject cloneGun= Instantiate(gunPrefab,transform.position,Quaternion.identity);
        cloneGun.transform.SetParent(transform);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Reload()
    {
        
    }

    public void shot()
    {
        throw new System.NotImplementedException();
    }

   
}
