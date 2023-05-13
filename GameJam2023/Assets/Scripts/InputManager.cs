using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


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
        zKeyCommand = new JumpCommand();
        qKeyCommand = new AttackCommand();
        zKeyCommand = new MoveForwardCommand(1);
        zKeyCommand = new MoveForwardCommand(1);
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            eKeyCommand.Execute(Player);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            aKeyCommand.Execute(Player);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            zKeyCommand.Execute(Player);
        }


    }

    private void SwapControls()
    {
        eKeyCommand = new AttackCommand();
        aKeyCommand = new JumpCommand();
    }

}


