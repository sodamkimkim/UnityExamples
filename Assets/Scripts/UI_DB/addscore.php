<?php
// asp, jsp, php

$servername = "localhost:3306";// $ : ���� ����. :db��Ʈ
$username = "root";
$password = "asd123";
$dbname = "db_score";

$id = $_POST["id"]; // "id" Ű�� WWWForm���� ���� "id"Ű�� ���� �ؼ� �ش� Ű�� value ����
$pw = $_POST["pw"];
$score = $_POST["score"];

$conn = new mysqli($servername, $username, $password, $dbname); // db connect ���� conn.

if($conn->connect_error){
		die("connection failed: ". $conn->connect_error);
}

$sql = "SELECT * FROM tb_score WHERE id = '" . $id."'";
// ������ �� ��ü�� ���� ����
$result = $conn->query($sql); // db ���ᰴü ���� �ʱ�ȭ - select ��� result�� �޾���
	
// echo .$sql;
if($result->num_rows > 0){
	$update_sql = "UPDATE tb_score SET score = '".
				$score . "', pw = " . $pw .  " WHERE id = '" . $id . "'";
	$conn->query($update_sql); // db ���ᰴü ���� �ʱ�ȭ
 echo $update_sql;
}
else{  // ���̵� ������ �߰��� ��
	$insert_sql = "INSERT INTO tb_score(id, pw, score)
	VALUES('" . $id . "','" . $pw . "', '".$score."')";
	$conn->query($insert_sql); // db ���ᰴü ���� �ʱ�ȭ
 echo $insert_sql;
}
//echo $score;
echo ", ".$result->num_rows;
$conn->close();
?>