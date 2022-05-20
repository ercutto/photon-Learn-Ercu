using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectMenuController : MonoBehaviour
{
    public Cards[] Thiscard;

    public int cardID;

    public GunsStat[] ThisGun;

    public int gunID;

    public void CardSelecting(int cardID)
    {
        MasterManager.card = Thiscard[cardID];
    }
    public void GunSelecting(int gunID)
    {
        MasterManager.gunStat = ThisGun[gunID];
    }
}
