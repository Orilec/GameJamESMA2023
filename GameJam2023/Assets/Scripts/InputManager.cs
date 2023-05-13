using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class InputManager : MonoBehaviour
{
    public PlayerController Player;
    private ICommand zKeyCommand;
    private ICommand qKeyCommand;
    private ICommand sKeyCommand;
    private ICommand dKeyCommand;

    public List<MyInput> inputs;

    
    public void AttributeActionOnZ(UnityAction<PlayerController> newAction)
    {
        //zKeyAction = null;
        //zKeyAction += newAction;
    }

    private List<ICommand> _commands;

    private void Awake()
    {
        zKeyCommand = new JumpCommand();
        qKeyCommand = new MoveCommand(-1);
        dKeyCommand = new MoveCommand(1);

    }


    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    zKeyCommand.Execute(Player);
        //}

        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    qKeyCommand.Execute(Player);
        //}

        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    sKeyCommand.Execute(Player);
        //}

        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    dKeyCommand.Execute(Player);
        //}

        foreach (var input in inputs)
        {
            input.Process(Player);
        }


    }

    public MyInput GetKeyWithKeyCode(KeyCode key)
    {
        return inputs.Find((input) => key == input.code);
    }

    private void AffectCommand(ICommand macommande)
    {
 

     
    }

}


[System.Serializable]
public class MyInput
{
    private UnityAction<PlayerController> onPressed, onDown, onUp;
    public KeyCode code;

    public void ClearUp()
    {
        onUp = null;
    }
    public void AttributeUp(UnityAction<PlayerController> newAction, bool shouldClear = true)
    {
        if(shouldClear)
        {
            ClearUp();
        }
        onUp += newAction;
    }
    public void ClearDown()
    {
        onDown = null;
    }
    public void AttributeDown(UnityAction<PlayerController> newAction, bool shouldClear = true)
    {
        if (shouldClear)
        {
            ClearDown();
        }
        onDown += newAction;
    }
    public void ClearPressed()
    {
        onPressed = null;
    }
    public void AttributePressed(UnityAction<PlayerController> newAction, bool shouldClear = true)
    {
        if (shouldClear)
        {
            ClearUp();
        }
        onPressed += newAction;
    }
    public void Process(PlayerController player)
    {
        if(Input.GetKeyDown(code))
        {
            onDown.Invoke(player);

        }
        if (Input.GetKeyUp(code))
        {
            onUp.Invoke(player);

        }
        if (Input.GetKey(code))
        {
            onPressed.Invoke(player);
        }
    }
}


