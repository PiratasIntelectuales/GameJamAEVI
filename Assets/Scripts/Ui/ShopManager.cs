using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    public GameObject Player;
    PlayerManager playerManag;

    public GameObject canvs;
    Animator animtor;

    public Text Money_in_Shop;
    [Header("Speed")]
    //deww

    [Space]// speed
    public float[] Zero_Update_Adds; // que bonus le añade al jugador
    public int[] Zero_Update_Cost; // cuanto cuesta cada una de las updates
    [Space]//plants
    [Header("plants")]
    public float[] First_Update_Adds; // que bonus le añade al jugador
    public int[] First_Update_Cost; // cuanto cuesta cada una de las updates
    [Space]//damage
    [Header("damage")]
    public int[] Second_Update_Adds;
    public int[] Second_Update_Adds_shotgun;
    public int[] Second_Update_Cost;
    [Space]//gun speed
    [Header("gun speed")]
    public float[] Third_Update_Adds;
    public int[] Third_Update_Cost;
    [Space]//all
    [Header("all")]
    public float[] Fourth_Update_Adds0;  // que bonus le añade al jugador del Zero
    public float[] Fourth_Update_Adds1;  // que bonus le añade al jugador del first
    public int[] Fourth_Update_Adds2;// que bonus le añade al jugador del Second
    public int[] Fourth_Update_Adds2_shotgun;// que bonus le añade al jugador del Second
    public float[] Fourth_Update_Adds3;// que bonus le añade al jugador del Third

    public int[] Fourth_Update_Cost; // cuanto cuesta cada una de las updates

    [Space]
    [Space]// speed
    // textos de los bonus
    public Text Zero_Text;
    public Text Zero_Text_Money;
    [Space]//plants
    public Text First_Text;
    public Text First_Text_Money;
    [Space]//damage
    public Text Second_Text;
    public Text Second_Text_sg;
    public Text Second_Text_Money;
    [Space]//gun speed
    public Text Third_Text;
    public Text Third_Text_Money;
    [Space]//all
    public Text Fourth_Text_0;
    public Text Fourth_Text_1;
    public Text Fourth_Text_2;
    public Text Fourth_Text_2_sg;
    public Text Fourth_Text_3;
    public Text Fourth_Text_Money;

    [Space]
    [Space]

    private int Zero_Update_State = 0; //Muestra cuantas updates ha comprado el usuario del primer boton
    private int First_Update_State = 0; //Muestra cuantas updates ha comprado el usuario del primer boton
    private int Second_Update_State = 0; //Muestra cuantas updates ha comprado el usuario del segundo boton
    private int Third_Update_State = 0; //Muestra cuantas updates ha comprado el usuario del tercer boton
    private int Forth_Update_State = 0; //Muestra cuantas updates ha comprado el usuario del cuarto boton

    //DEBUG ******************************************************************************************

    [Space]
    [Space]
    public Text Zero_Text_debug;
    public Text First_Text_debug;
    public Text Second_Text_debug;
    public Text Third_Text_debug;
    public Text Fourth_Text_debug;

    void setDEBUGtext()
    {
        Zero_Text_debug.text = Zero_Update_State.ToString();
        First_Text_debug.text = First_Update_State.ToString();
        Second_Text_debug.text = Second_Update_State.ToString();
        Third_Text_debug.text = Third_Update_State.ToString();
        Fourth_Text_debug.text = Forth_Update_State.ToString();
    }

    //DEBUG ******************************************************************************************




    void ReText(int update, int[] array, Text text )
    {
        text.text = array[update].ToString();
    }
    void ReText(int update, float[] array, Text text)
    {
        text.text = array[update].ToString();
    }
    void ReText(string str, Text text)
    {
        text.text = str;
    }

    void setTextColorRed(Text text)
    {
        text.color = Color.red;
    }
    void setTextColorBlack(Text text)
    {
        text.color = new Color(50f/255f, 50f/255f, 50f/255f);
    }


    public void buy(int tobuy/*0-Zero, 1-First, 2-Second, 3-Third, 4-Fourt */)
    {
        switch(tobuy)
        {
            case 0:
                if(playerManag.RemoveCash(Zero_Update_Cost[Zero_Update_State]))
                {
                    playerManag.addSpeed(Zero_Update_Adds[Zero_Update_State]);
                    this.Zero_Update_State++;

                    setTextColorBlack(Zero_Text_Money);
                }  
                else
                {
                    // cant buuy
                    // animtor.SetTrigger("CantBuy");

                    setTextColorRed(Zero_Text_Money);
                }
                break;

            case 1:
                if (playerManag.RemoveCash(First_Update_Cost[First_Update_State]))
                {
                    playerManag.addPlantsImprove(First_Update_Adds[First_Update_State]);
                    this.First_Update_State++;
                    setTextColorBlack(First_Text_Money);
                }
                else
                {
                    setTextColorRed(First_Text_Money);
                    // cant buuy
                    //animtor.SetTrigger("CantBuy");
                }
                break;
            case 2:
                if (playerManag.RemoveCash(Second_Update_Cost[Second_Update_State]))
                {
                    playerManag.addDamage(Second_Update_Adds[Second_Update_State], Second_Update_Adds_shotgun[Second_Update_State]);
                    this.Second_Update_State++;
                    setTextColorBlack(Second_Text_Money);
                }
                else
                {

                    setTextColorRed(Second_Text_Money);
                    // cant buuy
                    //animtor.SetTrigger("CantBuy");
                }
                break;

            case 3:
                if (playerManag.RemoveCash(Third_Update_Cost[Third_Update_State]))
                {
                    playerManag.addCadency(Third_Update_Adds[Third_Update_State]);
                    this.Third_Update_State++;
                    setTextColorBlack(Third_Text_Money);
                }
                else
                {
                    setTextColorRed(Third_Text_Money);
                    // cant buuy
                    //animtor.SetTrigger("CantBuy");
                }
                break;

            case 4:
                if (playerManag.RemoveCash(Fourth_Update_Cost[Forth_Update_State]))
                {
                    playerManag.addSpeed(Fourth_Update_Adds0[Forth_Update_State]);
                    playerManag.addPlantsImprove(Fourth_Update_Adds1[Forth_Update_State]);
                    playerManag.addDamage(Fourth_Update_Adds2[Forth_Update_State], Fourth_Update_Adds2_shotgun[Forth_Update_State]);
                    playerManag.addCadency(Fourth_Update_Adds3[Forth_Update_State]);
                    this.Forth_Update_State++;
                    setTextColorBlack(Fourth_Text_Money);
                }
                else
                {
                    setTextColorRed(Fourth_Text_Money);
                    // cant buuy
                    //animtor.SetTrigger("CantBuy");
                }

                break;
        }
    }

    void setTextinShop()
    {
        //********************************
        if (First_Update_State < Zero_Update_Adds.Length)
        {
            ReText(Zero_Update_State, Zero_Update_Adds, Zero_Text); //bonus que añade
            ReText(Zero_Update_State, Zero_Update_Cost, Zero_Text_Money); //Precio
        }
        else
        {
            ReText("Vendido", Zero_Text); //bonus que añade
            ReText("Vendido", Zero_Text_Money); //Precio
        }
        //********************************
        if (First_Update_State < First_Update_Adds.Length)
        {
            ReText(First_Update_State, First_Update_Adds, First_Text); //bonus que añade
            ReText(First_Update_State, First_Update_Cost, First_Text_Money); //Precio
        }
        else
        {
            ReText("Vendido", First_Text); //bonus que añade
            ReText("Vendido", First_Text_Money); //Precio
        }
        //********************************
        if (Second_Update_State < Second_Update_Adds.Length)
        {
            ReText(Second_Update_State, Second_Update_Adds, Second_Text); //bonus que añade
            ReText(Second_Update_State, Second_Update_Adds_shotgun, Second_Text_sg); //bonus que añade
            ReText(Second_Update_State, Second_Update_Cost, Second_Text_Money); //Precio
        }
        else
        {
            ReText("Vendido", Second_Text); //bonus que añade
            ReText("Vendido", Second_Text_Money); //Precio
        }
        //********************************
        if (Third_Update_State < Third_Update_Adds.Length)
        {
            ReText(Third_Update_State, Third_Update_Adds, Third_Text); //bonus que añade
            ReText(Third_Update_State, Third_Update_Cost, Third_Text_Money); //Precio
        }
        else
        {
            ReText("Vendido", Third_Text); //bonus que añade
            ReText("Vendido", Third_Text_Money); //Precio
        }
        //********************************  
        if (Forth_Update_State < Fourth_Update_Adds0.Length)
        {
            ReText(Forth_Update_State, Fourth_Update_Adds0, Fourth_Text_0); //bonus que añade
            ReText(Forth_Update_State, Fourth_Update_Adds1, Fourth_Text_1); //bonus que añade
            ReText(Forth_Update_State, Fourth_Update_Adds2, Fourth_Text_2); //bonus que añade
            ReText(Forth_Update_State, Fourth_Update_Adds2_shotgun, Fourth_Text_2_sg); //bonus que añade
            ReText(Forth_Update_State, Fourth_Update_Adds3, Fourth_Text_3); //bonus que añade

            ReText(Forth_Update_State, Fourth_Update_Cost, Fourth_Text_Money); //Precio
        }
        else
        {
            ReText("Vendido", Fourth_Text_0); //bonus que añade
            ReText("Vendido", Fourth_Text_1); //bonus que añade
            ReText("Vendido", Fourth_Text_2); //bonus que añade
            ReText("Vendido", Fourth_Text_2_sg); //bonus que añade
            ReText("Vendido", Fourth_Text_3); //bonus que añade

            ReText("Vendido", Fourth_Text_Money); //Precio
        }
        //********************************

    }

    void checkColor()
    {
        if (Zero_Update_Cost[Zero_Update_State] <= playerManag.Cash)
            setTextColorBlack(Zero_Text_Money);
        else
            setTextColorRed(Zero_Text_Money);

        if (First_Update_Cost[First_Update_State] <= playerManag.Cash)
            setTextColorBlack(First_Text_Money);
        else
            setTextColorRed(First_Text_Money);

        if (Second_Update_Cost[Second_Update_State] <= playerManag.Cash)
            setTextColorBlack(Second_Text_Money);
        else
            setTextColorRed(Second_Text_Money);

        if (Third_Update_Cost[Third_Update_State] <= playerManag.Cash)
            setTextColorBlack(Third_Text_Money);
        else
            setTextColorRed(Third_Text_Money);

        if (Fourth_Update_Cost[Forth_Update_State] <= playerManag.Cash)
            setTextColorBlack(Fourth_Text_Money);
        else
            setTextColorRed(Fourth_Text_Money);

    }

    void Start()
    {
        playerManag = Player.GetComponent<PlayerManager>();
        animtor = canvs.GetComponent<Animator>();
    }

    void Update()
    {
        checkColor();

        setTextinShop();

        Money_in_Shop.text = playerManag.Cash.ToString();
        
        setDEBUGtext();
    }

}
