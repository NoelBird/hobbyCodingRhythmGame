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
                // Resources/Prefabs/Bullet.prefab �ε�
                GameObject bullet = MonoBehaviour.Instantiate(prefab) as GameObject;
                // ���� �ν��Ͻ� ����. GameObject name�� �⺻���� Bullet (clone)
                bullet.name = "bullet"; // name�� ����
                bullet.transform.parent = transform;
                // bullet�� player�� �Ծ��ϴµ� �ʱ�ȭ�۾� ����
            spriteRenderer.sprite = pressedImage;
        }

        if(Input.GetKeyUp(keyToPress))
        {
            spriteRenderer.sprite = defaultImage;
        }
    }
}
