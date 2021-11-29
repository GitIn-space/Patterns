using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace FG
{
    public class Uimanager : MonoBehaviour
    {
        [SerializeField] Text text;
        private void OnNavigation(InputValue input)
        {
            if(input.Get<Vector2>() == new Vector2(0, 1))
            {
                string newtext = "";
                foreach (Uienum.UIBase each in Enum.GetValues(typeof(Uienum.UIBuildings)))
                    newtext += each.ToString() + ',';

                string[] split = newtext.Split(',');
                int c = 0;
                newtext = "";
                foreach (Uienum.Keys each in Enum.GetValues(typeof(Uienum.Keys)))
                {
                    newtext += each.ToString() + ": " + split[c] + "\n";
                    c++;
                    if (c >= split.Length - 1)
                        break;
                }

                text.text = newtext;
            }
        }

        private void Awake()
        {
            string newtext = "";
            foreach (Uienum.UIBase each in Enum.GetValues(typeof(Uienum.UIBase)))
                newtext += each.ToString() + ',';

            string[] split = newtext.Split(',');
            int c = 0;
            newtext = "";
            foreach(Uienum.Keys each in Enum.GetValues(typeof(Uienum.Keys)))
            {
                newtext += each.ToString() + ": " + split[c] + "\n";
                c++;
                if (c >= split.Length - 1)
                    break;
            }

            text.text = newtext;
        }
    }
}