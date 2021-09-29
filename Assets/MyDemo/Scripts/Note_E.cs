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
        //Debug.Log(transform.localScale.x);
    }


    //ͨ����С���ж��Ƿ���hit

    public void HitNote()
    {
        //Debug.Log(Input.GetKeyDown(keyToPress));
        if (Input.GetKeyDown(keyToPress))
        {
            //��ǰ�ô�
            if (transform.localScale.x > 1.75)
            {

                gameObject.SetActive(false);
                Debug.Log("E_Miss");
                //Debug.Log(transform.localScale);
                //miss����δд
            }
            else if (transform.localScale.x < 1.1)
            {

                gameObject.SetActive(false);
                Debug.Log("E_Miss");
                //Debug.Log(transform.localScale);
                //miss����δд
            }
            else
            {
                gameObject.SetActive(false);
                Debug.Log("E_Hit");
                //Debug.Log(transform.localScale);
                //hit����δд
            }
        }
        else
        {
            //Debug.Log(transform.localScale.x < 1.1);
            //����ط����ж�Ϊ1.002��Ҫ����Ϊ�����ҵ�koreograph��curveû�����٣�������֪����СֵΪ1.00158���������޷����ڣ��ڶ�С��ֵ1.006������������Ϊ1.002
            //E��curve����Ϊ���������������Ҫ���в������ж��ٽ�ֵ
            if (transform.localScale.x <= 1.002)
            {
                gameObject.SetActive(false);
                
                Debug.Log("E_Miss");
                //Debug.Log(transform.localScale);
            }
        }
    }

    private void ChangeNote(KoreographyEvent koreographyEvent, int sampleTime, int sampleDelta, DeltaSlice deltaSlice)
    {
        gameObject.SetActive(true);

        //Debug.Log(gameObject.active);

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
