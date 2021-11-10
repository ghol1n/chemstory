<?php

header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: POST, GET");
header("Access-Control-Allow-Headers: *");
header("Access-Control-Max-Age: 86400");

$servername = "localhost";
$username = "chemst75_admin";
$password = "admin";
$dbname = "chemst75_chemstorydb";

$loginUser = $_POST["loginUser"];
$loginPass = $_POST["loginPass"];
$IP = $_SERVER['REMOTE_ADDR'];


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
echo "Connected successfully";

$sql = "SELECT AES_DECRYPT(Senha,'zeus') from Usuarios WHERE Email = '" . $loginUser . "'";
$result = $conn->query($sql);

$sql1 = "INSERT INTO Secoes (IP, Email, created_at)
    VALUES ('". $IP ."', '".  $loginUser ."', CURRENT_TIMESTAMP)";

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
      if($row["AES_DECRYPT(Senha,'zeus')"] == $loginPass){
          echo "Login Sucess.";
          if ($conn->query($sql1) === TRUE) {
            echo "Secao cadastrada";
          }
      }else
        echo "Senha inválida";
    }
  } else {
    echo "Usuário inexistente.";
    echo($loginUser);
  }
  $conn->close();
?>
