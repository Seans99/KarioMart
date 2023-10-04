using UnityEngine;

[CreateAssetMenu]
public class PlayerCollectedPowerup : ScriptableObject
{
    private int p1Powerup = 0;
    private int p2Powerup = 0;
    private bool p1Collected = false;
    private bool p2Collected = false;

    public int P1Powerup
    {
        get { return p1Powerup; }
        set { p1Powerup = value; }
    }

    public int P2Powerup
    {
        get { return p2Powerup; }
        set { p2Powerup = value; }
    }

    public bool P1Collected
    {
        get { return p1Collected; }
        set { p1Collected = value; }
    }

    public bool P2Collected
    {
        get { return p2Collected; }
        set { p2Collected = value; }
    }
}
