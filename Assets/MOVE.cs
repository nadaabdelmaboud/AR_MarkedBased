using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class MOVE : MonoBehaviour,IVirtualButtonEventHandler
{
  
    public GameObject obj;
   public VirtualButtonBehaviour left;
   public VirtualButtonBehaviour right;
   public VirtualButtonBehaviour zin;
   public VirtualButtonBehaviour zout;
   public VirtualButtonBehaviour sound;
    bool leftbtn, rightbtn, zinbtn, zoutbtn;
    float l = 0;
    int r = 0;
    float zi = 0;
    float zo = 0;
    int index = 0;
    public GameObject soundon;
    public GameObject soundoff;
    private void Start()
    {
        leftbtn = false;
        rightbtn = false;
        zinbtn = false;
        zoutbtn = false;
        left.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        
        right.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        
        zin.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        
        zout.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        sound.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        soundon.SetActive(false);
    }
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (vb.name=="Sound") {
            if (index == 0)
            {
                Debug.Log("Sound on");
                index = 1;
                this.gameObject.GetComponent<AudioSource>().Play();
                soundoff.SetActive(false);
                soundon.SetActive(true);
                
            }
            else if(index==1) {
                Debug.Log("Sound off");
                index = 0;
                this.gameObject.GetComponent<AudioSource>().Stop();
                soundon.SetActive(false);
                soundoff.SetActive(true);
               
            }
        }
        if (vb.name == "Left")
        {
            leftbtn = true;
            Debug.Log("left");
        }
        else if (vb.name == "Right")
        {
            rightbtn = true;
            Debug.Log("right");
        }
        else if (vb.name == "IN")
        {
            zinbtn = true;
            Debug.Log("zin");
        }
        else if (vb.name == "OUT")
        {
            zoutbtn = true;
            Debug.Log("zout");
        }
    }
    

    public void OnButtonReleased(VirtualButtonBehaviour vb)
       
    {
      
        if (vb.name == "Left")
        {
            leftbtn = false;
            Debug.Log("unleft");
        }
        else if (vb.name == "Right")
        {
            rightbtn = false;
            Debug.Log("right");
        }
        else if (vb.name == "IN")
        {
            zinbtn = false;
            Debug.Log("zin");
        }
        else if (vb.name == "OUT")
        {
            zoutbtn = false;
            Debug.Log("zout");
        }
    }
    private void Update()
    {

        if (leftbtn)
        {
            l += .1f;
           obj.transform.Rotate(0, Time.deltaTime*l, 0);
        }
        if (rightbtn)
        {
            l += .1f;
            obj.transform.Rotate(0, -1*Time.deltaTime * l, 0);
        }
        if (zinbtn)
        {
            zi += .01f;
            obj.transform.localScale += new Vector3(Time.deltaTime * zi, Time.deltaTime *zi, Time.deltaTime * zi);
        }
        if (zoutbtn)
        {
            zo += .01f;
            if(obj.transform.localScale.y>=0&& obj.transform.localScale.x>=0&& obj.transform.localScale.z>=0) obj.transform.localScale -= new Vector3(Time.deltaTime * zo, Time.deltaTime * zo, Time.deltaTime * zo);
        }
    }
   
}
