using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstatiateExample : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    public Cards SelectedCard;

    private void Awake()
    {
       GameObject _PlayerSelection = MasterManager.NetworkInstantiate(_prefab, transform.position, Quaternion.identity);
        _PlayerSelection.GetComponent<Players>().Cards=MasterManager.card;


    }
}
