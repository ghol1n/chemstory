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
$numfase = $_POST["numfase"];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
//echo "Connected successfully $var <br>";

$sql = "SELECT   apelido, sum(pontuacao) from (SELECT * from Progresso_Fase where NumFase = "1" group by usuario 
union
SELECT * from Progresso_Fase where NumFase = "2" group by usuario 
UNION
SELECT * from Progresso_Fase where NumFase = "3" group by usuario 
ORDER BY pontuacao desc) a
join Usuario u on u.Email = a.usuario
group by apelido
order by sum(pontuacao) desc
limit 10";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
    echo($result)    
}
  } else {
    echo "0 results";
  }
  $conn->close();
?>
