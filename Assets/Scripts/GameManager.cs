using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Dropper dropper;
    public List<GameObject> fruits;
    public GameObject fruit;
    public GameObject particleSys;
    public TMP_Text scoreText;
    public Image image;

    public List<GameObject> allFruits;

    private int score;
    private GameObject nextFruit;
    private List<GameObject> collidingObjects = new List<GameObject>();

    void Start()
    {
        dropper.AddFruit(fruits[Random.Range(0, fruits.Count)]);
        nextFruit = fruits[Random.Range(0, fruits.Count)];
        image.sprite = nextFruit.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
    }

    public void AddNextFruit()
    {
        Invoke("Test", 0.5f);
    }

    public void Test()
    {   
        dropper.AddFruit(nextFruit);
        nextFruit = fruits[Random.Range(0, fruits.Count)];
        image.sprite = nextFruit.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
        print(nextFruit.name);
        //dropper.AddFruit(fruits[Random.Range(0, fruits.Count)]);
    }

    public void MergeFruit(GameObject fruitA, GameObject fruitB, GameObject nextFruit)
    {
        //if (collisionDebounce) return;
        if (!fruitA || !fruitB) return;
        //collisionDebounce = true;

        collidingObjects.Add(fruitA);
        collidingObjects.Add(fruitB);

        if(collidingObjects.Count >= 4)
        {
            
            int i = 0;
            foreach (var item in allFruits)
            {
                i++;
                if(item.name == fruitA.name.Replace("(Clone)", "")) break;
            }
            score += i;
            scoreText.text = score.ToString();
            
            var newFruitPos = collidingObjects[0].transform.position;
            
            var particlesOfOGFruit = Instantiate(particleSys, newFruitPos, Quaternion.identity);
            var pSys1 = particlesOfOGFruit.GetComponent<ParticleSystem>().main;
            
            var particlesOfnewFruit = Instantiate(particleSys, newFruitPos, Quaternion.identity);
            var pSys2 = particlesOfnewFruit.GetComponent<ParticleSystem>().main;
            
            particlesOfOGFruit.transform.localScale = fruitA.transform.localScale / 1.5f ;
            particlesOfnewFruit.transform.localScale = nextFruit.transform.localScale / 1.5f ;

            pSys1.startColor = fruitA.GetComponent<SpriteRenderer>().color + new Color(0,0,0,1);
            pSys2.startColor = nextFruit.GetComponent<SpriteRenderer>().color + new Color(0,0,0,1);

            foreach (var item in collidingObjects)
            {
                if(item)Destroy(item);
            }
            collidingObjects.Clear();

            Instantiate(nextFruit, newFruitPos, Quaternion.identity);

            

            //collisionDebounce = false;
        }
    }

    public async void GameOver()
    {
        dropper.gameObject.SetActive(false);

        GameObject[] fruits = GameObject.FindGameObjectsWithTag("Fruit");

        foreach (var item in fruits)
        {
            if(item)
            {
                var particle = Instantiate(particleSys, item.transform.position, Quaternion.identity);
                var pSys = particle.GetComponent<ParticleSystem>().main;

                particle.transform.localScale = item.transform.localScale / 1.5f ;
                pSys.startColor = item.GetComponent<SpriteRenderer>().color + new Color(0,0,0,1);

                Destroy(item);

                await new WaitForSeconds(0.2f);
            }
        }

        await new WaitForSeconds(1f);
        SceneManager.LoadScene("SampleScene");
    }

}
