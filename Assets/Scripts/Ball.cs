using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public int hotHitsThreshold = -1;
    public Vector3 initialImpulse = new Vector3(10, 0, 0);
    public Player hitter { get; private set; }
    public GameObject Flame;
    private int defaultPoints = 1;
    public int points;
    private Player previousHitter;
    private int hits;
    private GameObject flame;
    private bool inFlames = false;

    // Start is called before the first frame update
    void Start()
    {
        points = defaultPoints;
        speed = 10; //setting the speed
        Vector2 randomValues = UnityEngine.Random.insideUnitCircle; //generetes random X Y
        while (randomValues.y < 0.3)
        {
            Debug.Log("rolled " + randomValues.y + " for ball's new z - rerolling");
            randomValues = UnityEngine.Random.insideUnitCircle; //prevent the ball from moving too vertical and not towards the players
        }
        Vector3 startVel = new Vector3(randomValues.x, 0, randomValues.y); //creates a vector3 from the random values (x<-x, y<-0, z<-y)
        GetComponent<Rigidbody>().AddForce(startVel.normalized * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    bool IsHot()
    {
        return hits >= hotHitsThreshold;
    }

    void OnCollisionEnter(Collision collider)
    {
        PlayerBorder playerBorder = collider.gameObject.GetComponent<PlayerBorder>();
        Pedal pedal = collider.gameObject.GetComponent<Pedal>();

        if (pedal)
        {
            hits++; // increment hits counter if hits a pedal
            previousHitter = pedal.player != hitter ? hitter : previousHitter; // keep track of the previous hitter (comes handy in case of own goal)
            hitter = pedal.player;
        }
        else if (playerBorder)
        {
            hits = 0; // reset if hits a wall
            hitter = playerBorder.player.playerName != hitter.playerName ? hitter : previousHitter; // in case of own goal the previous hitter should get the points

            if (inFlames)
            {
                ExtinguishFlame();
            }
        }
    }

    public void SetInFlames()
    {
        if (!inFlames)
        {
            Vector3 postition = transform.position + new Vector3(0f, 1.5f, 0f);
            flame = Instantiate(Flame, transform.position, Quaternion.Euler(-90f, 0f, 0f), gameObject.transform);
            inFlames = true;
        }
    }

    void ExtinguishFlame()
    {
        Debug.Log("ExtinguishFlame");
        Destroy(flame);
        inFlames = false;
    }
}
