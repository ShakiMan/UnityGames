using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private static readonly int DEFEAT_SCORE = -10;
    private static readonly int MATCHED_SCORE = 10;
    private static readonly int NOT_MATCHED_SCORE = -2;
    
    [SerializeField] private Sprite reverseImage;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text gameResultText;

    public Sprite[] cards;
    public List<Sprite> gameCards = new List<Sprite>();
    public List<Button> Buttons = new List<Button>();

    private bool _firstCardGuessing;
    private bool _secondCardGuessing;

    private int _firstGuessIndex, _secondGuessIndex;
    private string _firstGuessCard, _secondGuessCard;
    private int _countCorrectGuesses;

    private int _gameScore;

    void Awake()
    {
        cards = Resources.LoadAll<Sprite>("Sprites/Images");
    }

    void Start()
    {
        CreateCardsButtons();
        CreateCardsListeners();
        CreateGameCards();
        Shuffle();

        _gameScore = 0;
        _countCorrectGuesses = 0;
        UpdateScore();

        gameResultText.enabled = false;
        
    }

    private void UpdateScore()
    {
        string scoreTxt = scoreText.text.Split(' ')[0]; 
        scoreText.text = scoreTxt + " " + _gameScore;
    }

    void CreateCardsButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("CardButton");

        for (int i = 0; i < objects.Length; i++)
        {
            Buttons.Add(objects[i].GetComponent<Button>());
            Buttons[i].image.sprite = reverseImage;
        }
    }

    void CreateGameCards()
    {
        int index = 0;
        for (int i = 0; i < Buttons.Count; i++)
        {
            gameCards.Add(cards[index]);
            i++;
            gameCards.Add(cards[index]);
            index++;
        }
    }

    void CreateCardsListeners()
    {
        foreach (var button in Buttons)
        {
            button.onClick.AddListener(PickCard);
        }
    }

    public void PickCard()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        Debug.Log("Clicking button: " + name);

        if (!_firstCardGuessing)
        {
            _firstCardGuessing = true;
            _firstGuessIndex = int.Parse(name);
            _firstGuessCard = gameCards[_firstGuessIndex].name;
            Buttons[_firstGuessIndex].image.sprite = gameCards[_firstGuessIndex];
        }
        else if (!_secondCardGuessing)
        {
            _secondGuessIndex = int.Parse(name);

            if (_firstGuessIndex != _secondGuessIndex)
            {
                _secondCardGuessing = true;
                _secondGuessCard = gameCards[_secondGuessIndex].name;
                Buttons[_secondGuessIndex].image.sprite = gameCards[_secondGuessIndex];
                
                StartCoroutine(CheckIfCardsMatch());
            }
        }
    }

    IEnumerator CheckIfCardsMatch()
    {
        if (_firstGuessCard == _secondGuessCard)
        {
            yield return new WaitForSeconds(.5f);
            OnMatch();
        }
        else
        {
            yield return new WaitForSeconds(.5f);
            OnMismatch();
        }

        yield return new WaitForSeconds(.25f);
        _firstCardGuessing = _secondCardGuessing = false;
    }

    private void OnMatch()
    {
        Buttons[_firstGuessIndex].interactable = false;
        Buttons[_secondGuessIndex].interactable = false;
        Buttons[_firstGuessIndex].image.color = new Color(0, 0, 0, 0);
        Buttons[_secondGuessIndex].image.color = new Color(0, 0, 0, 0);

        _gameScore += MATCHED_SCORE;
        _countCorrectGuesses += 2;
        UpdateScore();

        if (_countCorrectGuesses == gameCards.Count)
        {
            OnGameFinish();
        }
    }

    private void OnMismatch()
    {
        Buttons[_firstGuessIndex].image.sprite = reverseImage;
        Buttons[_secondGuessIndex].image.sprite = reverseImage;

        _gameScore += NOT_MATCHED_SCORE;
        UpdateScore();

        if (_gameScore <= DEFEAT_SCORE)
        {
            OnGameFinish();
        }
    }

    private void OnGameFinish()
    {
        if (_gameScore <= DEFEAT_SCORE)
        {
            foreach (var btn in Buttons)
            {
                btn.interactable = false;
                btn.image.color = new Color(0, 0, 0, 0);
            }
            gameResultText.text = "GAME OVER!";
            gameResultText.enabled = true;
            gameResultText.fontSize = 44;
        }
        else
        {
            gameResultText.text = "YOU WON!";
            gameResultText.enabled = true;
            gameResultText.fontSize = 44;
        }
    }

    void Shuffle()
    {
        for (int i = 0; i < gameCards.Count; i++)
        {
            Sprite temp = gameCards[i];
            int randomIndex = Random.Range(i, gameCards.Count);
            gameCards[i] = gameCards[randomIndex];
            gameCards[randomIndex] = temp;
        }
    }
    
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            Restart();
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            BackToMenu();
        }
    }
    
}