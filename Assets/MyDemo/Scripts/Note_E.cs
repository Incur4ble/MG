using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class Note_E : MonoBehaviour
{
    //����Ч������ʹ��SpriteRenderer

    public string eventID;

    public float maxScale = 2f;
    public float minScale = 1f;

    public bool canBePressed;
    public bool isHit;


    public KeyCode keyToPress;


    // Start is called before the first frame update
    void Start()
    {
        //����
        Koreographer.Instance.RegisterForEventsWithTime(eventID, ChangeNote);
    }

    // Update is called once per frame
    void Update()
    {
        HitNote();
    }


    //ͨ����С���ж��Ƿ���hit

    public void HitNote()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            //��ǰ�ô�
            if (transform.localScale.x > 1.75)
            {
                canBePressed = false;
                isHit = false;
                gameObject.SetActive(false);
                Debug.Log("E_Miss");
                //miss����δд
            }
            //д����(?)
            else if (transform.localScale.x < 1.1)
            {
                canBePressed = false;
                isHit = false;
                gameObject.SetActive(false);
                Debug.Log("E_Miss");
                //miss����δд
            }
            else
            {
                canBePressed = true;
                isHit = true;
                gameObject.SetActive(false);
                Debug.Log("E_Hit");
                //hit����δд
            }
        }
        if (transform.localScale.x == 1.1)
        {
            Debug.Log("wrong!!!!!!!");
            gameObject.SetActive(false);
        }
    }

    private void ChangeNote(KoreographyEvent koreographyEvent, int sampleTime, int sampleDelta, DeltaSlice deltaSlice)
    {
        gameObject.SetActive(true);
        //�ж��Ƿ���curve����
        if (koreographyEvent.HasCurvePayload())
        {

            //��ȡ����ֵ
            float curveValue = koreographyEvent.GetValueOfCurveAtTime(sampleTime);
            //�ɷ���ֵ�޸�Scale����
            transform.localScale = Vector3.one * Mathf.Lerp(minScale, maxScale, curveValue);      //lerp:��ֵ
        }
    }
}
