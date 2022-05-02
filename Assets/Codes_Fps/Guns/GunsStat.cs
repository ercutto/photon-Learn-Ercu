using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Gun",menuName ="Guns")]
public class GunsStat : ScriptableObject
{
    public GameObject gunPrefab;
    public GameObject bullertPrefab;
    public string gunName;
    [SerializeField]
    public int capacity;
    [SerializeField]
    public float reloadTime;
    [SerializeField]
    public float repeatTime;
    [SerializeField]
    public float range;
}
