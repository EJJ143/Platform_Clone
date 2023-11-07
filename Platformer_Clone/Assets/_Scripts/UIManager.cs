using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        scoreText.text = "Wumpa Fruit: " + playerController.wumpaFruit;
        livesText.text = "Lives: " + playerController.lives;
    }
}
