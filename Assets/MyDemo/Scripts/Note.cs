using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    //
    public bool canBePressed;

    public KeyCode keyToPress;

    //������
    public float temp = 126.4f; 


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //��ʱ�����õ��ƶ�
        transform.position -= new Vector3(temp * Time.deltaTime /60f, 0f , 0f);
        //����
        if(Input.GetKeyDown(keyToPress))
        {
            //�ж��Ƿ��ǿ��԰���
            //�����ж�д��GameManager�ϣ�Ȼ����õ�����ȽϺã�������GameManager������֣�
            if (canBePressed)
            {
                gameObject.SetActive(false);
                GameManager.instance.hitNote();
                //������дhit�ȼ����ж�
            }   
        }        
    }

    //������TagΪActivator,canBePressedִ��
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Activator"))
        {
            canBePressed = true;
        }
    }

    //�뿪�����������ٱ�canBePressed
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Activator"))
        {
            canBePressed = false;
            GameManager.instance.missHit();
        }
    }
}