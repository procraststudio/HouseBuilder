using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public int materialsTotal;
    public int moneyTotal;
    public int lifeTotal;
    public int nervesTotal;
    public int dayNumber;
    public int hour;
    public int d100;
    public int playerLevel;
    private float timeToAppear = 1f;
    private float timeWhenDisappear;

    [SerializeField] TextMeshProUGUI woodTotalText;
    [SerializeField] TextMeshProUGUI stoneTotalText;
    [SerializeField] TextMeshProUGUI moneyTotalText;
    [SerializeField] TextMeshProUGUI lifeTotalText;
    [SerializeField] TextMeshProUGUI dayNumberText;
    [SerializeField] TextMeshProUGUI hourNumberText;
    [SerializeField] TextMeshProUGUI materialsChange;
    [SerializeField] TextMeshProUGUI moneyChange_text;

    [SerializeField] TextMeshProUGUI startText;
    [SerializeField] TextMeshProUGUI option1Text;
    [SerializeField] TextMeshProUGUI option2Text;
    [SerializeField] TextMeshProUGUI finalText;
    [SerializeField] TextMeshProUGUI eventHero;
    [SerializeField] TextMeshProUGUI finalEventHero;

    [SerializeField] AudioClip click01;
    [SerializeField] AudioClip click02;
    [SerializeField] [Range(0, 1)] float clickSoundVolume;
    [SerializeField] AudioClip [] talkingSounds;
    [SerializeField] AudioClip horseSound;

    public GameObject startPanel;
    public GameObject finalPanel;
    public GameObject heroImage;
    public GameObject finalHeroImage;
    public GameObject nightCanvas;
    public GameObject Action01;
    public GameObject Action02;
    public GameObject Action03;
    //public GameObject houseImage;

    [SerializeField] public Sprite [] heroImages;
   // [SerializeField] public Sprite[] houseImages;
    public GameObject eventsCanvas;
    public GameObject continueButton;
    public GameObject trueButton;
    public GameObject falseButton;

    public bool option1;
    public bool option2;
    public bool action01Activated;
    public bool action02Activated;
    public bool action03Activated;
    Rigidbody2D m_Rigidbody;
    AudioSource myAudioSource;
    public Animator transition;

    [SerializeField] public Transform pfDamagePopup;

    public static List<string> events = new List<string>() { "CWANIAK ZDZISEK", "EWELINA", "BEŁKOT", "MANIEK", "BOLEK", "OSESEK GIGANT", "ŁAZANKI Z KOSMOSU", "KOŃ FETTY" };  //  "DZIKA", "HELA", "PIECZARA", , "PIES" 
    public static List<string> randomEvents = new List<string>() { "NOWORODEK GIGANT", "KOSMICZNE ŁAZANKI", "KOŃ FETTY" };  //  "DZIKA", "HELA", "PIECZARA", , "PIES" 

    private enum States
        { GameStart, Question, TrueState, FalseState, EffectState, Night, Dawn, Sickness, Death };
    private States myState;
    int currentHero;
   

    void Start()
    {
        myState = States.GameStart;
        materialsTotal = 1;
        moneyTotal = 1;
        lifeTotal = 8;
        dayNumber = 1;
        hour = 8;
        nightCanvas.SetActive(false);
        Action01.SetActive(false);
        Action02.SetActive(false);
        Action03.SetActive(false);
        action01Activated = false;
        action02Activated = false;
        action03Activated = false;
        myAudioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        woodTotalText.GetComponent<TextMeshProUGUI>().text = materialsTotal.ToString();
        moneyTotalText.GetComponent<TextMeshProUGUI>().text = moneyTotal.ToString();
        dayNumberText.GetComponent<TextMeshProUGUI>().text = dayNumber.ToString();
        hourNumberText.GetComponent<TextMeshProUGUI>().text = hour.ToString();

        StatesManager();
        ActionsDisplay();
        CalculatePlayerLevel();

        if (lifeTotal>10)
        {
            lifeTotal = 10;
        }
        else if (lifeTotal<=0)
        {
            myState = States.Death;
        }
    }

    public void StatesManager()

    {
        if (myState == States.Question)
        {
            finalPanel.SetActive(false);
            startPanel.SetActive(true);
            trueButton.SetActive(true);
            falseButton.SetActive(true);
            continueButton.SetActive(false);
            materialsChange.CrossFadeAlpha(1f, 0.1f, true);
            materialsChange.GetComponent<TextMeshProUGUI>().text = null;
            moneyChange_text.CrossFadeAlpha(1f, 0.1f, true);
            moneyChange_text.GetComponent<TextMeshProUGUI>().text = null;
            // materialsChange.transform.position = new Vector3(290f, 390f);
            heroImage.GetComponent<Image>().sprite = heroImages[currentHero];
            eventHero.GetComponent<TextMeshProUGUI>().text = events[currentHero] + ":";
        }

        else if (myState == States.EffectState)
        {
            startPanel.SetActive(false);
            finalPanel.SetActive(true);
            continueButton.SetActive(true);
            trueButton.SetActive(false);
            falseButton.SetActive(false);
            finalHeroImage.GetComponent<Image>().sprite = heroImages[currentHero];
            finalEventHero.GetComponent<TextMeshProUGUI>().text = events[currentHero] + ":";

        }
        //  startText.SetActive(false);

        else if (myState == States.GameStart)
        {
            nightCanvas.SetActive(false);
            finalPanel.SetActive(false);
            startPanel.SetActive(false);
            trueButton.SetActive(false);
            falseButton.SetActive(false);
            continueButton.SetActive(true);
           if ((moneyTotal > 2)&&(!action01Activated)) { Action01.SetActive(true); }
           if ((materialsTotal > 2) && (!action02Activated)) { Action02.SetActive(true); }
           if ((moneyTotal > 4) &&(lifeTotal <10) && (!action03Activated)) { Action03.SetActive(true); }

        }

        else if (myState == States.Night)
        {
            nightCanvas.SetActive(true);
            finalPanel.SetActive(false);
            startPanel.SetActive(false);
            trueButton.SetActive(false);
            falseButton.SetActive(false);
            continueButton.SetActive(true);
            // night events
            //nightCanvas.SetActive(true);
        }
        else if (myState == States.Death)
        {
            FindObjectOfType<StartGame>().LoadGameScene();
            //  transition.SetTrigger("Start");
          //  SceneManager.LoadScene(2);

        }


        }

    

    public void AdvanceButton()
    {
        if (myState == States.GameStart)
        {
            GenerateEvent();
            myState = States.Question;
            AudioSource.PlayClipAtPoint(click01, Camera.main.transform.position, clickSoundVolume);
        }
        else if (myState == States.Question)
        {
            // no button
        }
        else if (myState == States.EffectState)
        {
            AudioSource.PlayClipAtPoint(click02, Camera.main.transform.position, clickSoundVolume);
            hour += Random.Range(1,4); //random 1-3 hours
            if (hour < 20)
            {
                GenerateEvent();
                myState = States.Question;
                
            }
            else
            {
                myState = States.Night;
            }
        }

        else if (myState == States.Night)
        {
            AudioSource.PlayClipAtPoint(click01, Camera.main.transform.position, clickSoundVolume);
            nightCanvas.SetActive(false);
            lifeTotal++;
            dayNumber++;
            hour = 8;
           action01Activated = false;
           action02Activated = false;
           action03Activated = false;
            if ((dayNumber == 11) && (materialsTotal<30)&& (moneyTotal < 30))
            {
                myState = States.Death;
            }
            else
            {
                myState = States.GameStart;
            }
        }
    }

    public void GenerateEvent()
    {
        string eventText;
        int index = Random.Range(0, events.Count);
        eventText = events[index];
        Debug.Log("Event is " + eventText);
        //int ind = Random.Range(0, talkingSounds.Count);
        if (eventText == "KOŃ FETTY")
        {
            AudioClip clip = horseSound;
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, clickSoundVolume);
        }
        else
        {
            AudioClip clip = talkingSounds[Random.Range(0, talkingSounds.Length)];
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, clickSoundVolume);
        }
        //  myAudioSource.PlayOneShot(clip);

        switch (eventText)
        {
            case "CWANIAK ZDZISEK":
                currentHero = 0;
                startText.GetComponent<TextMeshProUGUI>().text = "Szefie, materiał spadł komuś z lawety. Przywieżć?";
                option1Text.GetComponent<TextMeshProUGUI>().text = "Dawaj pan";
                option2Text.GetComponent<TextMeshProUGUI>().text = "Nie wchodzę w to.";
                return;
            case "EWELINA":
                currentHero = 1;
                startText.GetComponent<TextMeshProUGUI>().text = "Napij się nalewki mojej ciotki albo weż u mnie tanią pożyczkę";
                option1Text.GetComponent<TextMeshProUGUI>().text = "Łyknę tej nalewki, choć mętna jest";
                option2Text.GetComponent<TextMeshProUGUI>().text = "Daj pożyczkę";
                return;
            case "BEŁKOT":
                currentHero = 2;
                startText.GetComponent<TextMeshProUGUI>().text = "Kierownik da kratę vanpura, to będzie w mig zrobione";
                option1Text.GetComponent<TextMeshProUGUI>().text = "Proszę, tu piwko dla mistrza";
                option2Text.GetComponent<TextMeshProUGUI>().text = "Zrób pan dziś przerwę sobie";
                return;
            case "MANIEK":
                currentHero = 3;
                startText.GetComponent<TextMeshProUGUI>().text = "Mam dzisiaj robić, czy mam dziś nie robić?";
                option1Text.GetComponent<TextMeshProUGUI>().text = "Rób pan";
                option2Text.GetComponent<TextMeshProUGUI>().text = "W takim stanie? Idź pan do domu";
                return;
            case "BOLEK":
                currentHero = 4;
                startText.GetComponent<TextMeshProUGUI>().text = "Kierownik da na materiał to zaraz się biorę";
                option1Text.GetComponent<TextMeshProUGUI>().text = "Dobra, tylko szybko";
                option2Text.GetComponent<TextMeshProUGUI>().text = "Nie ma takiej opcji";
                return;
            case "OSESEK GIGANT":
                currentHero = 5; 
                startText.GetComponent<TextMeshProUGUI>().text = "AGUGUAGUGU. A GU-GU!";
                option1Text.GetComponent<TextMeshProUGUI>().text = "Ło matko!"; ;
                option2Text.GetComponent<TextMeshProUGUI>().text = "Łolaboga";
                falseButton.SetActive(false);
                return;

            case "ŁAZANKI Z KOSMOSU":
                currentHero = 6;
                startText.GetComponent<TextMeshProUGUI>().text = "Witajcie, Ziemianie. Wasze podatki są za wysokie by tu lądować";
                option1Text.GetComponent<TextMeshProUGUI>().text = "Nie jest tak źle";
                option2Text.GetComponent<TextMeshProUGUI>().text = "Mają obniżyć przed wyborami";
                falseButton.SetActive(false);
                return;
            
            case "KOŃ FETTY":
                currentHero = 7;
                startText.GetComponent<TextMeshProUGUI>().text = "IHAHAHAHAAA!";
                option1Text.GetComponent<TextMeshProUGUI>().text = "Ja ciebie też";
                option2Text.GetComponent<TextMeshProUGUI>().text = "No i gitara";
                falseButton.SetActive(false);
                return;


        }


    }

    public void ChoiceOption1()
    {

        d100 = Random.Range(1, 101);
        Debug.Log("Number was " + d100);
        AudioSource.PlayClipAtPoint(click01, Camera.main.transform.position, clickSoundVolume);
        myState = States.EffectState;
        switch (currentHero)
        {
            case 0: //ZDZICH
                if (d100 <= 75)
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "Masz pan te materiały. Spadam";
                    WoodChange(+3);
                }
                else
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "Złapały mnie. Co teraz będzie?";
                    lifeTotal--;
                }

                return;
            case 1: //EWELINA
                if (d100 <= 75)
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "Samo zdrowie";
                    lifeTotal++;
                }
                else
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "Miałeś spore nudności";
                    lifeTotal -= 2;
                }

                return;
            case 2: //BELKOT
                if (d100 <= 75)
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "Ale się porobiłem...";
                    WoodChange(-2); lifeTotal--;
                }
                else
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "Zrobione na ażur. Kto, ja nie zrobię?";
                    WoodChange(5);
                }

                return;

            case 3: //MANIEK
                if (d100 <= 75)
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "Masz pan zrobione.";
                    WoodChange(1);
                }
                else
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "Spieprzyłem to panu wzorowo";
                    MoneyChange(-1); lifeTotal--;
                }

                return;
            case 4: //BOLEK
                if (d100 <= 75)
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "Można kulturalnie? Można?";
                    WoodChange(2);
                }
                else
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "Znowu w życiu mi nie wyszło...";
                    WoodChange(-2);
                }

                return;
            case 5: //NOWORODEK GIGANT
                if (d100 <= 50)
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "Noworodek spadł na ciebie";
                    lifeTotal -= 2; 
                }
                else
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "Noworodek uszkodził dom";
                    WoodChange(-1);
                }

                return;

            case 6: //ŁAZANKI Z KOSMOSU
                if (d100 <= 50)
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "Sprzedałeś nasze zdjęcia do gazety, szujo!";
                    MoneyChange(2);
                }
                else
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "Grzywna za niezgłoszenie wizyty Łazanek";
                    MoneyChange(-1);
                }

                return;

            case 7: //KOŃ FETTY
                if (d100 <= 50)
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "Przywiozłem materiały";
                    WoodChange(3);
                }
                else
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "Duża kasa! Ihahaha!";
                    MoneyChange(3);
                }

                return;

        }
           
    }

    public void ChoiceOption2()
    {
        d100 = Random.Range(1, 101);
        Debug.Log("Number was " + d100);
        myState = States.EffectState;
        AudioSource.PlayClipAtPoint(click02, Camera.main.transform.position, clickSoundVolume);
        switch (currentHero)
        {
            case 0: //ZDZISEK
            if (d100 <= 75)
        {
            finalText.GetComponent<TextMeshProUGUI>().text = "Cykor. Tylko nikomu nie mówić, zapłacę.";
            MoneyChange(2);
        }

        else
        {
            finalText.GetComponent<TextMeshProUGUI>().text = "Masz pan trochę materiału. Jakby co, to nic pan nie wiesz";
            WoodChange(2);
        }
                return;
            case 1: //EWELINA
                if (d100 <= 75)
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "Tu podpisać, gdzie wykropkowane";
                    MoneyChange(3);
                }

                else
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "Niestety, RSSO wyszło 34234%";
                    MoneyChange(-2);
                }
                return;
            case 2: //BELKOT
                if (d100 <= 75)
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "O, kierownik stówę zostawił";
                    MoneyChange(-1); lifeTotal -=2;
                }

                else
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "I tak tu spieprzyłem po swojemu";
                    WoodChange(1); lifeTotal--;
                }
                return;
            case 3: //MANIEK
                if (d100 <= 75)
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "Odpocząłeś pan ode mnie";
                    lifeTotal++;
                }

                else
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "Masz pan syf na balkonie";
                    // no effect
                }
                return;
            case 4: //BOLEK
                if (d100 <= 75)
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "To oddaję zaliczkę i szukaj mnie w Polsce";
                    MoneyChange(1);
                }

                else
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "Po co te nerwy, już oddaję kasę";
                    MoneyChange(4);
                }
                return;
            case 5: //NOWORODEK GIGANT
                if (d100 <= 50)
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "Noworodek spadł na ciebie";
                    lifeTotal -= 2;
                }
                else
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "Noworodek uszkodził dom";
                    WoodChange(-1);
                }
                return;
            case 6: //ŁAZANKI Z KOSMOSU
                if (d100 <= 50)
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "Sprzedałeś nasze zdjęcia do gazety, gnido!";
                    MoneyChange(2);
                }
                else
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "Grzywna za niezgłoszenie wizyty Łazanek";
                    MoneyChange(-1);
                }
                return;
            case 7: //KOŃ FETTY
                if (d100 <= 50)
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "Koń z wozu, budowie lżej";
                    WoodChange(3);
                }
                else
                {
                    finalText.GetComponent<TextMeshProUGUI>().text = "Duża kasa! Ihahaha!";
                    MoneyChange(3);
                }
                return;

        }
        
    }

    public void WoodChange (int woodChange)
    {
        materialsTotal += woodChange;
        if (woodChange > 0)
        {
            materialsChange.GetComponent<TextMeshProUGUI>().text = "+" + woodChange.ToString();
        }
        else
        {
            materialsChange.GetComponent<TextMeshProUGUI>().text = woodChange.ToString();

            
        }
        materialsChange.CrossFadeAlpha(0.0f, 2f, false);

        if (materialsTotal < 0)
         {
            materialsTotal = 0;
        }
        else if (materialsTotal>30)
        {
            materialsTotal = 30;
        }
   
    }

    public void MoneyChange(int moneyChange)
    {
        moneyTotal += moneyChange;

        if (moneyChange > 0)
        {
            moneyChange_text.GetComponent<TextMeshProUGUI>().text = "+" + moneyChange.ToString();
        }
        else

        {
            moneyChange_text.GetComponent<TextMeshProUGUI>().text = moneyChange.ToString();
         }
            moneyChange_text.CrossFadeAlpha(0.0f, 2f, false);


        if (moneyTotal < 0)
        {
            moneyTotal = 0;
        }
        else if (moneyTotal >30)
        {
            moneyTotal = 30;
        }

    }

    public int GetMaterials()
    {
        return materialsTotal;
    }

    public int GetMoney()
    {
        return moneyTotal;
    }

    public int GetLife()
    {
        return lifeTotal;
    }

    public int GetHour()
    {
        return hour;
    }

    public void ActionsDisplay()
    {
        if (moneyTotal < 3) 
        {
            Action01.SetActive(false);
        }
        else if (materialsTotal < 3) 
        {
            Action02.SetActive(false);
        }
        else if (moneyTotal <5) 
        {
            Action03.SetActive(false);
        }
    }
    
    public void SellMaterials()
    {
        AudioSource.PlayClipAtPoint(click01, Camera.main.transform.position, clickSoundVolume);
        WoodChange(-3);
        MoneyChange(1);
        Action02.SetActive(false);
        action02Activated = true;

    }

    public void BuyMaterials()
    {
        AudioSource.PlayClipAtPoint(click02, Camera.main.transform.position, clickSoundVolume);
        WoodChange(1);
        MoneyChange(-3);
        Action01.SetActive(false);
        action01Activated = true;
    }

    public void Doctor()
    {
        AudioSource.PlayClipAtPoint(click01, Camera.main.transform.position, clickSoundVolume);
        MoneyChange(-5);
        lifeTotal++;
        Action03.SetActive(false);
        action03Activated = true;
    }

    public void CalculatePlayerLevel()
    {
        if ((materialsTotal+moneyTotal) <20)
        {
            playerLevel = 1;
          //  houseImage.GetComponent<Image>().sprite = null;
        }
        else if (((materialsTotal + moneyTotal) >= 20)&& ((materialsTotal + moneyTotal) < 40))
        {
            playerLevel = 2;
           // houseImage.GetComponent<Image>().sprite = houseImages[0];

        }
        else if ((materialsTotal + moneyTotal) >= 40)
            {
            playerLevel = 3;
           // houseImage.GetComponent<Image>().sprite = houseImages[1];
        }
    }

   

}
