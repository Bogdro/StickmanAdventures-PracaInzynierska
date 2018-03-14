using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour {


    public GameObject player1;
    public GameObject player2;

    private GameObject currentPlayer;
    private MovementCommand command;
	
	void OnEnable() {
        player1 = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("PlayerClone");
        currentPlayer = player1;
        currentPlayer.GetComponent<Player>().Indicator.SetActive(true);
        command = new MovementCommand(currentPlayer.GetComponent<Player>());
    }

    // Update is called once per frame
    void Update () {
        command.Execute();
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.JoystickButton5)) {
            if (currentPlayer == player1)
            {
                player2.GetComponent<Player>().movementObject = player1.GetComponent<Player>().movementObject;
                player1.GetComponent<Player>().Indicator.SetActive(false);
                player1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, player1.GetComponent<Rigidbody2D>().velocity.y);
                currentPlayer = player2;
                player1.GetComponent<Player>().movementObject = new IdleMovement();

            }
            else if (currentPlayer == player2)
            {
                player1.GetComponent<Player>().movementObject = player2.GetComponent<Player>().movementObject;
                player2.GetComponent<Player>().Indicator.SetActive(false);
                player2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, player2.GetComponent<Rigidbody2D>().velocity.y);
                currentPlayer = player1;
                player2.GetComponent<Player>().movementObject = new IdleMovement();
            }
            currentPlayer.GetComponent<Player>().Indicator.SetActive(true);
            command.ChangeReciever(currentPlayer.GetComponent<Player>());
        }
    }
}
