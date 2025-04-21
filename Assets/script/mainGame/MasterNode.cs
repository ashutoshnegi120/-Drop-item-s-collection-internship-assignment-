using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using System.Net.NetworkInformation;
using UnityEngine.Audio;

public class MasterNode : MonoBehaviour
{
    [SerializeField] private GameObject[] leftSpawn;
    [SerializeField] private GameObject[] rightSpawn;
    [SerializeField] public GameObject drop;
    [SerializeField] private GameObject backGround;
    [SerializeField] private Color[] color;
    [SerializeField] private GameObject leftPrefab;
    [SerializeField] private GameObject rightPrefab;
    [SerializeField] private float time = 0f;
    [SerializeField] private float timeSpeed = 0.2f;
    [SerializeField] private TextMeshProUGUI dayAndNight;
  
    public int health = 3;

    private void Start()
    {
        
        StartCoroutine(Spawn());
    }

    private void Update()
    {
        if (time <= 25f || time >= 75f)
        {
            dayAndNight.text = string.Format("Day");
        }
        else
        {
            dayAndNight.text = string.Format("Night");
        }
        DayAndNight();
       
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            int randomSide = Random.Range(0, 2);
            if (randomSide == 0)
            {
                Instantiate(leftPrefab, leftSpawn[Random.Range(0, 2)].transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(rightPrefab, rightSpawn[Random.Range(0, 2)].transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(Random.Range(3f,4f));
        }
    }

    private void DayAndNight()
    {
        time += Time.deltaTime * timeSpeed;

        if (time > 100f)
        {
            time = 0f;
        }
        UpdateDayNightCycle();
        
        
    }
    private void UpdateDayNightCycle()
    {

        float t = Mathf.PingPong(time / 50f, 1f);
        Color currentColor = Color.Lerp(color[0], color[1], t);
        backGround.GetComponent<SpriteRenderer >().color = currentColor;
    }





}
