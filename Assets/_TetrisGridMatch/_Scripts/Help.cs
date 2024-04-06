using System.Collections.Generic;
using _Twisted._Scripts.ControllerRelated;
using UnityEngine;

public class Help : MonoBehaviour
{
    public static Help instance;
    public GameObject firstHelpArrow, secondHelpArrow;
    public int targetBallToShowHelp;
    private void Awake()
    {
        instance = this;
    }

    private int _counter;

    public void ShowHelp()
    {
        _counter++;
        if (_counter >= 1)
            gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        MainController.GameStateChanged += GameManager_GameStateChanged;
    }

    private void OnDisable()
    {
        MainController.GameStateChanged -= GameManager_GameStateChanged;
    }

    public bool showInitialHelp;

    void GameManager_GameStateChanged(GameState newState, GameState oldState)
    {
        if (newState == GameState.Levelwin || newState == GameState.Levelfail)
        {
            gameObject.SetActive(false);
        }

        /*if (!showInitialHelp) return;
        if (newState == GameState.BallSpawnerState)
        {
            firstHelpArrow.SetActive(true);
            showInitialHelp = false;
        }*/
    }

    /*public void ShowHelp_OnTargetBallReached()
    {
        if (targetPlaceElement.occupiedBall != null) return;
        secondHelpArrow.SetActive(true);
    }*/
}