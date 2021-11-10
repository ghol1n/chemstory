using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
public class Web : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        // A correct website page.
        // StartCoroutine(GetRequest("https://chemstory.space/Login.php"));
       // StartCoroutine(Login("teste@gmail","123"));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get("https://chemstory.space/Login.php"))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }
    
    public static IEnumerator Conectar(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text.Contains("Login Sucess")) 
                {
                    SceneManager.LoadScene("Tutorial");

                }
                else
                {
                    Login.invalido = "Email ou Senha inválidos";
                }
                   

            }
        }
    }

    public static IEnumerator ConectarEng(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text.Contains("Login Sucess"))
                {
                    SceneManager.LoadScene("Tutorial");
                }
                else
                {
                    LoginEng.invalido = "Invalid Email or Password";
                }


            }
        }
    }

    public static IEnumerator Register(string nickname,string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginNick", nickname);
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/RegisterUser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text.Contains("cadastrado com sucesso."))
                {
                    Cadastro.invalido = "Cadastrado com sucesso.";
                }
                else
                {
                    Cadastro.invalido = "Email ou Apelido já cadastrados.";
                }


            }
        }
    }

    public static IEnumerator RegisterEng(string nickname, string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginNick", nickname);
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/RegisterUser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text.Contains("cadastrado com sucesso."))
                {
                    CadastroEng.invalido = "Registered successfully.";
                }
                else
                {
                    CadastroEng.invalido = "Email or Nickname already registered.";
                }


            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
