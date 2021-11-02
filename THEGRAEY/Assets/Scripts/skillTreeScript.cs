using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillTreeScript : MonoBehaviour
{
    public Text Attribute;
    public Text Name;
    public Text Desc;
    public GameObject Selector;

    public Vector3 MosPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MosPos = Input.mousePosition;

        Selector.transform.rotation = Quaternion.Euler(MosPos);
        Debug.Log(Input.mousePosition);
    }
}
