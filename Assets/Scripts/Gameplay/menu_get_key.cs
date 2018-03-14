using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menu_get_key : MonoBehaviour {

    private bool play_switched = true;
    public Transform menu_cloud;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("up") ) {
            menu_cloud.position = new Vector2(-7.43f, 1.11f);
            play_switched = true;
        }
        if (Input.GetKey("down"))
        {
            menu_cloud.position = new Vector2(-7.43f, -1.5f);
            play_switched = false;
        }
        if (Input.GetKeyDown("space") && play_switched == true)
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
        if (Input.GetKeyDown("space") && play_switched == false)
        {
            //UnityEditor.EditorApplication.isPlaying = false;
                        Application.Quit(); 
        }


    }
}
