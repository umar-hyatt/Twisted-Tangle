using UnityEngine;
using System.Collections;

public class LogicRopeWithCoil : MonoBehaviour
{
    public UltimateRope Rope;
    public float RopeExtensionSpeed;
    float m_fRopeExtension;
	void Start()
    {
	    m_fRopeExtension = Rope != null ? Rope.m_fCurrentExtension : 0.0f;
	}
    void OnGUI()
    {
        LogicGlobal.GlobalGUI();
        GUILayout.Label("Rope test (Procedural rope with additional coil)");
        GUILayout.Label("Use the keys i and o to extend the rope");
    }
	void Update()
    {
        
	}
}
