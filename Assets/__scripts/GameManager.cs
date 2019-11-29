using Assets.__scripts;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
      public static GameObject ActiveNode;
      public GameObject BuyTurretUI;
      public GameObject SellTurretUI;



      public static int GameStat_Health = 30;
      public static int GameStat_Money = 100;
      public static int GameStat_CurrentWave = 1;

      public TextMeshProUGUI Health;
      public TextMeshProUGUI Money;
      public TextMeshProUGUI Current;

      public GameObject GameOver;
      public TextMeshProUGUI GameOverInfo;

      void Start()
      {
            Health.text = GameStat_Health.ToString();
            Money.text = GameStat_Money.ToString();
            Current.text = GameStat_CurrentWave + "/6";
      }

      void Update()
      {
            Health.text = GameStat_Health.ToString();
            Current.text = GameStat_CurrentWave + "/6";
            Money.text = GameStat_Money.ToString();

            if (GameStat_Health <= 0)
            {
                  GameOver.SetActive(true);
                  foreach (var enemy in GameObject.FindGameObjectsWithTag("enemy"))
                  {
                        enemy.GetComponent<Enemy>().Speed = 0;
                  }
                  GameOverInfo.text = "YOU LOST";
            }

            if (GameStat_CurrentWave == 6)
            {
                  if (GameObject.FindGameObjectsWithTag("enemy").Length == 0)
                  {
                        GameOver.SetActive(true);
                        GameOverInfo.text = "YOU WON";
                  }
            }
      }

      public void BuildTower(int i)
      {
            var turretTB = Builder.Instance.GetTurret(i);
            if (GameStat_Money < turretTB.Price[0])
            {
                  return;
            }

            ActiveNode.GetComponent<Node>().Turret = (GameObject)Instantiate(turretTB.TurretPrefab, ActiveNode.transform.position + new Vector3(0, .5f, 0), ActiveNode.transform.rotation);
            ActiveNode.GetComponent<Node>().Turret.GetComponent<Turret>().GetValues(turretTB, i, 0);
            foreach (var renderer in ActiveNode.GetComponent<Node>().Turret.GetComponentsInChildren<Renderer>())
            {
                  renderer.material = turretTB.Materials[0];
            }
            GameStat_Money -= turretTB.Price[0];
            Money.text = GameStat_Money.ToString();
            BuyTurretUI.SetActive(false);
      }

      public void UpgradeTower()
      {
            var type = ActiveNode.GetComponent<Node>().Turret.GetComponent<Turret>().Type;
            var level = ActiveNode.GetComponent<Node>().Turret.GetComponent<Turret>().Level;
            var turretTB = Builder.Instance.GetTurret(type);

            if (GameStat_Money < turretTB.Price[level])
            {
                  return;
            }
            if (level == 3)
            {
                  return;
            }


            ActiveNode.GetComponent<Node>().Turret.GetComponent<Turret>().GetValues(turretTB, type, level);
            foreach (var renderer in ActiveNode.GetComponent<Node>().Turret.GetComponentsInChildren<Renderer>())
            {
                  renderer.material = turretTB.Materials[level];
            }

            GameStat_Money -= turretTB.Price[level];
            Money.text = GameStat_Money.ToString();
            SellTurretUI.SetActive(false);
      }

      public void SellTower()
      {
            var type = ActiveNode.GetComponent<Node>().Turret.GetComponent<Turret>().Type;
            var level = ActiveNode.GetComponent<Node>().Turret.GetComponent<Turret>().Level;
            var turretTB = Builder.Instance.GetTurret(type);


            GameStat_Money += turretTB.Price[level - 1]/2;
            Money.text = GameStat_Money.ToString();

            Destroy(ActiveNode.GetComponent<Node>().Turret);
            SellTurretUI.SetActive(false);
      }

      public void ReturnToMenu()
      {
            SceneManager.LoadScene(0);
      }
}
