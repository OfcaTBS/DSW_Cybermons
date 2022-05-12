using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    private Queue<ICommand> commandBuffer;

    public void AddCommand(ICommand command)
    {
        commandBuffer.Enqueue(command);
        Debug.Log(gameObject.name + " gets command: " + command);
    }

    private void Awake()
    {
        commandBuffer = new Queue<ICommand>();
    }
}
