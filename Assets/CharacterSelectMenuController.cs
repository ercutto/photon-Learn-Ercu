using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectMenuController : MonoBehaviour
{
    public Cards[] Thiscard;
    public int cardID;
    public void CardSelecting(int cardID)
    {
        MasterManager.card = Thiscard[cardID];
    }
}
