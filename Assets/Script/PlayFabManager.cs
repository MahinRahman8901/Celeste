using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class PlayFabManager : MonoBehaviour
{
    public InputField email;
    public InputField pass;
    public Text message;

    public void RegisterButton(){

        if (pass.text.Length < 5){ //Checks if password is less than 5 and if it is error message is sent
            message.text = "Password is too short!";
            return;
        }


        var regrequest = new RegisterPlayFabUserRequest{ //requests the playfabapi
            Email = email.text,//requires user to sign register with email and password
            Password = pass.text,
            RequireBothUsernameAndEmail = false //only email is needed
        };

        PlayFabClientAPI.RegisterPlayFabUser(regrequest, RegSuccess, err); //depending on whether the user registers correctly either the success method or error method will run
    

    }


    void RegSuccess(RegisterPlayFabUserResult result){
        message.text = "User has been registered successfully";
    } //Message user receives if logged in successfully



    public void LoginButton(){ // Ssame as register button
        var regrequest = new LoginWithEmailAddressRequest{
            Email = email.text, //requires user to enter email and password then checks it in the database to see if it matches
            Password = pass.text  
        };

        PlayFabClientAPI.LoginWithEmailAddress(regrequest, LoginSucces, err);//depending on whether the user logins correctly either the success method or error method will run
        
    }


    public void ResetButton(){
        var regrequest = new SendAccountRecoveryEmailRequest{
            Email = email.text,//Uses users email and sends the request to that email
            TitleId = "EE263"//titleid set in playfab so it redirects user to  the right game

        };
        
        PlayFabClientAPI.SendAccountRecoveryEmail(regrequest,PassReset, err);//Same as above reasons
    }
    
    void PassReset(SendAccountRecoveryEmailResult result){
        message.text = "Password Reset has been sent to the email!";    
        } //message user sees when they click reset password button

    public void nextScene(){
        SceneManager.LoadScene(1); //loads the next scene which iss the main meny
    }


    void Start()
    {
        login();
    }

    // Update is called once per frame
    void login() //logs the developer(me) into playfab automactically so that they can use its features
    {
        var request = new LoginWithCustomIDRequest{ //Creates request that allows user to login via device they are on
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };

        PlayFabClientAPI.LoginWithCustomID(request, success, err);
    }

    void success(LoginResult result){ //Shows the success messsage
        Debug.Log("Logged Into PlayFab");
        
    }

    void LoginSucces(LoginResult result){ //Shows the success messsage
        message.text=("Loggged in");
        System.Threading.Thread.Sleep(1000);
        Debug.Log("Login has been successfully achieved");
        nextScene(); 
        //when user logs in they see the above message in the log and then it takes them to the next scene
    }

    void err(PlayFabError error){//Shows the Erroro messsage
        message.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }//when there is any error either logging in or registering the error report will print on the screen to show the user what they did wrong

    

    
}
