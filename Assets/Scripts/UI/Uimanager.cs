using UnityEngine;
using UnityEngine.UI;

namespace FG
{
    public class Uimanager
    {
        private static Uimanager instance;
        private Menu textfield;
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
        }

        public void OnNavigation(int input)
        {
            if (input == -1)
                return;

            textfield.gameObject.SetActive(false);
            try
            {
                textfield = textfield.Getsubmenu(input);
            }
            catch(System.Exception e)
            {
                Debug.LogError(e);
            }
            textfield.gameObject.SetActive(true);
        }
    }
}