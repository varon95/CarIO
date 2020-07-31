using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public int damage = 10;
    public float bulletSpeed = 200.0f;
    public GameObject bulletPrefab;

    public GameObject canvas;
    public GameObject bulletImg;
    float posX = 10;
    float posY = 10f;
    float deltaY = +30f;
    public int magazineSize = 3;
    List<GameObject> magazineList = new List<GameObject>();
    RectTransform rectTransform;
    int remainingBullets;
    public float reloadTime = 3f;
    float reloading = 0f;

    bool reloadBarBool = false;
    public GameObject reloadBarImg;
    float reloadBarPosY = 10f;
    private GameObject reloadBar;
    float reloadBarUnit;

    private void Start()
    {
        reload();
        remainingBullets = magazineSize;
        
    }

    private void FixedUpdate()
    {
        if (remainingBullets <= 0)
        {
            reloading += Time.deltaTime;
            calculateReloadBar();

            if (reloading >= reloadTime)
            {
                reloading = 0f;
                remainingBullets = magazineSize;
                Destroy(reloadBar);
                reloadBarBool = false;

                reload();
            }

        }
    }

    void Update()
    {
        if (remainingBullets<=0)
        {
            
        }
        else if (Input.GetMouseButtonDown(0))
        {
            //shotFreqTemp = shotFreq;
            GameObject bulletObject = Instantiate(bulletPrefab);
            bulletObject.GetComponent<bullet>().damage = damage;
            bulletObject.GetComponent<bullet>().speed = bulletSpeed;
            bulletObject.transform.position = transform.position;
            bulletObject.transform.rotation = transform.rotation;
            
            Destroy(magazineList[magazineList.Count - 1]);
            magazineList.RemoveAt(magazineList.Count - 1);
            remainingBullets -= 1;
        }
    }

    void reload()
    {
        for (int i = 0; i < magazineSize; i++)
        {
            GameObject bulletIcon = Instantiate(bulletImg);
            bulletIcon.transform.parent = canvas.transform;
            rectTransform = bulletIcon.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(posX, posY + i * deltaY, 0f);
            magazineList.Add(bulletIcon);
        }
    }

    void calculateReloadBar()
    {
        if (reloadBarBool)
        {
            
            reloadBar.transform.localScale -= new Vector3(0, reloadBarUnit * Time.deltaTime, 0);

        }
        //LOAD A NEW RELOAD BAR 
        else
        {
            reloadBar = Instantiate(reloadBarImg);
            reloadBar.transform.parent = canvas.transform;
            rectTransform = reloadBar.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(posX, reloadBarPosY, 0f);

            reloadBarUnit = (reloadBar.transform.localScale.y / reloadTime);

            reloadBarBool = true;
        }
    }

}
