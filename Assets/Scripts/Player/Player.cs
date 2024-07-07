using UnityEngine;

public class Player : MonoBehaviour
{
    public ItemComponent.PlayerType playerType;
    public int playerLV;
    public float maxHealth;
    public float currentHealth;
    public float maxMana;
    public float currentMana;
    public float physicalDefense;
    public float magicalDefense;
    public float timeWait;
    public bool button;
    public Animator anim;
    public BaseStats baseStats;
    public float Damage;
    public bool PhysicalOrMagical;

    public void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        baseStats = gameObject.GetComponent<BaseStats>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerLV = baseStats.playerLV;
        maxHealth = baseStats.maxHealth;
        currentHealth = maxHealth;
        maxMana = baseStats.maxMana;
        currentMana = maxMana;
        gameObject.GetComponent<Attack>().attackDamage = baseStats.attackDamage;
        physicalDefense = baseStats.physicalDefense;
        magicalDefense = baseStats.magicalDefense;
    }

    // Update is called once per frame
    void Update()
    {
        hurt_death();
    }

    public void hurt_death()
    {
        if (Damage > 0)
        {
            if (PhysicalOrMagical && (Damage - physicalDefense) > 0)
            {
                currentHealth -= (Damage - physicalDefense);
            }
            else
            if (!PhysicalOrMagical && (Damage - magicalDefense) > 0)
            {
                currentHealth -= (Damage - magicalDefense);
            }
            currentHealth = Mathf.Round(currentHealth);
            Damage = 0;

            if (currentHealth > 0)
            {
                anim.SetTrigger("Hurt");
            }
            else
            {
                anim.SetTrigger("Death");
                Invoke("destroy", 1f);
            }
        }
    }

    public void takeDamage(float damage, bool physicalormagical)
    {
        Damage = damage;
        PhysicalOrMagical = physicalormagical;
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this, gameObject.GetComponent<Stats>(), gameObject.GetComponent<Inventory>());
        GameObject.FindGameObjectWithTag("EnemySystem").GetComponent<EnemySystem>().SaveEnemy();
        GameObject.FindGameObjectWithTag("ItemSystem").GetComponent<ItemSystem>().SaveItem();
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        GameObject.FindGameObjectWithTag("EnemySystem").GetComponent<EnemySystem>().LoadEnemy();
        GameObject.FindGameObjectWithTag("ItemSystem").GetComponent<ItemSystem>().LoadItem();
        playerLV = data.playerLV;
        maxHealth = data.maxHealth;
        currentHealth = data.currentHealth;
        maxMana = data.maxMana;
        currentMana = data.currentMana;
        gameObject.GetComponent<Attack>().attackDamage = data.attackDamage;
        physicalDefense = data.physicalDefense;
        magicalDefense = data.magicalDefense;

        gameObject.GetComponent<Inventory>().itemList = data.itemList;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

    void destroy()
    {
        GameObject.Find("System Change Scene").GetComponent<ChangeScene>().setScene(2);
    }
}
