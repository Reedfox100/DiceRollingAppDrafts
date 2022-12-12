using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phyzix : MonoBehaviour
{
    Rigidbody rb;
    //on ground
    bool landed;
    //was thrown
    bool thrown;
    //value returned
    bool returned;
    //if the dice was selected to be rolled
    bool selected;
    //value of dice that was rolled
    public int diceValue;
    //fixing for out of bounds dice
    public bool resetWait = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Checks dice rolling
    void Update()
    {
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RollDice();
            }

            if (!landed && thrown)
            {
                landed = true;
            }

            if (landed && thrown && !returned)
            {
                ValueRNG();
                returned = true;
            }
            if (rb.position.y < -0.5)
            {
                Reset();
                resetWait = true;
            }
            if (rb.position.x < -0.3 || rb.position.x > 0.3)
            {
                Reset();
                resetWait = true;
            }
            if (rb.position.z < -0.3 || rb.position.z > 0.3)
            {
                Reset();
                resetWait = true;
            }
        }
    }
    //Rolls the dice and waits for resetable reroll
    void RollDice()
    {
        if (!thrown && !landed && !resetWait)
        {
            thrown = true;
            rb.useGravity = true;
            rb.AddTorque(Random.Range(0, 200), 0, Random.Range(0, 200));
            rb.AddForce(Random.Range(-350, 350), 0, Random.Range(-350, 350));
        }
        else if (thrown && landed)
        {
            Reset();
        }
        else if (resetWait)
        {
            resetWait = false;
        }
    }
    //Resets location
    void Reset()
    {
        transform.position = new Vector3(Random.Range((float)-0.15, (float)0.15), (float)0.35, Random.Range((float) -0.15, (float) 0.15));
        thrown = false;
        landed = false;
        returned = false;
        rb.useGravity = false;
        

    }
    //Returns random value for the dice (WILL BE CHANGED WITH WORKING TEXTURES)
    void ValueRNG()
    {
        if (rb.IsSleeping() && landed)
        {
            if (rb.name == "node_id4")
                diceValue = Random.Range(1, 5);
            if (rb.name == "node_id6")
                diceValue = Random.Range(1, 7);
            if (rb.name == "node_id8")
                diceValue = Random.Range(1, 9);
            if (rb.name == "node_id10")
                diceValue = Random.Range(1, 11);
            if (rb.name == "node_id12")
                diceValue = Random.Range(1, 13);
            if (rb.name == "node_id20")
                diceValue = Random.Range(1, 21);
        }
    }
}