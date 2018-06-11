using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public Text waveCountdownText;

    private int waveNumber = 1;
    

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        float i = Mathf.Floor(countdown);
        if (i > 0)
        {
            waveCountdownText.text = i.ToString();
        }
        else
        {
            waveCountdownText.text = "Wave " + waveNumber + " Incomming!";        }
        
    }

    IEnumerator SpawnWave()
    {
        Debug.Log("Wave "+ waveNumber +  " Incomming!");

        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.2f);
        }

        waveNumber++;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
