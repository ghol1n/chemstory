<?php

header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: POST, GET");
header("Access-Control-Allow-Headers: *");
header("Access-Control-Max-Age: 86400");

$servername = "localhost";
$username = "chemst75_admin";
$password = "admin";
$dbname = "chemst75_chemstorydb";

$numfase = $_POST["numfase"];
$coletaveis = $_POST["coletaveis"];
$tempo = $_POST["tempo"];
$idUsuario = $_POST["idUsuario"];
$pontuacao = $_POST["pontuacao"];


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
echo "Connected successfully";

$sql = "INSERT INTO Progresso_Fase (NumFase, Coletaveis, TempoConclusao, IdUsuario, Pontuacao) VALUES (". $numfase .", ". $coletaveis .", ". $tempo .", ". $idUsuario .", ". $pontuacao .")";
$result = $conn->query($sql);

    if ($conn->query($sql1) === TRUE) {
        echo "Usuário pontuado.";
      } else {
        echo "Error: " . $sql1 . "<br>" . $conn->error;
        
      }   
  $conn->close();
?>
