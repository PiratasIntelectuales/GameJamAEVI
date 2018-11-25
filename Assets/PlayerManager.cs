using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    [Space]
    public int Cash = 0; // NO PUT
    public int Initial_Cash;    
    public Text Bank;
    [Space]
    [Space]

    public PlayerShoot player;
    public PlayerMovement player_move;

    [Space]

    //DEBUG ******************************************************************************************
    public Text SPD; //speed
    public Text PLN; //plant
    public Text DMG; //Damage
    public Text CAD; //cadenct

    void settext()
    {
        // SPD.text = speed.ToString();
        // PLN.text = plant.ToString();
        // DMG.text = damage.ToString();
        // CAD.text = cadent.ToString();
    }

    //DEBUG ************************************************************************





    void ReText(int Cash, Text text)
    {
        text.text = Cash.ToString();
    }

    // Use this for initialization
    void Start ()
    {
        Cash += Initial_Cash;
    }
	
	// Update is called once per frame
	void Update ()
    {
        ReText(Cash, Bank);        
    }

    public void AddCash(int quantity)
    {
        Cash += quantity;
    }

    public bool RemoveCash(int quantity)
    {
        if(Cash>=quantity)
        {
            Cash -= quantity;
            return true;
        }
        return false;         
    }

    public void addDamage(int damage,int damage_shogun)
    {
        player.laser_gun_damage += damage;
        player.shotgun_damage += damage_shogun;
        //add damage
    }
    public void addSpeed(float speed)
    {
        if ((player_move.speed + speed) < 130)
            player_move.speed += speed;
        else player_move.speed = 130;
    }
    public void addCadency(float cadency, float candency_shotgun)
    {
        //add damage
        if ((player.laser_time_between_shots - cadency) < 0.04f)
        {
            player.laser_time_between_shots -= cadency;
            player.shotgun_time_between_shots -= candency_shotgun;
        }
        else
        {
            player.laser_time_between_shots = 0.04f;
            player.shotgun_time_between_shots = 0.15f;
        }
    }
    public void addPlantsImprove(float improve)
    {
        //add damage
    }

    public void addAll(int damage, int damage_sg, float speed,float cadency, float cadency_shotgun, float improve)
    {
        addDamage(damage, damage_sg);
        addSpeed(speed);
        addCadency(cadency, cadency_shotgun);
        addPlantsImprove(improve);
    }

}
