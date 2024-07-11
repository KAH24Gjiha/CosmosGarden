using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMove : MonoBehaviour
{
    
    public Animator animator;
    public float directX;
    public float directY;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();

        StartCoroutine(Direction());
    }
    public void Move()
    {
        Debug.Log("움직이기");
        Vector3 velocity = new Vector3(directX, directY, 0) * Time.deltaTime * 0.3f;

        this.transform.position += velocity;

        if ((int)directX == 0 && (int)directY == 0) { animator.SetInteger("Move", 0);}
        else { animator.SetInteger("Move", 1); }

        if (directX > 0) this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        else if(directX < 0) this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
    }
    public void BackMove()
    {
        Debug.Log("뒷걸음");
        Vector3 velocity = new Vector3(directX, directY, 0) * Time.deltaTime * 0.3f;

        this.transform.position -= velocity;
    }
    

    public IEnumerator Direction()
    {
        while (true)
        {
            directX = Random.Range(-1, 2);
            directY = Random.Range(-1, 2);

            switch (directX)
            {
                case -1: { animator.SetInteger("Move", 1);this.gameObject.GetComponent<SpriteRenderer>().flipX = true; break; }
                case 0: { animator.SetInteger("Move", 0); break; }
                case 1: { animator.SetInteger("Move", 1); this.gameObject.GetComponent<SpriteRenderer>().flipX = false; break; }

            }
            animator.SetInteger("Move", (int)directX);
            yield return new WaitForSeconds(1.0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("콜라이더 닿음");
        if (collision.transform.CompareTag("land")) Move();
        else BackMove();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("콜라이더 닿음");
        if (collision.transform.CompareTag("land")) Move();
        else BackMove();
    }
}
