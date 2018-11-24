using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    private int First_Update_State = 0; //Muestra cuantas updates ha comprado el usuario del primer boton
    private int Second_Update_State = 0; //Muestra cuantas updates ha comprado el usuario del segundo boton
    private int Third_Update_State = 0; //Muestra cuantas updates ha comprado el usuario del tercer boton
    private int Forth_Update_State = 0; //Muestra cuantas updates ha comprado el usuario del cuarto boton
    [Space]
    [Space]
    public int[] First_Update_Adds; // que bonus le añade al jugador
    public int[] First_Update_Cost; // cuanto cuesta cada una de las updates
    [Space]
    public int[] Second_Update_Adds;
    public int[] Second_Update_Cost;
    [Space]
    public int[] Third_Update_Adds;
    public int[] Third_Update_Cost;
    [Space]
    public int[] Fourth_Update_Adds1;  // que bonus le añade al jugador del first
    public int[] Fourth_Update_Adds2;// que bonus le añade al jugador del Second
    public int[] Fourth_Update_Adds3;// que bonus le añade al jugador del Third

    public int[] Fourth_Update_Cost; // cuanto cuesta cada una de las updates

    [Space]
    [Space]
    // textos de los bonus
    public Text First_Text;
    public Text First_Text_Money;
    [Space]
    public Text Second_Text;
    public Text Second_Text_Money;
    [Space]
    public Text Third_Text;
    public Text Third_Text_Money;
    [Space]
    public Text Fourth_Text_1;
    public Text Fourth_Text_2;
    public Text Fourth_Text_3;
    public Text Fourth_Text_Money;

    void ReText(int update, int[] array, Text text )
    {
        text.text = array[update].ToString();
    }

    void Update()
    {
        ReText(First_Update_State, First_Update_Adds, First_Text); //bonus que añade
        ReText(First_Update_State, First_Update_Cost, First_Text_Money); //Precio

        ReText(Second_Update_State, Second_Update_Adds, Second_Text); //bonus que añade
        ReText(Second_Update_State, Second_Update_Cost, Second_Text_Money); //Precio

        ReText(Third_Update_State, Third_Update_Adds, Third_Text); //bonus que añade
        ReText(Third_Update_State, Third_Update_Cost, Third_Text_Money); //Precio

        ReText(Forth_Update_State, Fourth_Update_Adds1, Fourth_Text_1); //bonus que añade
        ReText(Forth_Update_State, Fourth_Update_Adds2, Fourth_Text_2); //bonus que añade
        ReText(Forth_Update_State, Fourth_Update_Adds3, Fourth_Text_3); //bonus que añade

        ReText(Forth_Update_State, Fourth_Update_Cost, Fourth_Text_Money); //Precio
    }

}
