using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float hareketHizi;

    [SerializeField]
    float ziplamaGucu;
    Animator anim;

    bool yonSagmi;

    bool yerdemi;
    public Transform zeminKontrolNoktasi;
    public LayerMask zeminLayer;
    bool ikiKezZýplayabilirmi;

    public float geriTepmeSuresi, geriTepmeGucu;
    float geriTepmeSayac;
    public float zýplaZýplaGucu;

    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (geriTepmeSayac<=0)
        {
            HareketEttirFNC();
            ZiplaFNC();
            YonuDegistir();
        }
        else
        {
            geriTepmeSayac-= Time.deltaTime;

            if (yonSagmi)
            {
                rb.velocity = new Vector2(-geriTepmeGucu, rb.velocity.y);

            }
            else
            {
                rb.velocity = new Vector2(+geriTepmeGucu, rb.velocity.y);
            }

        }



        anim.SetFloat("hareketHizi", Mathf.Abs(rb.velocity.x));
        anim.SetBool("yerdemi", yerdemi);
    }

    void HareketEttirFNC()
    {
        float h = Input.GetAxis("Horizontal");
        float hiz = h * hareketHizi;

        rb.velocity = new Vector2(hiz, rb.velocity.y);
    }


    void ZiplaFNC()
    {
        if (yerdemi)
        {
            ikiKezZýplayabilirmi = true;

        }

        if (Input.GetButtonDown("Jump"))
        {
            yerdemi = Physics2D.OverlapCircle(zeminKontrolNoktasi.position, .2f, zeminLayer);
            if (yerdemi)
            {
                rb.velocity = new Vector2(rb.velocity.x, ziplamaGucu);
                SesController.Ýnstance.SesEfektiCikar(3);

            }
            else
            {
                if (ikiKezZýplayabilirmi)
                {
                    rb.velocity = new Vector2(rb.velocity.x, ziplamaGucu);
                    ikiKezZýplayabilirmi = false;
                    SesController.Ýnstance.SesEfektiCikar(3);

                }
            }


        }
        
       



    }
 
    void YonuDegistir()
    {
        Vector2 geciciScale = transform.localScale;
        if (rb.velocity.x > 0)
        {
            yonSagmi = true;
            geciciScale.x = 1f;

        }
        else if (rb.velocity.x < 0)
        {
            yonSagmi=false;
            geciciScale.x = -1f;


        }
        transform.localScale = geciciScale;
    }

    public void GeritepmeFNC()
    {
        geriTepmeSayac = geriTepmeSuresi;
        rb.velocity=new Vector2(0,rb.velocity.y);

        anim.SetTrigger("Hasar");
    }

    public void ZýplaZýplaFNC()
    {

        rb.velocity = new Vector2(rb.velocity.x, zýplaZýplaGucu);
        SesController.Ýnstance.SesEfektiCikar(3);
    }


}
