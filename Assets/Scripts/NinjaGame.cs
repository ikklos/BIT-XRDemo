using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NinjaGame : MonoBehaviour
{
    public Transform focusPoint;
    public GameObject prefab;
    public GameObject text;
    public TextMeshProUGUI textMesh;
    private bool gameRunning = false;
    private float offsetTime = 0.0f;
    private int score = 0;
    private BoxCollider boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        if (focusPoint == null)
        {
            focusPoint = transform;
            focusPoint.position += new Vector3(0, 1, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameRunning)
        {
            offsetTime -= Time.deltaTime;
            if (offsetTime <= 0.0f)
            {
                offsetTime = Random.Range(0f, 1.2f);
                GenerateBall();
            }
            textMesh.text = string.Format("Score:{0}", score);
        }
    }

    void GenerateBall()
    {
        Vector3 pos = new Vector3();
        Vector3 boxSize = boxCollider.size;
        pos.x = Random.Range(boxCollider.transform.position.x - boxSize.x/2.0f,boxCollider.transform.position.x + boxSize.x / 2.0f);
        pos.y = Random.Range(boxCollider.transform.position.y - boxSize.y/2.0f,boxCollider.transform.position.y + boxSize.y / 2.0f);
        pos.z = Random.Range(boxCollider.transform.position.z - boxSize.z/2.0f,boxCollider.transform.position.z + boxSize.z / 2.0f);
        Object obj = Instantiate(prefab, pos, Quaternion.identity);
        CutBall script = obj.GetComponent<CutBall>();
        script.SetCuttedHandler(() =>
        {
            score++;
        });
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        Vector3 force =  focusPoint.position - pos;
        force.Normalize();
        rb.AddForce(force * Random.Range(6.0f,7.5f), ForceMode.Impulse);
    }

    void StartGame()
    {
        gameRunning = !gameRunning;
        if (gameRunning)
        {
            score = 0;
            text.SetActive(true);
        }
        else
        {
            text.SetActive(false);
        }
    }
}
