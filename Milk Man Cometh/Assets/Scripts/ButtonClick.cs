using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
/*
 * Handles button clicking events, especially in the main menu and the pause menu.
 */
public class ButtonClick : MonoBehaviour
{
    //public Vector2 xY;                      // Vector with the player's starting coordinates
    public Damage playerHealth;             // Reference to the player's health.
    private int level;                      // The level's index in the build
    public Transform player;                // The player's current position
    public int scene;

    //spawnPoint spawn;

    Animator anim;                          // Reference to the animator component.

    void Awake () {

        level = SceneManager.GetActiveScene().buildIndex;   // Set's the level index to the current scene
        anim = GetComponent<Animator>();                    // Sets the animator to the object's animator
    }
	
	// Update is called once per frame
	void Update () {

        if (Damage.player != null)
        {
            player = Damage.player.transform;   // Sets the player's transform to the current player's transform
        }
        
    }
    /*
     * The play game button
     */
    public void playGame()
    {
        SceneManager.LoadScene(scene);
    }
    /*
     * The restart level button
     */
    public void restartLevel()
    {
        player.transform.position = new Vector3(spawnPoint.spawn.transform.position.x, spawnPoint.spawn.transform.position.y); //spawn.spawn; // Reset the player's position to the starting position in the level
        
        SceneManager.LoadScene(level);
        //anim.SetBool("Dead", false);
        //BasicControls.player.anim.SetBool("Dead", false);
    }
    /*
     * The quit game button
     */
    public void closeGame()
    {
        Application.Quit();
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);

    }
}
