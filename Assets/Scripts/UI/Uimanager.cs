using UnityEngine;
using UnityEngine.UI;

namespace FG
{
    public class Uimanager
    {
        private static Uimanager instance;
        private Menu textfield;
        private Input player;
        public static Uimanager Instance
        {
            get
            {
                if(instance == null)
                    instance = new Uimanager();
                return instance;
            }
        }

        private Uimanager()
        {
            textfield = GameObject.Find("Canvas").GetComponentInChildren<Menu>();
            player = GameObject.Find("Player").GetComponent<Input>();
        }

        public void OnNavigation(int input)
        {
            if (input == -1)
                return;

            textfield.gameObject.SetActive(false);
            try
            {
                Transform temp = textfield.Getsubitem(input);
                if (temp.GetComponent<Menu>() != null)
                {
                    Menu test = temp.GetComponent<Menu>();
                    textfield = test;
                    player.Toggleghost(null);
                }
                else if(temp.GetComponent<Building>() != null)
                {
                    Factory test = temp.GetComponent<Factory>();
                    player.Toggleghost(temp);
                }
                else if(temp.GetComponent<Pathfinder>() != null)
                {
                    Factorymanager.Instance.Create(temp);
                }
                    
            }
            catch(System.Exception e)
            {
                Debug.LogError(e);
            }
            textfield.gameObject.SetActive(true);
        }
    }
}