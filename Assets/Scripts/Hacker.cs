using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game configuration data
    const string menuHint = "You may type Menu at any time.";
    string[] level1Passwords = { "Andro", "Mira", "Kuche" };
    string[] level2Passwords = { "Andro1", "Mira1", "Kuche1" };
    string[] level3Passwords = { "Andro2", "Mira2", "Kuche2" };



    //GameStates
    int level;
    string password;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;
    

    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello Player");
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local school");
        Terminal.WriteLine("Press 2 for the neighbours wifi");
        Terminal.WriteLine("Press 3 for nudes");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {

        if (input == "Menu")
        {
            
            ShowMainMenu();
            //TODO handle diffrently depending on screen
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }
    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        
        else
        {
            Terminal.WriteLine("Please choose a valid level");
        }
    }
    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());

    }

    void SetRandomPassword()
    {
        switch (level)
        {

            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)]; ;
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if(input == password)
        {
            WinScreen();
        }

        else
        {
            AskForPassword();
        }
    }

    void WinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
     _______
    /     / /
   /     / /
  /_____/ /
 (______(/");
                break;
            case 2:
                Terminal.WriteLine("The Password is...");
                Terminal.WriteLine("_|_");
                break;
            case 3:
                Terminal.WriteLine("Enjoy");
                Terminal.WriteLine(@"
 |||||
 ||. .||
|||\=/|||
|.-- --.|
/(.) (.)\
\ ) . ( /
'(  v  )`
  \ | /
  ( | )
  '- -`");
                break;
        }
        
    }
}


   

