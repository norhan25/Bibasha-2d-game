using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator anim;
  
    public Transform AttackPoint;
    public float AttackRange = .4f;
    public LayerMask EnemyLayer;
    int SimpleHitCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SoundManager.PlaySound("PlayerAttack");
            SimpleAttack();
        }
    }

    void SimpleAttack()
    {
        anim.SetTrigger("SimpleAttack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayer);

        foreach (Collider2D Enemy in hitEnemies)
        {
            if (Enemy.tag.Equals("SkeletonEnemy"))
            {
                SimpleHitCount++;
                // If we hit same enemy twice He will die
                if (SimpleHitCount == 2)
                {
                    Destroy(Enemy.gameObject);

                    SimpleHitCount = 0; // changing back hit Count to zero for calculation of other enemies
                }
            }
            else if (Enemy.tag.Equals("Bosslvl1"))
            {
                
                BossHealth.TakeDamage(15);
                if (BossHealth.currhealth < 5)
                {
                    BossHealth.Bossanim.SetTrigger("IsDead");
                    Level_Manager.lvl1_completed = true;
                    Destroy(Enemy.gameObject);
                }
            }
            else if (Enemy.tag.Equals("Bosslvl2"))
            {

                BossHealth.TakeDamage(30);
                if (BossHealth.currhealth < 5)
                {
                    BossHealth.Bossanim.SetTrigger("IsDead");
                    Level_Manager.lvl2_completed = true;
                    Destroy(Enemy.gameObject);
                }
            }
            else if (Enemy.tag.Equals("Bosslvl3"))
            {

                BossHealth.TakeDamage(45);
                if (BossHealth.currhealth < 5)
                {
                    BossHealth.Bossanim.SetTrigger("IsDead");
                    Level_Manager.lvl3_completed = true;
                    Destroy(Enemy.gameObject);
                }
            }
        }

    
    }


    // This Function is used to Draw on screen the Sphere on Attack point
    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange); 
    }

    IEnumerator BossDie(float time)
    {
        yield return new WaitForSeconds(time);

        Debug.Log("Boss Died");
    }


    
}
