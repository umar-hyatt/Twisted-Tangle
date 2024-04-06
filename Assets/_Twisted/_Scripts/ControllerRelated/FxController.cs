using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Twisted._Scripts.ControllerRelated
{
    public class FxController : MonoBehaviour
    {
        public static FxController instance;
        
        public GameObject ropeSortFx;

        private void Awake()
        {
            instance = this;
        }
    }
}