<?php
include 'bd.php';

$usu = $pass = '';
$usu = isset($_POST['usu']) ? $_POST['usu'] : '-';
$pass = isset($_POST['pass']) ? $_POST['pass'] : '-';

echo insertVersao($usu, $pass);

function insertVersao($usu, $pass)
{
	$pdo = Conectar();
	$result = 'True';
	
	if($pdo == null)
	{
		echo '<br>deu ruim';
	}
	else
	{
		$sql = 'SELECT * FROM USUARIO WHERE LOGIN = ? AND SENHA = ?';
		
		$stm = $pdo->prepare($sql);
		$stm->bindValue(1, $usu);
		$stm->bindValue(2, $pass);

		$stm->execute();
		$pdo = null;	

		return json_encode($stm->fetchAll(PDO::FETCH_ASSOC));
	}
}

?>