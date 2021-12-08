using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace FG
{
    public class Input : MonoBehaviour
    {
        [SerializeField] private float speed = 1;
        [SerializeField] private float rotspeed = 1;
        [SerializeField] private float gravityscale;
        [SerializeField] private float blueprintrange = 15f;

        private float rot = 0f;
        private Vector2 dir = new Vector2();
        private Rigidbody body;
        private Transform obj;
        private Camera cam;
        private Vector3 objpos;
        private int floormask;
        private Transform currentfab;

        public void Toggleghost(Transform gofab)
        {
            if (obj != null && gofab == null || currentfab != null && currentfab == gofab)
            {
                Destroy(obj.gameObject);
                currentfab = null;
            }
            else if (obj == null && gofab != null)
            {
                obj = Instantiate(gofab, transform.position + transform.forward * 4, Quaternion.identity, transform);

                obj.position = transform.position + transform.forward * 4 - Vector3.up * gofab.transform.localScale.y * 0.5f;

                currentfab = gofab;
            }
        }

        private void Awake()
        {
            body = gameObject.GetComponent<Rigidbody>();

            cam = Camera.main;

            floormask = LayerMask.GetMask("Floor");
        }

        private void Move()
        {
            Vector3 velocity = new Vector3();

            if (dir.x != 0)
                velocity += transform.right.normalized * dir.x * speed;
            if (dir.y != 0)
                velocity += transform.forward.normalized * dir.y * speed;

            body.velocity = velocity;
        }

        private void Rotate()
        {
            body.angularVelocity = Vector3.zero;

            transform.Rotate(new Vector3(0, rot, 0) * rotspeed * Time.deltaTime);
        }

        private void Movebp()
        {
            if (obj != null)
            {
                Vector3 pos = new Vector3(0, 0, -10);

                if (Physics.Raycast(cam.ScreenPointToRay(objpos), out RaycastHit info, blueprintrange, floormask))
                {
                    pos = info.point + Vector3.up * obj.transform.localScale.y * 0.5f;

                    obj.position = pos;
                }
            }
        }

        private void Gravity()
        {
            body.velocity += new Vector3(0, -1, 0) * gravityscale;
        }

        private void FixedUpdate()
        {
            Move();

            Rotate();

            Movebp();

            Gravity();
        }

        private void OnMove(InputValue input)
        {
            dir = input.Get<Vector2>();
        }

        private void OnTurn(InputValue input)
        {
            rot = input.Get<float>();
        }

        private void OnLook(InputValue input)
        {
            objpos = input.Get<Vector2>();
        }

        private void OnNavigation(InputValue input)
        {
            Uimanager.Instance.OnNavigation(Vec2toint(input.Get<Vector2>()));
        }

        private void OnFire(InputValue input)
        {
            if (obj != null)
            {
                obj.parent = null;
                obj = null;
                currentfab = null;
            }
        }

        private int Vec2toint(Vector2 input)
        {
            if (input == new Vector2(0, 1))
                return 0;// 'Z';
            else if (input == new Vector2(0, -1))
                return 1;// 'X';
            else if (input == new Vector2(1, 0))
                return 2;// 'C';
            else if (input == new Vector2(-1, 0))
                return 3;// 'V';
            else
                return -1;// '.';
        }
    }
}