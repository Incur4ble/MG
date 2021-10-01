using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    //
    public bool canBePressed;

    public KeyCode keyToPress;

    //测试用
    public float temp = 126.4f; 


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //临时测试用的移动
        transform.position -= new Vector3(temp * Time.deltaTime /60f, 0f , 0f);
        //读键
        if(Input.GetKeyDown(keyToPress))
        {
            //判断是否是可以按的
            //按键判定写在GameManager上，然后调用到这里比较好（方便在GameManager上面积分）
            if (canBePressed)
            {
                gameObject.SetActive(false);
                GameManager.instance.hitNote();
                //可以续写hit等级的判定
            }   
        }        
    }

    //触碰到Tag为Activator,canBePressed执行
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Activator"))
        {
            canBePressed = true;
        }
    }

    //离开触发器，不再被canBePressed
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Activator"))
        {
            canBePressed = false;
            GameManager.instance.missHit();
        }
    }
}