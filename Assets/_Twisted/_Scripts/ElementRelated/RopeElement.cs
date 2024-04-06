using System;
using System.Collections;
using _Twisted._Scripts.ControllerRelated;
using DG.Tweening;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

namespace _Twisted._Scripts.ElementRelated
{
    public class RopeElement : MonoBehaviour
    {
        private UltimateRope _ultimateRope;
        public Transform handle1, handle2;
        
        [HideInInspector] public bool fingerUp, rolledUp;
        public int intouch;
        private float timer;
        public float starttime;

        public RopeNode collidedRopeNode;
        private float _initialDistFromMid;
        private bool _checkStress;

        private void OnEnable()
        {
            AddMissingComponentsToNodes();
        }

        private void Awake()
        {
            
        }

        void Start()
        {
            starttime = 0.75f;
            intouch = 0;
            timer = starttime;
            fingerUp = true;
            _ultimateRope = GetComponent<UltimateRope>();
            _ultimateRope.TotalRopeLength = 3.2f;
            _ultimateRope.RopePhysicsMaterial = GameController.instance.ropePhysicsMat;
            ChangeHandleColor();
        }

        void ChangeHandleColor()
        {
            handle1.GetComponent<Renderer>().material = GameController.instance.GetHandleMaterial(GetComponent<Renderer>().material);
            handle2.GetComponent<Renderer>().material = GameController.instance.GetHandleMaterial(GetComponent<Renderer>().material);
        }
        public void InContact()
        {
            intouch++;
        }
        public void NoContact()
        {
            intouch--;
        }

        public void CalculateInitialDist()
        {
            Vector3 midPoint = (handle1.position + handle2.position) / 2;
            _initialDistFromMid = Vector3.Distance(collidedRopeNode.transform.position, midPoint);
            _checkStress = true;
        }
        void Update()
        {
            if (intouch == 0 && fingerUp)
            {
                timer -= Time.deltaTime;
                if (timer <= 0 && !rolledUp)
                {
                    rolledUp = true;
                    StartCoroutine(RollUpRope());
                }
            }
            else
            {
                timer = starttime;
            }

            if (!_checkStress || !collidedRopeNode) return;
            Vector3 midPoint = (handle1.position + handle2.position) / 2;
            float dist = Vector3.Distance(collidedRopeNode.transform.position, midPoint);
            if(dist >= _initialDistFromMid + 1f)
            {
                SnapHandles();
                collidedRopeNode = null;
            }
        }

        private void SnapHandles()
        {
            ObjectDrag dragScript1 = handle1.GetComponent<ObjectDrag>();
            dragScript1.targetSnapPosition = handle1.GetComponent<HandleElement>()._lastPos;
            dragScript1.isSnapping = true;
            ObjectDrag dragScript2 = handle2.GetComponent<ObjectDrag>();
            dragScript2.targetSnapPosition = handle2.GetComponent<HandleElement>()._lastPos;
            dragScript2.isSnapping = true;
        }
        IEnumerator RollUpRope()
        {
            ChangeLayersOfNodes();
            handle1.GetComponent<Collider>().enabled = false;
            handle1.DORotate(Vector3.right * 180, 0.5f);
            _ultimateRope.BoneColliderType = UltimateRope.EColliderType.None;
            
            Vector3 movePos = new Vector3(handle2.position.x, 0.35f, handle2.position.z);
            handle1.DOMove(movePos, 0.5f).SetEase(Ease.OutBack);
            handle2.DOMoveY(handle2.position.y - 15, 0.5f);
            SoundsController.instance.PlaySound(SoundsController.instance.cupUp);
            Vibration.Vibrate(30);
            
            yield return new  WaitForSeconds(0.5f);
            Transform fx = Instantiate(FxController.instance.ropeSortFx, movePos, quaternion.identity).transform;
            GameController.instance.StartCoroutine(GameController.instance.DumpUnUsed(fx.gameObject));
            
            handle1.DOScale(Vector3.zero, 0.3f).SetEase(Ease.OutBack);
            handle2.DOScale(Vector3.zero, 0.3f).SetEase(Ease.OutBack);
            yield return new WaitForSeconds(0.35f);
            handle1.gameObject.SetActive(false);
            handle2.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

        void AddMissingComponentsToNodes()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                child.tag = "otherrope";
                RopeNode ropeNode = child.GetComponent<RopeNode>();
                if (ropeNode == null)
                    child.AddComponent<RopeNode>();
                child.gameObject.layer = 9;
            }
        }

        void ChangeLayersOfNodes()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                child.gameObject.layer = 6;
            }
        }
    }
}