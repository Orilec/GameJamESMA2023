using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InputManager : MonoBehaviour
{
    public PlayerController Player;
    private ICommand zKeyCommand;
    private ICommand qKeyCommand;
    private ICommand sKeyCommand;
    private ICommand dKeyCommand;

    private List<ICommand> _commands;

    private void Awake()
    {

        qKeyCommand = new MoveCommand(-1);
        dKeyCommand = new MoveCommand(1);

    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {

        }

        if (Input.GetKeyDown(KeyCode.A))
        {

        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            zKeyCommand.Execute(Player);
        }


    }

    private void AffectCommand(ICommand macommande)
    {


     
    }

}


