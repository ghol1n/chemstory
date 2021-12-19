<?php   
require_once('/PHPMailer.php');
require_once('/SMTP.php');
require_once('/Exception.php');
$loginUser = $_POST["loginUser"];

use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\SMTP;
use PHPMailer\PHPMailer\Exception;


 
$mail = new PHPMailer(true);
$sql = "SELECT AES_DECRYPT(Senha,'zeus'), EmailSeguranca from Usuario WHERE Email = $loginUser";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
try {
	$mail->SMTPDebug = SMTP::DEBUG_SERVER;
	$mail->isSMTP();
	$mail->Host = 'smtp.gmail.com';
	$mail->SMTPAuth = true;
	$mail->Username = 'chemstorypi@gmail.com';
	$mail->Password = 'fagnaodeus';
	$mail->Port = 587;
 
	$mail->setFrom('chemstorypi@gmail.com');
	$mail->addAddress($row["EmailSeguranca"]);
 
	$mail->isHTML(true);
	$mail->Subject = 'Recuperação de Senha - Chemstory';
	$mail->Body = 'Caro jogador(a), sua senha é: ';
    //.$row["AES_DECRYPT(Senha,'zeus')"]'';
	$mail->AltBody = '';
 
	if($mail->send()) {
		echo 'Email enviado com sucesso';
	} else {
		echo 'Email nao enviado';
	}
} catch (Exception $e) {
	echo "Erro ao enviar mensagem: {$mail->ErrorInfo}";
}
}
?>

