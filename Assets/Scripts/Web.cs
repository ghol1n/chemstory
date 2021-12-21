using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Net;
using System;


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


    public static IEnumerator Session()
    {
        WWWForm form = new WWWForm();

        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/ip.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Debug.Log(www.downloadHandler.text);
                if (!String.IsNullOrEmpty(www.downloadHandler.text)) { 
                Login.usuarioButom = www.downloadHandler.text;
                    LoginEng.usuarioButom = www.downloadHandler.text;
                };
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
                    SceneManager.LoadScene("TutorialEng");
                }
                else
                {
                    LoginEng.invalido = "Invalid Email or Password";
                }


            }
        }
    }

    public static IEnumerator getUserId(string username)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);

        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/getId.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                Login.usuarioid = www.downloadHandler.text;
            }
        }
    }

    public static IEnumerator Register(string nickname,string username, string password, string usernameSeg)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginNick", nickname);
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);
        form.AddField("loginSeg", usernameSeg);


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
                    Login.usuario = username;
                    Cadastro.invalido = "Cadastrado com sucesso.";
                    Thread.Sleep(1000);
                    SceneManager.LoadScene("Tutorial");
                    }
                
                else
                {
                    Cadastro.invalido = "Email, Apelido ou Email de segurança já cadastrados.";
                }


            }
        }
    }

    public static IEnumerator RegisterEng(string nickname, string username, string password, string usernameSeg)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginNick", nickname);
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);
        form.AddField("loginSeg", usernameSeg);

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
                    Login.usuario = username;
                    CadastroEng.invalido = "Registered successfully.";
                    Thread.Sleep(1000);
                    SceneManager.LoadScene("TutorialEng");
                }
                else
                {
                    CadastroEng.invalido = "Email, Nickname or Security Email already registered.";
                }


            }
        }
    }

    

        public static IEnumerator Pontuar(int numfase, int coletaveis, int tempo, string usuario, int pontuacao)
        {
            WWWForm form = new WWWForm();
            form.AddField("numfase", numfase);
            form.AddField("coletaveis", coletaveis);
            form.AddField("tempo", tempo);
            form.AddField("usuario", usuario);
            form.AddField("pontuacao", pontuacao);

            using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/PontuarFase.php", form))
            {
                yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    Debug.Log(www.downloadHandler.text);
                        SceneManager.LoadScene("Pontuacao_"+numfase.ToString());

                }
            }
        }

    public static IEnumerator PontuarEng(int numfase, int coletaveis, int tempo, string usuario, int pontuacao)
    {
        WWWForm form = new WWWForm();
        form.AddField("numfase", numfase);
        form.AddField("coletaveis", coletaveis);
        form.AddField("tempo", tempo);
        form.AddField("usuario", usuario);
        form.AddField("pontuacao", pontuacao);

        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/PontuarFase.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                SceneManager.LoadScene("Pontuacao_" + numfase.ToString()+"Eng");

            }
        }
    }

    public static IEnumerator GetPontuacao(string usuario, int numfase)
    {
        WWWForm form = new WWWForm();
        form.AddField("usuario", usuario);
        form.AddField("numfase", numfase.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/GetPontuacaoFase.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                GetPontuacaoFase.pontuacao = www.downloadHandler.text;
            }
        }
    }

    public static IEnumerator GetPontuacaoEng(string usuario, int numfase)
    {
        WWWForm form = new WWWForm();
        form.AddField("usuario", usuario);
        form.AddField("numfase", numfase.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/GetPontuacaoFaseEng.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                GetPontuacaoFaseEng.pontuacao = www.downloadHandler.text;
            }
        }
    }

    public static IEnumerator GetEmailSeg(string username)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);


        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/GetEmailSeguranca.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text.Contains("0 results"))
                {
                    Thread.Sleep(1000);
                    Login.invalido = "Email inexistente";
                }

                else
                {
                    Login.EmailSeg = www.downloadHandler.text;
                    SenhaEnviada.result = Login.EmailSeg.Substring(Login.EmailSeg.Length - 16).PadLeft(Login.EmailSeg.Length, '*');
                }


            }
        }
    }

    public static IEnumerator GetSenha(string username)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);


        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/GetSenha.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Login.SenhaSeg = www.downloadHandler.text;
                Debug.Log(www.downloadHandler.text);
                Login.foi = 1;

            }
        }
    }

    public static IEnumerator Esqueci(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);


        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/EnvioSenha.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text.Contains("sucesso"))
                {
                    Thread.Sleep(1000);
                    SceneManager.LoadScene("SenhaEnviada");
                }

                else
                {
                    Cadastro.invalido = "Email inexistente.";
                }


            }
        }
    }

    public static IEnumerator GetEmailSegEng(string username)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);


        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/GetEmailSeguranca.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text.Contains("0 results"))
                {
                    Thread.Sleep(1000);
                    Login.invalido = "Inexistent Email";
                }

                else
                {
                    Login.EmailSeg = www.downloadHandler.text;
                    SenhaEnviada.result = Login.EmailSeg.Substring(Login.EmailSeg.Length - 16).PadLeft(Login.EmailSeg.Length, '*');
                }


            }
        }
    }

    public static IEnumerator GetSenhaEng(string username)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);


        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/GetSenha.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Login.SenhaSeg = www.downloadHandler.text;
                Debug.Log(www.downloadHandler.text);
                LoginEng.foi = 1;

            }
        }
    }

    public static IEnumerator EsqueciEng(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);


        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/EnvioSenha.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text.Contains("sucesso"))
                {
                    Thread.Sleep(1000);
                    SceneManager.LoadScene("SenhaEnviadaEng");
                }

                else
                {
                    Cadastro.invalido = "Inexistent Email.";
                }


            }
        }
    }

    public static IEnumerator GetRankingApelido()
    {
        WWWForm form = new WWWForm();

        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/GetRankingNickname.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                GetRanking.apelido = www.downloadHandler.text;
            }
        }
    }
    public static IEnumerator GetRankingTotal()
    {
        WWWForm form = new WWWForm();

        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/GetRankingTotal.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                GetRanking.total = www.downloadHandler.text;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
