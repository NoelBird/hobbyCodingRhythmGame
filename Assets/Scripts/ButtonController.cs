using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
                GameObject prefab = Resources.Load("BlueBall") as GameObject;
                // Resources/Prefabs/Bullet.prefab 로드
                GameObject bullet = MonoBehaviour.Instantiate(prefab) as GameObject;
                // 실제 인스턴스 생성. GameObject name의 기본값은 Bullet (clone)
                bullet.name = "bullet"; // name을 변경
                bullet.transform.parent = transform;
                // bullet을 player에 입양하는등 초기화작업 수행
            spriteRenderer.sprite = pressedImage;
        }

        if(Input.GetKeyUp(keyToPress))
        {
            spriteRenderer.sprite = defaultImage;
        }
    }
}
