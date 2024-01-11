<?php
$servername = "localhost:3306";
$username = "root";
$password = "asd123";
$dbname = "db_score";

$id = $_POST["id"];
$score = $_POST["score"];
$limits = $_POST["limits"];
// echo  $id.$score.$limits;

$conn = new mysqli($servername, $username, $password, $dbname);
if($conn->connect_error)
{
	die("connection failed : ".$conn->connect_error);
}

$sql = "SELECT * FROM tb_score WHERE id = '" .$id."'";
$result = $conn->query($sql);
// echo $sql;

if($result->num_rows > 0) // 기존에 id있으면 update문 실행
{ // update tb_score set score = '1111' where id = 'aaa';
	$update_sql = "UPDATE tb_score SET score = '".$score."' WHERE id = '".$id."'";
	$conn->query($update_sql);
	// echo $update_sql;
}
else{
	$insert_sql = "INSERT INTO tb_score(id, score)
	VALUES('".$id."',".$score.")";
	$conn->query($insert_sql);
	echo $insert_sql;
}

$conn->close();
?>