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

    public bool canBePressed;
    public bool isHit;


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
    }


    //通过大小来判断是否能hit

    public void HitNote()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            //提前敲打
            if (transform.localScale.x > 1.75)
            {
                canBePressed = false;
                isHit = false;
                gameObject.SetActive(false);
                Debug.Log("W_Miss");
                //miss计数未写
            }
            //xiecuole
            else if (transform.localScale.x < 1.1)
            {
                canBePressed = false;
                isHit = false;
                gameObject.SetActive(false);
                Debug.Log("W_Miss");
                //miss计数未写
            }
            else
            {
                canBePressed = true;
                isHit = true;
                gameObject.SetActive(false);
                Debug.Log("W_Hit");
                //hit计数未写
            }
        }
        if (transform.localScale.x == 1.1)
        {
            gameObject.SetActive(false);
        }
    }

    private void ChangeNote(KoreographyEvent koreographyEvent, int sampleTime, int sampleDelta, DeltaSlice deltaSlice)
    {
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
