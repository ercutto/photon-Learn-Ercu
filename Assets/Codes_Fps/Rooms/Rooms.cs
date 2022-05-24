using System;
using UnityEngine;
[CreateAssetMenu(menuName ="FPS Game Modes",fileName ="Game Modes")]
public class Rooms : ScriptableObject
{
    public string _name;
    public bool _hasTeams;
    public int teamSize;

}
