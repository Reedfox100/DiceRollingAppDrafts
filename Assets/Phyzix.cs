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
    //initial position
    Vector3 initPosition;
    //value of dice that was rolled
    public int diceValue;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initPosition = transform.position;
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

            if (rb.IsSleeping() && !landed && thrown)
            {
                landed = true;
            }

            if (rb.IsSleeping() && landed && thrown && !returned)
            {
                ValueRNG();
                returned = true;
            }
        }
    }
    //Rolls the dice and waits for resetable reroll
    void RollDice()
    {
        if (!thrown && !landed)
        {
            thrown = true;
            rb.useGravity = true;
            rb.AddTorque(Random.Range(0, 200), 0, Random.Range(0, 200));
            rb.AddForce(Random.Range(80, 350), 0, Random.Range(80, 350));
        }
        else if (thrown && landed)
        {
            Reset();
        }
    }
    //Rolls from ground with transform from ground into air
    void RollAgain()
    {
        Reset();
        thrown = true;
        rb.useGravity = true;
        rb.AddTorque(Random.Range(0, 200), 0, Random.Range(0, 200));
    }
    //Resets location
    void Reset()
    {
        transform.position = initPosition;
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