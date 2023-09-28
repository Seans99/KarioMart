using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameData : ScriptableObject
{
    private Sprite player1;
    private Sprite player2;
    private int trackId;

    public Sprite Player1
    {
        get { return player1; }
        set { player1 = value; }
    }

    public Sprite Player2 
    { 
        get { return player2; } 
        set {  player2 = value; } 
    }

    public int TrackId
    {
        get { return trackId; }
        set { trackId = value; }
    }
}
