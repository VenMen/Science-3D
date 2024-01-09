using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _listOfStructures;
    private void Start()
    {
        float str = 0;
        int z = 20;
        float summ = 0;
        while (z < 201)
        {
            int randomStructureNumber = Random.Range(0, _listOfStructures.Length);
            GameObject struc = Instantiate(_listOfStructures[randomStructureNumber], new Vector3(0, 0, z), Quaternion.identity);
            summ = summ + struc.GetComponent<OwnRating>().rating;
            str = str + 1;
            z = z + 20;
        }

        float endRating = summ / str;
        Debug.Log(endRating);
    }
}
