using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public float followSpeed = 1f;
    public GameObject prefab;

    private bool collidedWithPlayer = false;
    private GameObject player;
    private ParticleSystem particles;
    private bool explosionSequenceCommenced = false;
    private bool newOrbSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        // destroy object at the end of the explosion sequence
        if(explosionSequenceCommenced && !particles.IsAlive())
        {
            Destroy(this.gameObject);
        }

        // spawn new orb on explosion commenced
        if(explosionSequenceCommenced && !newOrbSpawned)
        {
            SpawnOrb();
            newOrbSpawned = true;
        }

        if (collidedWithPlayer)
        {
            // fade out component
            MeshRenderer mr = GetComponent<MeshRenderer>();
            Color targetColor = new Color(mr.material.color.r, mr.material.color.g, mr.material.color.b, 0);
            mr.material.color = Color.Lerp(mr.material.color, targetColor, Time.deltaTime * 5f);

            // play particle explosion if not already started
            if (!explosionSequenceCommenced)
            {
                particles.Play();
                explosionSequenceCommenced = true;
            }
        }
    }

    public void SpawnOrb()
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("Spawn");
        int rand = Random.Range(0, spawnPoints.Length - 1);
        GameObject spawnPoint = spawnPoints[rand];
        Instantiate(prefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        Debug.Log(spawnPoint.transform.position);
    }

    private void OnTriggerEnter(Collider collider) 
    {
        if (collider.gameObject.name == "Player")
        {
            player = collider.gameObject;
            collidedWithPlayer = true;
        }
    }
}
