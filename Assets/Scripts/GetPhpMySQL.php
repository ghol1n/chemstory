<?php
$servername = "localhost";
$username = "root";
$password = "123";
$dbname = "chemstorydb";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
echo "Connected successfully $var <br>";

$sql = "SELECT * from usuarios;";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
      echo "id: " . $row["id"]. " - apelido: " . $row["Apelido"]. " - senha: " . $row["Senha"]. "<br>";
    }
  } else {
    echo "0 results";
  }
  $conn->close();
?>
