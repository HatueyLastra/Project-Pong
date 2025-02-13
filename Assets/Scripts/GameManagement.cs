using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManagement : MonoBehaviour
{
    public static int PointsP1 = 0;
    public static int PointsP2 = 0;

    int pointCounterP1 = 0;
    int pointCounterP2 = 0;

    int numberOfSets;
    public int maxPoints = 10;

    public GameObject sets;
    private GameObject set;
    int previousSet;

    public GameObject powers;
    int powersGroup;
    private GameObject power;
    public GameObject spawnAnimation;
    private Vector3 spawnAnimationPosition;

    // Para que no se repitan poderes
    int previousPower = -1;
    int previousPower2 = -1;


    public int specialPower;

    public TextMeshProUGUI PointsTxt1;
    public TextMeshProUGUI PointsTxt2;
    public static bool generatePower;
    void Start()
    {
        spawnAnimationPosition = spawnAnimation.transform.position;
        powersGroup = powers.transform.GetChild(0).childCount;
        specialPower = Random.Range(0,6);
        numberOfSets = sets.transform.childCount;
        StartCoroutine(Special());
        generatePower = true;
}
    void Update()
    {
        // Genera un poder
        if (generatePower)
            PowerGenerator();

        // Se encarga de mostrar los contadores en tiempo real
        PointsTxt1.text = PointsP1.ToString();
        PointsTxt2.text = PointsP2.ToString();

        // Detecta que se haya anotado un punto
        if ((PointsP1 != pointCounterP1) || (PointsP2 != pointCounterP2))
        {
            if(set != null)
            {
                set.SetActive(false);  // Hace desaparecer el set actual
            }
            ChangeSet();

            pointCounterP1 = PointsP1;
            pointCounterP2 = PointsP2;

        }
        // Si se llega a un cierto número de puntos, se gana la partida
        if (PointsP1 == maxPoints)
        {
            SceneManager.LoadScene(2);
        }
        if (PointsP2 == maxPoints)
        {
            SceneManager.LoadScene(3);
        }


    }

    void PowerGenerator()
    {
        // Update no genera poder por ahora
        generatePower = false;

        powersGroup = powers.transform.GetChild(0).childCount;
        int randomPower = Random.Range(0, powersGroup);
        while ((randomPower == previousPower) || (randomPower == previousPower2))
        randomPower = Random.Range(0, powersGroup);
        if((PointsP1 < 5) && (PointsP2 < 5)){
            power = powers.transform.GetChild(0).transform.GetChild(randomPower).gameObject;
            StartCoroutine(Spawn(power));
        }
        else
        {
            power = powers.transform.GetChild(1).transform.GetChild(randomPower).gameObject;
            StartCoroutine(Spawn(power));
        }
        previousPower2 = previousPower;
        previousPower = randomPower;

    }

    public IEnumerator Special()
    {
        yield return new WaitForSeconds(120f);
        if (specialPower == 0)
           StartCoroutine(Spawn(powers.transform.GetChild(2).transform.GetChild(0).gameObject));
        yield return new WaitForSeconds(60f);
        if (specialPower == 1)
           StartCoroutine(Spawn(powers.transform.GetChild(2).transform.GetChild(1).gameObject));
    }
    public void ChangeSet()
    {
        int num = Random.Range(0, numberOfSets);
        while (previousSet == num)
            num = Random.Range(0, 6);
        set = sets.transform.GetChild(num).gameObject;
        set.SetActive(true);
        previousSet = num;
    }

    public IEnumerator Spawn(GameObject power)
    {
        if(((PointsP1 < 6) || (PointsP2 < 6)) || (PointsP1 == PointsP2))
        {
            float x = Random.Range(-5.5f, 5.5f);
            float y = Random.Range(-3.5f, 3.5f);
            Vector3 randomPosition = new Vector3(x, y, 0);
            spawnAnimation.transform.position = randomPosition;
            yield return new WaitForSeconds(3f);
            spawnAnimation.transform.position = spawnAnimationPosition;
            power.transform.position = randomPosition;
        }
        else if (PointsP1 < PointsP2)
        {
            float x = Random.Range(-5.5f, 0f);
            float y = Random.Range(-3.5f, 3.5f);
            Vector3 randomPosition = new Vector3(x, y, 0);
            spawnAnimation.transform.position = randomPosition;
            yield return new WaitForSeconds(3f);
            spawnAnimation.transform.position = spawnAnimationPosition;
            power.transform.position = randomPosition;
        }
        else if (PointsP2 < PointsP1)
        {
            float x = Random.Range(0f, 5.5f);
            float y = Random.Range(-3.5f, 3.5f);
            Vector3 randomPosition = new Vector3(x, y, 0);
            spawnAnimation.transform.position = randomPosition;
            yield return new WaitForSeconds(3f);
            spawnAnimation.transform.position = spawnAnimationPosition;
            power.transform.position = randomPosition;
        }
    }
}
