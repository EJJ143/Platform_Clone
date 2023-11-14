using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Authors: Johnson, Ethan
//         Suazo, Angel
//Last Modified:11/13/23
//Purpose:To handle displaying score (wumpa fruit collected) and the amount of lives the player has in the main scene
public class UIManager : MonoBehaviour
{
    public PlayerController playerController;
    public TMP_Text scoreText;
    public TMP_Text livesText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Wumpa Fruit: " + playerController.wumpaFruitCollected;
        livesText.text = "Lives: " + playerController.lives;
    }
}
