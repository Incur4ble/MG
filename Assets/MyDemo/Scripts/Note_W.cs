using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class Note_W : MonoBehaviour
{
    //动画效果更改使用SpriteRenderer

    public string eventID;

    public float maxScale = 2f;
    public float minScale = 1f;


    public KeyCode keyToPress;


    // Start is called before the first frame update
    void Start()
    {
        //调用
        Koreographer.Instance.RegisterForEventsWithTime(eventID, ChangeNote);
    }

    // Update is called once per frame
    void Update()
    {
        HitNote();
        //Debug.Log(transform.localScale.x);
    }


    //通过大小来判断是否能hit

    public void HitNote()
    {
        //Debug.Log(Input.GetKeyDown(keyToPress));
        if (Input.GetKeyDown(keyToPress))
        {
            //提前敲打
            if (transform.localScale.x > 1.75)
            {

                gameObject.SetActive(false);
                Debug.Log("W_Miss");
                //Debug.Log(transform.localScale);
                //miss计数未写
            }
            else if (transform.localScale.x < 1.1)
            {

                gameObject.SetActive(false);
                Debug.Log("W_Miss");
                //Debug.Log(transform.localScale);
                //miss计数未写
            }
            else
            {

                gameObject.SetActive(false);
                Debug.Log("W_Hit");
                //Debug.Log(transform.localScale);
                //hit计数未写
            }
        }
        else
        {
            //Debug.Log(transform.localScale.x < 1.1);
            if (transform.localScale.x < 1.003)
            {
                gameObject.SetActive(false);

                Debug.Log("W_Miss!!!!!!!");
                //Debug.Log(transform.localScale);
            }
        }
    }

    private void ChangeNote(KoreographyEvent koreographyEvent, int sampleTime, int sampleDelta, DeltaSlice deltaSlice)
    {
        gameObject.SetActive(true);
        //Debug.Log(gameObject.active);

        //判定是否有curve负荷
        if (koreographyEvent.HasCurvePayload())
        {
            gameObject.SetActive(true);
            //获取负荷值
            float curveValue = koreographyEvent.GetValueOfCurveAtTime(sampleTime);
            //由符合值修改Scale属性
            transform.localScale = Vector3.one * Mathf.Lerp(minScale, maxScale, curveValue);      //lerp:插值
        }
    }
}
