<?php

header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: POST, GET");
header("Access-Control-Allow-Headers: *");
header("Access-Control-Max-Age: 86400");

$servername = "localhost";
$username = "chemst75_admin";
$password = "admin";
$dbname = "chemst75_chemstorydb";

$loginNick = $_POST["loginNick"];
$loginUser = $_POST["loginUser"];
$loginPass = $_POST["loginPass"];


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
echo "Connected successfully";

$sql = "SELECT * from Usuarios WHERE Email = '" . $loginUser . "' or Apelido = '" . $loginNick . "'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // output data of each row
    
        echo "Apelido ou Email já cadastrado.";
  } else {
    $sql1 = "INSERT INTO Usuarios (Apelido, Email, Senha)
    VALUES ('". $loginNick ."', '".  $loginUser ."', AES_ENCRYPT('". $loginPass . "', 'zeus'))";
    if ($conn->query($sql1) === TRUE) {
        echo "Usuário cadastrado com sucesso.";
      } else {
        echo "Error: " . $sql1 . "<br>" . $conn->error;
        
      }    
  }
  $conn->close();
?>
