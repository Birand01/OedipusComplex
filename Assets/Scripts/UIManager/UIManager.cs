using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum Sex
{
    Male, Female
}
public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text destinyText;
    [SerializeField] Button menuButton,nextLevelButton;
   
    private string destinyStoy;
    private Sex currentSex;
    private void Awake()
    {
       
        destinyStoy = "";
        destinyText.text = destinyStoy;
    }
    private void Start()
    {
      
        SexChoice();
        DestinyTextCoroutine();
    }
    private void OnEnable()
    {
        PlayerFateAchievement.OnLevelEnd += MenuButtonVisibility;
    }
    
    public void MenuScene()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadNextLevel()
    {
        CharacterSelection.Instance.isGameActive = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void MenuButtonVisibility()
    {
        menuButton.gameObject.SetActive(true);
        nextLevelButton.gameObject.SetActive(true);
    }

   


    private void SexChoice()
    {
        int choice = CharacterSpawner.Instance.selectedCharacter;
        if (choice == 0)
        {
            currentSex = Sex.Female;
        }
        else if (choice == 1)
        {
            currentSex = Sex.Male;
        }
    }
    private void DestinyTextCoroutine()
    {
        switch (currentSex)
        {
            case Sex.Female:
                StartCoroutine(DestinyTextCoroutine("Father", destinyText, 5.0f));
                break;
            case Sex.Male:
                StartCoroutine(DestinyTextCoroutine("Mother", destinyText, 5.0f));
                break;
        }
    }
    IEnumerator DestinyTextCoroutine(string textContent, TMP_Text destinyText, float time)
    {
        destinyText.text = "When I grow up,I will marry with my " + textContent;
        yield return new WaitForSeconds(time);
        destinyText.gameObject.SetActive(false);

    }
    private void OnDisable()
    {
        PlayerFateAchievement.OnLevelEnd -= MenuButtonVisibility;
    }
}
