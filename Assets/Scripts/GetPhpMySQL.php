<?php
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: POST, GET");
header("Access-Control-Allow-Headers: *");
header("Access-Control-Max-Age: 86400");

$servername = "localhost";
$username = "chemst75_admin";
$password = "admin";
$dbname = "chemst75_chemstorydb";

$usuario = $_POST["usuario"];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
//echo "Connected successfully $var <br>";

$sql = "SELECT * from Progresso_Fase WHERE Usuario = $usuario;";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
      echo "Fase: ". $row["NumFase"]. " UsuÁrio: " . $row["Usuario"]. " ColetÁveis: " . $row["Coletaveis"]. " Tempo de ConclusÃo: " . $row["TempoConclusao"]. " PontuaÇÃo: ". $row["Pontuacao"]. " ConcluÍdo em: ".$row[created_at]. ";"
    }
  } else {
    echo "0 results";
  }
  $conn->close();
?>
