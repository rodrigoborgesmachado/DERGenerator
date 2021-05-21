<?php
include 'bd.php';

$user = isset($_POST['user']) ? $_POST['user'] : '-';
$pass = isset($_POST['pass']) ? $_POST['pass'] : '0';

echo insertUsuario($user, $pass);

function insertUsuario($user, $pass)
{
	$pdo = Conectar();
	$result = 'True';
	
	if($pdo == null || $chaveGuid == '-')
	{
		$result = 'False';
	}
	else
	{
		$sql = 'INSERT INTO USUARIO (USER, PASS) VALUES (?, ?)';
		$stm = $pdo->prepare($sql);
		$stm->bindValue(1, $user);
		$stm->bindValue(2, $pass);
		
		if($stm->execute() == false)
		{
			$result = 'False';
		}
		
		$pdo = null;	
	}
	
	$r['Result'] = $result;	
	return json_encode($r);
}

?>