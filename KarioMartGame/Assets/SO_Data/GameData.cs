using UnityEngine;

[CreateAssetMenu]
public class GameData : ScriptableObject
{
    private Sprite player1; // Player 1 car
    private Sprite player2; // Player 2 car
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
