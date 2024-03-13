using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class playermover : MonoBehaviour
{
    public static playermover instance;
    public bool Deid = false;
    public bool doublekillscore = false;
    public bool shootontapping;
    public bool blackplayer;
    public int bitsgiven;
    public healthbar healthbars;

    [SerializeField] private Transform postoshoot;
    [SerializeField] private Transform aimcrosshair;

    [SerializeField] private GameObject[] whendiedGOon;
    [SerializeField] private GameObject[] objectoffondied;
    [SerializeField] private GameObject partlie;
    [SerializeField] private GameObject X2text;
    [SerializeField] private GameObject meshasGameobject;
    [SerializeField] private GameObject deadCamera;// camera that will show the dead animation 
    [SerializeField] private GameObject mainCamera;// the camera main camera
    [SerializeField] private GameObject canvse;// the UI canvse
    [SerializeField] private GameObject joystick_cover;
    [SerializeField] private GameObject damagetext;
    [SerializeField] private GameObject shootbuttonobject;

    [SerializeField] private Rigidbody2D playersr;
    [SerializeField] private Vector3 damage_text_position;
    [SerializeField] private Animator playersanime;
    [SerializeField] private Animator playerHealthBar;
    [SerializeField] private SpriteRenderer sprit;
    [SerializeField] private Joystick joystick;
    [SerializeField] private scorestexts score;
    [SerializeField] private playeraudio audioscript;

    [SerializeField] private float Speed;
    [SerializeField] private float onairspeed;
    [SerializeField] private float jumpspeed;
    [SerializeField] private float shootingForce;
    [SerializeField] private float formuchtime;
    [SerializeField] private float rateoffire; // 1f
    [SerializeField] private float dalayBetweenjump;
    [SerializeField] private float dalayBetweentpartlicehit;// diffcult var
    [SerializeField] private float diffcultypoints;
    
    [SerializeField] private int greenEnemyHit; // diffcult var
    [SerializeField] private int redEnemyHit; // diffcult var
    [SerializeField] private int GhostHit; // diffcult var
    [SerializeField] private int missileHit; // diffcult var
    [SerializeField] private int partclieHit; // diffcult var
    [SerializeField] private int jumpleft = 2;
    [SerializeField] private int reward;

    [SerializeField] private string moves;
    [SerializeField] private string blackskin;
    [SerializeField] private string twox;
    [SerializeField] private string heart;
    [SerializeField] private string greenenemy;
    [SerializeField] private string redenemy;
    [SerializeField] private string ghost;
    [SerializeField] private string particleTag;
    [SerializeField] private string missileTag;
    private string diffcultystr;

    // non-serializeField variables
    private const int maxHealth = 100;
    private List<Enemy> enemytransform = new List<Enemy>();
    private Vector3 startp;
    private Camera mainc;
    private int health;
    private float timesone;
    private float timeforDouble;
    private float stopwatchforjump,stopwatchforpartlices;
    private bool isDragging = false;
    private bool tappingbutton = false;
    private bool isGround = true;
    private bool shouldbejumping = false;//input of jumping button

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        string bs = PlayerPrefs.GetString("shootingway","b"); // for the opitimizetion purpose the gamemanger is not used
        string diffcultystr = PlayerPrefs.GetString("diffculty","Easy"); // for diffcult
        Debug.Log(bs);

        if(bs == "b")
        {
            shootontapping = false;
        }
        else if(bs == "m")
        {
            shootontapping = true;
        }
        else
        {
            Debug.LogError($"the variable shootontapping is set to wrong value");
        }
        Debug.Log(diffcultystr);
        if(diffcultystr == "Very Easy")//very easy
        {
            // delay = 0.75,enemyhits = 15,partilces hit = 5, bits = / 2 , missle = 20
            dalayBetweentpartlicehit = 0.75f;
            redEnemyHit = 15;
            greenEnemyHit = 15;
            GhostHit = 15;
            missileHit = 20;
            partclieHit = 5;
            diffcultypoints = 0.5f;
        }
        else if(diffcultystr == "Easy") // easy
        {
            // delay = 0.5,enemyhits = 20,partilces hit = 5 ,bits = /1.5 , missle = 40
            dalayBetweentpartlicehit = 0.5f;
            redEnemyHit = 20;
            greenEnemyHit = 20;
            GhostHit = 20;
            missileHit = 40;
            partclieHit = 5;
            diffcultypoints = (1/1.5f);
        }
        else if(diffcultystr == "Normal") // normal
        {
            // dely = 0.25,enemyhits = 30, partilce hit = 10, bits = *1 , missle = 60
            dalayBetweentpartlicehit = 0.75f;
            redEnemyHit = 30;
            greenEnemyHit = 30;
            GhostHit = 30;
            missileHit = 60;
            partclieHit = 10;
            diffcultypoints = 1;
        }

        else if(diffcultystr == "Hard") // hard
        {
            //delay = 0.1,enemyhits = 40 , partilce hit = 20 ,bits = *2 , misssle = 90
            dalayBetweentpartlicehit = 0.75f;
            redEnemyHit = 15;
            greenEnemyHit = 15;
            GhostHit = 15;
            missileHit = 90;
            partclieHit = 20;
            diffcultypoints = 2;
        }
        else if(diffcultystr == "Asian")
        {
            Debug.LogWarning("the var diffculty is set to asian but gameplayScene is opened");
        }
        else
        {
            Debug.LogWarning("the var diffculty is not set to correct value the current value"+diffcultystr);
        }
    }
    void Start()
    {
        mainc = Camera.main;//getting the main camera referce
        health = maxHealth;
        healthbars.SetMaxhealth(maxHealth);
        playerHealthBar.SetInteger("health",health);
        blackplayer = (PlayerPrefs.GetString("currentplayer","garo") != "garo");
        if(!shootontapping)
        {
            shootbuttonobject.SetActive(true);
        }
        else
        {
            shootbuttonobject.SetActive(false);
        }
        if(blackplayer)
        {
            playersanime.SetBool(blackskin,true);
        }
        else
        {
            playersanime.SetBool(blackskin,false);
        }
    }
    void FixedUpdate()
    {
        if (Deid)
        {
            Time.timeScale = 0f;
            saveplayerhighscore();
            givereward();
            return;
        }
        
        if (health <= 0)// player is deid
        {
            audioscript.playaudio(4);
            playersanime.SetInteger(moves, 5);
            Deid = true;
            playerDeadstart();
            return;
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (Time.time > timeforDouble + formuchtime)
        {
            doublekillscore = false;
            X2text.SetActive(false);
        }

        float joystickMove = joystick.Horizontal;
        Vector2 pos = transform.position;
        if (!isGround)
        {
            Speed = onairspeed;
        }
        else
        {
            Speed = 6f;
        }
        if (joystickMove < 0) // moving to left
        {
            audioscript.playaudio(3);
            joystick_cover.SetActive(true);
            playersanime.SetInteger(moves, 2);
            sprit.flipX = true;
            pos.x += -Speed * Time.deltaTime;
            transform.position = pos;
        }
        if (joystickMove > 0) // moving to right
        {
            audioscript.playaudio(3);
            joystick_cover.SetActive(true);
            playersanime.SetInteger(moves, 2);
            sprit.flipX = false;
            pos.x += Speed * Time.deltaTime;
            transform.position = pos;
        }
        if (isGround && shouldbejumping/* && jumpleft > 0*/) // checking should player jump if the button is called
        {
            // if(stopwatchforjump == 0)
            // {
            //     stopwatchforjump = Time.time + dalayBetweenjump;
            // }

            // if(Time.time >= stopwatchforjump)
            // {
                
            //     stopwatchforjump = 0f;
            // }
            jumper();
            shouldbejumping=false;
        }
        else
        {
            shouldbejumping = false;
        }

        if (Input.touchCount > 0 && shootontapping)
        {
            Touch touch = Input.GetTouch(0);
            if (Time.time <= timesone)
            {
                return;
            }
            if (touch.phase == TouchPhase.Began)
            {
                if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId)) // here the fine
                {
                    startp = Camera.main.ScreenToWorldPoint(touch.position);
                    startp.z = 0;
                    isDragging = true;
                    // aimline.positionCount = 1;
                    // aimline.SetPosition(0,startp);
                }
                return;

            }

            else if (touch.phase == TouchPhase.Moved /*&& !EventSystem.current.IsPointerOverGameObject(touch.fingerId)*/)
            {
                if(EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    return;
                }

                if (isDragging)
                {
                    Vector3 currentp = Camera.main.ScreenToWorldPoint(touch.position);
                    Vector3 tragetpos = Giveintputpos();
                    aimcrosshair.gameObject.SetActive(true);
                    Vector2 dir2d = tragetpos- transform.position;
                    float angle = Mathf.Atan2(dir2d.y,dir2d.x) * Mathf.Rad2Deg;
                    aimcrosshair.rotation = Quaternion.Euler(0,0,angle);
                    currentp.z = 0;
                }
                return;
            }
            else if (touch.phase == TouchPhase.Ended /*&& !EventSystem.current.IsPointerOverGameObject(touch.fingerId)*/)
            {
                if(EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    return;
                }
                if (isDragging)
                {
                    aimcrosshair.gameObject.SetActive(false);
                    Vector3 endpoint = Camera.main.ScreenToWorldPoint(touch.position);
                    endpoint.z = 0;
                    timesone = Time.time + rateoffire;
                    Vector3 inputPosition = Giveintputpos();
                    shootparticle(inputPosition);
                }
                isDragging = false;
                return;
            }
            

            // the switched code of shoot
            #region swiched_code       
            // switch (touch.phase)
            // {
            //     case TouchPhase.Began:

            //         break;

            //     case TouchPhase.Moved:

            //         break;

            //     case TouchPhase.Ended:
            //         if(isDragging)
            //         {
            //             Vector3 endpoint = Camera.main.ScreenToWorldPoint(touch.position);
            //             endpoint.z = 0;
            //             timesone = Time.time + 1f;
            //             Vector3 inputPosition = Giveintputpos();
            //             shootparticle(inputPosition);
            //             aimline.positionCount = 0;
            //         }
            //         isDragging = false;
            //         break;
            // }
            #endregion
        }

        if (joystickMove == 0f && isGround)
        {
            playersanime.SetInteger(moves, 1);
            joystick_cover.SetActive(false);
        }
        playerHealthBar.SetInteger("health",health);
    }
    // int sdf = (score.finalscores * diffcultypoints);
    // int dsds = (int)(sdf * (score.speicalkills + score.normalkills)/100);
    
    //Debug.Log(dsds);
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(missileTag))
        {
            int takendamage = takedamage(missileHit); // missile damage was 50
            GameObject textteller = Instantiate(damagetext,transform.position + damage_text_position,Quaternion.identity);
            textteller.GetComponent<damagetext>().damage = takendamage;
        }
        if (collision.gameObject.CompareTag("ground2"))
        {
            // audioscript.playaudio(2);
            // isGround = true;
        }
        if (collision.gameObject.CompareTag(redenemy))
        {
            // some damage should be given
            int takendamage = takedamage(redEnemyHit);
            GameObject textteller = Instantiate(damagetext,transform.position + damage_text_position ,Quaternion.identity);
            textteller.GetComponent<damagetext>().damage = takendamage;
        }
        if (collision.gameObject.CompareTag(greenenemy))
        {
            // some damage should be given
            int takendamage = takedamage(greenEnemyHit); // green enemy damage 1
            GameObject textteller = Instantiate(damagetext,transform.position + damage_text_position ,Quaternion.identity);
            textteller.GetComponent<damagetext>().damage = takendamage;
        }
            
        if (collision.gameObject.CompareTag(ghost))
        {
            // some damage should be given
            int takendamage = takedamage(GhostHit); // ghost damage 1
            GameObject textteller = Instantiate(damagetext,transform.position + damage_text_position ,Quaternion.identity);
            textteller.GetComponent<damagetext>().damage = takendamage;
        }
    }

    void OnTriggerEnter2D(Collider2D colliders)
    {
        if(Deid)
        {
            return;
        }

        if(colliders.gameObject.CompareTag("groundUp"))
        {
            audioscript.playaudio(2);
            isGround = true;
        }
        if (colliders.gameObject.CompareTag(twox))
        {
            if (doublekillscore == false)
            {
                audioscript.playaudio(6);
            }
            // x2 in point for killing an enemy
            doublekillscore = true;
            timeforDouble = Time.time;
            X2text.SetActive(true);
            Destroy(colliders.gameObject);
        }
        if (colliders.gameObject.CompareTag(heart))
        {
            addHealth(maxHealth / 2);
            Destroy(colliders.gameObject);
            // health should be fulled
        }
    }

    /*void OnCollisionStay2D(Collision2D collision)
    {
        if (Deid)
        {
            return;
        }
        if(stopwatchforjump == 0)
        {
            stopwatchforjump = Time.time + dalayBetweenjump;
        }

        if(Time.time >= stopwatchforjump)
        {
            
            stopwatchforjump = 0f;
        }
    }*/
    void OnParticleCollision(GameObject other)
    {
        if (Deid)
        {
            return;
        }
        if(stopwatchforpartlices == 0)
        {
            stopwatchforpartlices = Time.time + dalayBetweentpartlicehit;// this can be used  ---------------------------
        }
        
        if (other.gameObject.CompareTag(particleTag) && Time.time >= stopwatchforpartlices)
        {
            int takendamage = takedamage(partclieHit); // any particle hitting damage was 5
            GameObject textteller =  Instantiate(damagetext,transform.position + damage_text_position,Quaternion.identity);
            textteller.GetComponent<damagetext>().damage = takendamage;
            stopwatchforpartlices = 0f;
        }
    }

    Vector3 Giveintputpos() // function for getting dirition of the tapped places
    {
        Vector3 inputPosition = Vector3.zero;
        Touch t = Input.GetTouch(0);
        inputPosition = t.position;
        inputPosition.z = 10f;
        inputPosition = mainc.ScreenToWorldPoint(inputPosition);
        return inputPosition;
    }
    void shootparticle(Vector3 tragetpos)// spawer and shoot the bullet in the given position
    {
        audioscript.playaudio(0);
        GameObject partli = Instantiate(partlie, transform.position, Quaternion.identity);
        Rigidbody2D partlierb2d = partli.GetComponent<Rigidbody2D>();
        Vector3 dir = (tragetpos - transform.position).normalized;
        partlierb2d.AddForce(dir * shootingForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }

    void jumper() // to make player jump
    {
        audioscript.playaudio(1);
        playersr.AddForce(new Vector2(0f, jumpspeed), ForceMode2D.Impulse);
        playersanime.SetInteger(moves, 3);
        isGround = false;
        Debug.LogWarning("jumping left: "+jumpleft);
        
    }
    
    Vector3 shootbutton()
    {
        enemytransform.Clear();
        Enemy[] allenemy = FindObjectsOfType<Enemy>(); // finding all enemys in the scene
        enemytransform.AddRange(allenemy); // add the enemys to the list
        float nearfromx = 45f; //both are screen ditance from player
        float nearfromy = 10f;
        Enemy nearest = null; // enemy that should be shooted
        foreach (Enemy obj in enemytransform)// looping every enemy
        {
            float xposition = transform.position.x - obj.transform.position.x;// find out the x-axis distance
            float yposition = transform.position.y - obj.transform.position.y;// find out the x-axis distance
            //Debug.Log(obj+"<color=yellow> ("+(int) xposition+" "+(int) yposition+" )</color>");
            if(yposition < 0) // if the y-position is -neg than do it positive
            {
                yposition = -yposition;
            }
            if(xposition < 0) // if the x-position is -neg than do it positive
            {
                xposition = -xposition;
            }
            if(yposition >= nearfromy || xposition >= nearfromx) // removing the enemy ouside the camera
            {
                continue;
            }
            if(yposition < 6.0f && xposition < 6.0f) // if any enemy is too close in the y-axis shoot him with no delay
            {
                nearest = obj;
                Vector3 thisvector2 = obj.transform.position;
                return thisvector2;
            }

            if(xposition < nearfromx && yposition < 4.2f) // if nearest from x than say this as nearest enemy
            {
                nearest = obj;
                nearfromx = xposition;
            }
            
        }
        if(nearest == null)
        {
            Vector3 thisvector3 = new Vector3(Random.Range(-5,6),Random.Range(-5,6),0f);
            return thisvector3;     
        }
        Vector3 thisvector = nearest.transform.position;
        //Debug.Log("<color=red>{"+thisvector+"}</color>");
        return thisvector;
    }


    void playerdead() // player when died animation ends
    {
        whendiedGOon[0].SetActive(true);
        meshasGameobject.SetActive(false);
    }

    void playerDeadstart() // when player died animation starts
    {
        audioscript.playaudio(4);
        audiomanager.instance.GetComponent<AudioSource>().Stop();
        for (int i = 0; i < objectoffondied.Length; i++)
        {
            objectoffondied[i].SetActive(false);
        }
        whendiedGOon[1].SetActive(true);
        deadCamera.SetActive(true);
        canvse.SetActive(false);
    }

    int takedamage(int damage) // player take amount of damage
    {
        audioscript.playaudio(5);
        if (health > 0)
        {
            health -= damage;
            healthbars.SetHealth(health);
            playersanime.SetInteger(moves, 4);
            if (health < 0)
            {
                health = 0;
            }
        }
        return damage;

    }

    int addHealth(int addedHealth) // add amount of health
    {
        audioscript.playaudio(7);
        if (health < maxHealth)
        {
            health += addedHealth;
            healthbars.SetHealth(health);
            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }
        return addedHealth;
    }

    void saveplayerhighscore() // save the high score  
    {
        if (score.highscorebyplayer < score.finalscores)
        {
            PlayerPrefs.SetInt("highscore", (int)score.finalscores);
            PlayerPrefs.Save();
        }
    }

    void givereward()
    {
        reward = (int)((score.finalscores * diffcultypoints) * (score.speicalkills + score.normalkills)/100);
        bitsgiven = reward;
        reward += PlayerPrefs.GetInt("bitcoins",0);
        PlayerPrefs.SetInt("bitcoins",reward);
        PlayerPrefs.Save();
    }


    // function for the press buttons
    public void isbuttonpressed(bool pr)
    {
        tappingbutton = pr;
    }
    public void jumps(bool shouldjump)
    {
        shouldbejumping = shouldjump;
    }

    public void shootfronbutton()
    {
        if (Time.time <= timesone)
        {
            return;
        }
        shootparticle(shootbutton());
        timesone = Time.time + rateoffire;
    }
}