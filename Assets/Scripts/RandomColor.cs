using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomColor : MonoBehaviour
{
    [SerializeField] private Image an_image;
    [SerializeField] private float changeInterval = 1.0f;
    private float localChangeInterval;

    // Start is called before the first frame update
    void Start()
    {
        localChangeInterval = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        localChangeInterval += Time.deltaTime;

        if (localChangeInterval < changeInterval) return;
        
        localChangeInterval -= changeInterval;

        an_image.color = new Color(Random.value, Random.value, Random.value);

    }
}
