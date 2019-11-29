using Assets.__scripts;
using UnityEngine;

public class Node : MonoBehaviour
{
      public GameObject Turret;

      public GameObject BuyTurretUI;
      public GameObject SellTurretUI;

      void OnMouseDown()
      {
            BuyTurretUI.SetActive(false);
            SellTurretUI.SetActive(false);

            GameManager.ActiveNode = gameObject;

            if (Turret == null)
            {
                  BuyTurretUI.SetActive(true);
            }
            else
            {
                  SellTurretUI.SetActive(true);
            }
      }
}
