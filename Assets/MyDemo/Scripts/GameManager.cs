using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //��̬����,���������ĵ���
    public static GameManager instance;




    // Start is called before the first frame update
    void Start()
    {
        instance = this;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hitNote()
    {
        Debug.Log("Hit");

    }

    public void missHit()
    {
        Debug.Log("Miss");
    }



}
