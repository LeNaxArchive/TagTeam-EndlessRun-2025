using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegementGenerator : MonoBehaviour
{
    public GameObject[] segment;
    [SerializeField] int zPos = 5;
    [SerializeField] int pluszPos = 15;
    [SerializeField] bool creatingSegment = false;
    [SerializeField] int segmentNum;


    void Update()
    {
        if(creatingSegment == false)
        {
            creatingSegment = true;
            StartCoroutine(SegmentGen());
        }
        
    }

    IEnumerator SegmentGen()
    {
        segmentNum = Random.Range(0, 2);
        Instantiate(segment[segmentNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += pluszPos;
        yield return new WaitForSeconds(3);
        creatingSegment = false;
    }

}
