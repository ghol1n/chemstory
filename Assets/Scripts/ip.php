<?php

header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: POST, GET");
header("Access-Control-Allow-Headers: *");
header("Access-Control-Max-Age: 86400");

$servername = "localhost";
$username = "chemst75_admin";
$password = "admin";
$dbname = "chemst75_chemstorydb";

$IP = $_SERVER['REMOTE_ADDR'];
$loginUser = $_POST["loginUser"];

$conn = new mysqli($servername, $username, $password, $dbname);

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
  }

  $sql = "SELECT * from Secoes WHERE IP = '" . $IP . "' order by Created_at desc limit 1;";
$result = $conn->query($sql);

if ($result->num_rows > 0){
    while($row= $result->fetch_assoc()){
        echo $row["Email"];
    }
}
$conn->close();


?>