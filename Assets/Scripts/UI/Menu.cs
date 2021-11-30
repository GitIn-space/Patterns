using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FG
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private Transform[] submenus = new Transform[4];

        public Menu Getsubmenu(int i)
        {
            if(i < 5 && i >= 0 && submenus[i] != null)
                return submenus[i].GetComponent<Menu>();
            throw new System.Exception();
        }
    }
}