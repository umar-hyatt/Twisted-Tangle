using System.Collections;
using System.Collections.Generic;
using _Twisted._Scripts.ElementRelated;
using UnityEngine;

public class RopeNode : MonoBehaviour
{
    private Decider ropedecider;
    private RopeElement _ropeElement;
    
    void Start()
    {
        ropedecider = Decider.instance;
        _ropeElement = transform.parent.GetComponent<RopeElement>();
    }
    void Update()
    {
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "otherrope")
        {
            if (collision.gameObject.transform.parent == transform.parent)
            {
           
            }
            else {
                ropedecider.stillincontact();
                _ropeElement.InContact();
                _ropeElement.collidedRopeNode = this;
                _ropeElement.CalculateInitialDist();
            }
           
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "otherrope")
        {
            if (collision.gameObject.transform.parent == transform.parent)
            {
              //  Debug.Log(collision.gameObject.transform.parent+"<--->"+transform.parent);
              // Debug.Log("same parent 2.0");
            }
            else
            {
                ropedecider.onincontact();
                _ropeElement.NoContact();
            }
        }
    }
}
