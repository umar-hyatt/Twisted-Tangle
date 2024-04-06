using System.Collections;
using System.Collections.Generic;
using _Twisted._Scripts.ControllerRelated;
using _Twisted._Scripts.ElementRelated;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Decider : MonoBehaviour
{
    public static Decider instance;
    public Animator deviceanimation;
    [HideInInspector] public bool fingerUp;
    public int intouch;
    private float timer;
    public float starttime;
    [HideInInspector] public bool levelComplete;

    private RopeElement[] ropeElements;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        starttime = 0.75f;
        intouch = 0;
        timer = starttime;
        ropeElements = FindObjectsOfType<RopeElement>();
    }
    void Update()
    {
        if (intouch == 0 && fingerUp)
        {
            timer -= Time.deltaTime;
            if (timer <= 0 && !levelComplete)
            {
                 MainController.instance.SetActionType(GameState.Levelwin);
                 levelComplete = true;
                 //RollupAllRopes();
            }
        }
        else
        {
            timer = starttime;
        }
    }

    void RollupAllRopes()
    {
        for (int i = 0; i < ropeElements.Length; i++)
        {
            //ropeElements[i].RollUpRope();
        }
    }
    void CameraZoomIn()
    {
        GameObject[] mobiles = GameObject.FindGameObjectsWithTag("mobile");
        float totX = 0;
        
        for (int i = 0; i < mobiles.Length; i++)
        {
            totX += mobiles[i].transform.position.x;
        }
        Transform cam = Camera.main.transform;
        Vector3 camNewPos = new Vector3(totX / 2, cam.position.y, cam.position.z + 3);
        //cam.DOMove(camNewPos, 0.3f).SetEase(Ease.Linear);
    }
    public void stillincontact()
    {
        intouch++;
    }
    public void onincontact()
    {
        intouch--;
    }
    public void lefteed()
    {
        fingerUp = true;
    }
    public void dropeed()
    {
        fingerUp = false;
    }

}
