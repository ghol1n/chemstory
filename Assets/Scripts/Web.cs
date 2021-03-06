using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Net;
using System;
using UnityEngine.UI;
using Mgl;

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





    public static IEnumerator Conectar(string username, string password, string token)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);
        form.AddField("token", token);

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
                if (www.downloadHandler.text.Contains("Login Success")) 
                {
                    Login.LoginSuccess = true;
                    using (UnityWebRequest wwww = UnityWebRequest.Post("https://chemstory.space/Cookie.php", form))
                    {
                        yield return wwww.SendWebRequest();

                        if (wwww.result != UnityWebRequest.Result.Success)
                        {
                            Debug.Log(wwww.error);
                        }
                        else
                        {
                        }
                    }
                    if (Login.numFaseProgresso == "0 results")
                    {
                        SceneManager.LoadScene("Tutorial");
                    }
                    else
                    {
                        if ((Int16.Parse(Login.numFaseProgresso) == 15)){
                            SceneManager.LoadScene("lvl_1");
                        }

                    }
                    {
                        SceneManager.LoadScene("lvl_" + (Int16.Parse(Login.numFaseProgresso) + 1));
                    }
                    
                    

                }
                else
                {
                    I18n i18n = I18n.Instance;    
                    Login.invalido = i18n.__("Invalid Email or Password");
                }
                   

            }
        }
    }

    public static IEnumerator Cookie(string username, string token)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("token", token);


        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/GetCookie.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text.Contains("invalido"))
                {
                    SceneManager.LoadScene("FimConexao");
                }
                else
                {
                }


            }
        }
    }

    private static void SetRequestHeader(string v1, string v2)
    {
        throw new NotImplementedException();
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
                    if (Login.numFaseProgresso == "0 results")
                    {
                        SceneManager.LoadScene("TutorialEng");
                    }
                    else
                    {
                        SceneManager.LoadScene("lvl_" + Login.numFaseProgresso);
                    }
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
                    SceneManager.LoadScene("Cadastrado");
                    }
                
                else
                {
                    I18n i18n = I18n.Instance;
                    Cadastro.invalido = i18n.__("Email, Nickname or Security Email already registered.");
                    SceneManager.LoadScene("EmailExistente");
                }


            }
        }
    }

    public static IEnumerator TesteEmail(string username)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);


        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/TesteUser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text.Contains("nao existe"))
                {
                    Login.usuario = username;
                    //Cadastro.invalido = "";
                    Thread.Sleep(1000);
                    //SceneManager.LoadScene("Cadastrado");
                    Cadastro.existe = false;
                    System.Threading.Thread.Sleep(500);
                    System.Threading.Thread.Sleep(500);
                }

                else
                {
                    
                    I18n i18n = I18n.Instance;
                    Cadastro.invalido = i18n.__("Email, Nickname or Security Email already registered.");
                    Cadastro.existe = true;
                    System.Threading.Thread.Sleep(500);
                    System.Threading.Thread.Sleep(500);
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
                if(numfase != 15) { 
                    Debug.Log(www.downloadHandler.text);
                        SceneManager.LoadScene("Pontuacao_1");
                }
                else
                {
                    Debug.Log(www.downloadHandler.text);
                    SceneManager.LoadScene("PontuacaoFinal");
                }

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
                if (numfase != 15)
                {
                    Debug.Log(www.downloadHandler.text);
                    SceneManager.LoadScene("Pontuacao_" + numfase.ToString() + "Eng");
                }
                else
                {
                    Debug.Log(www.downloadHandler.text);
                    SceneManager.LoadScene("PontuacaoFinalEng");
                }
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

    public static IEnumerator GetProgresso(string usuario)
    {
        WWWForm form = new WWWForm();
        form.AddField("usuario", usuario);

        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/GetProgresso.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                Login.numFaseProgresso = (www.downloadHandler.text);

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
                GetPontuacaoFase.pontuacao = www.downloadHandler.text;
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
                    I18n i18n = I18n.Instance;
                    Login.invalido = i18n.__("Non-existent email");
                    Cadastro.ExisteCheck = true;
                    Cadastro.existe = false;
                }

                else
                {
                    Login.EmailSeg = www.downloadHandler.text;
                    Debug.Log(www.downloadHandler.text + Login.EmailSeg);
                    SenhaEnviada.result = Login.EmailSeg.Substring(5).PadLeft(Login.EmailSeg.Length, '*');
                    SenhaEnviada.emailSeg = Login.EmailSeg;
                    Login.foi = 1;
                    Cadastro.ExisteCheck = true;
                    Cadastro.existe = true;
                }


            }
        }
    }

    public static IEnumerator GetEmail(string username)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);


        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/GetEmail.php", form))
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
                    I18n i18n = I18n.Instance;
                    Login.invalido = i18n.__("Non-existent email");
                    Cadastro.ExisteCheck = true;
                    Cadastro.existe = false;
                }

                else
                {
                    Login.EmailSeg = www.downloadHandler.text;
                    Debug.Log(www.downloadHandler.text + Login.EmailSeg);
                    SenhaEnviada.result = Login.EmailSeg.Substring(5).PadLeft(Login.EmailSeg.Length, '*');
                    Login.foi = 1;
                    Cadastro.ExisteCheck = true;
                    Cadastro.existe = true;
                }

                Debug.Log("? ISSO: " + username);


            }
        }
    }



    /* public static IEnumerator GetSenha(string username)
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
     }*/

    public static IEnumerator Esqueci(string username)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);


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
            }
        }
    }

    public static IEnumerator ChecarEmail(string username)
    {
        WWWForm form = new WWWForm(); 
        form.AddField("loginUser", username);
        
        if (Cadastro.existe != true) { 
            using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/EnvioEmail.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                    EmailEnviado.result = username;
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text.Contains("sucesso"))
                {
                    Thread.Sleep(1000);
                    if (Cadastro.existe != true) 
                    { SceneManager.LoadScene("EmailEnviado"); };
                }
            }
        }
        }
    }
    /* public static IEnumerator GetEmailSegEng(string username)
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
     }*/

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
                    Cadastro.invalido = "Nonexistent Email.";
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

    //metodo novo
    //pega os IDs dos desafios que tem o nivel de dificuldade informado
    public static IEnumerator GetIdDificuldade(int dificuldade)
    {
        
        WWWForm form = new WWWForm();
        form.AddField("dificuldade", dificuldade);

        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/idDificuldade.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {

                Debug.Log(www.downloadHandler.text);
                challange_new.conteudoDificuldade = www.downloadHandler.text.Split('#');
                int i = 0;
               // Debug.Log("challenge new: "+ challange_new.conteudoDificuldade[0]);
               // Debug.Log("challenge new: "+ challange_new.conteudoDificuldade[1]);
              //  Debug.Log("challenge new: "+ challange_new.conteudoDificuldade[2]);
               // Debug.Log("challenge new: "+ challange_new.conteudoDificuldade[3]);
               // Debug.Log("challenge new: "+ challange_new.conteudoDificuldade[4]);
               // Debug.Log("challenge new: " + challange_new.conteudoDificuldade[5]);
            }
        }


    }

    // fim metodo novo

    public static IEnumerator GetPergunta(int id)
    {

        //Debug.Log("dificuldade: "+dificuldade);
        WWWForm form = new WWWForm();
        Debug.Log(id);
        form.AddField("id", (id*2)-1);
       // form.AddField("dificuldade", (dificuldade));
        challange_new.numPergunta = (id * 2 -1);
        Debug.Log("numero procurado: " + challange_new.numPergunta);

        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/GetPergunta.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                challange_new.conteudo = www.downloadHandler.text.Split('#');
                challange_new.respostas[0] = challange_new.conteudo[2];
                challange_new.respostas[1] = challange_new.conteudo[3];
                challange_new.respostas[2] = challange_new.conteudo[4];
                challange_new.respostas[3] = challange_new.conteudo[5];
                //challange_new Pergunta.text = challange_new.conteudo[0];
            }
        }
    }
    public static IEnumerator GetPerguntaEng(int id)
    {
        WWWForm form = new WWWForm();
        Debug.Log(id);
        form.AddField("id", (id * 2));
        challange_new.numPergunta = (id * 2);

        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/GetPergunta.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                challange_new.conteudo = www.downloadHandler.text.Split('#');
                challange_new.respostas[0] = challange_new.conteudo[2];
                challange_new.respostas[1] = challange_new.conteudo[3];
                challange_new.respostas[2] = challange_new.conteudo[4];
                challange_new.respostas[3] = challange_new.conteudo[5];
            }
        }
    }

    public static IEnumerator AlterarSenha(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);


        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/AlterarSenha.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text.Contains("com sucesso."))
                {
                    Login.usuario = username;
                    SceneManager.LoadScene("SenhaAlterada");
                }

                else
                {
                    Cadastro.invalido = "Email invalido.";
                }


            }
        }
    }
    public static IEnumerator AlterarSenhaEng(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);


        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/AlterarSenha.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text.Contains("com sucesso."))
                {
                    Login.usuario = username;
                    SceneManager.LoadScene("SenhaAlteradaEng");
                }

                else
                {
                    Cadastro.invalido = "Email invalido.";
                }


            }
        }
    }
    public static IEnumerator VerificarToken(string token, string user)
    {
        WWWForm form = new WWWForm();
        form.AddField("UserToken", token);
        form.AddField("loginUser", user);

        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/VerificarToken.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text.Contains("validado"))
                {
                    SceneManager.LoadScene("AlterarSenha");
                }
                else
                {
                    SenhaEnviada.invalido = "Token Incorreto.";
                }
            } 

            }
        }

    public static IEnumerator VerificarTokenEmail(string token, string user)
    {
        WWWForm form = new WWWForm();
        form.AddField("UserToken", token);
        form.AddField("loginUser", user);

        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/VerificarToken.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text.Contains("validado"))
                {
                    SceneManager.LoadScene("TentarCadastro");
                }
                else
                {
                    SenhaEnviada.invalido = "Token Incorreto.";
                }
            }

        }
    }

    public static IEnumerator VerificarTokenEng(string token, string user)
    {
        WWWForm form = new WWWForm();
        form.AddField("UserToken", token);
        form.AddField("loginUser", user);

        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/VerificarToken.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text.Contains("validado"))
                {
                    SceneManager.LoadScene("AlterarSenhaEng");
                }
                else
                {
                    SenhaEnviada.invalido = "Token Incorreto.";
                }
            }

        }
    }

    public static IEnumerator VerificarResposta(string resposta, int pergunta)
    {
        WWWForm form = new WWWForm();
        form.AddField("resposta", resposta);
        form.AddField("numPergunta", pergunta);


        using (UnityWebRequest www = UnityWebRequest.Post("https://chemstory.space/VerificarResposta.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {Debug.Log(resposta);
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text.Contains("correta"))
                {
                    challange_new.correto = true;
                    Debug.Log(www.downloadHandler.text);
                    challange_new.jarecebeu = true;


                    int pontuacao = (GameController1.totalScore / GameControllerD1.totalTime) * 175;
                    if (pontuacao < GameController1.totalScore)
                    {
                        pontuacao = GameController1.totalScore;
                    }
                    //  Debug.Log(GameController1.totalScore);
                    // Debug.Log(GameControllerD1.totalTime);
                    Debug.Log(Login.usuario);


                    // Debug.Log(pontuacao);
                }
                else
                {
                    challange_new.correto = false;
                    Debug.Log(www.downloadHandler.text);
                        SceneManager.LoadScene("errado");
                    challange_new.correto = false;
                }


            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
