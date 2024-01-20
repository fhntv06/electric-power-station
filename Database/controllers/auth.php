<?
require_once "helper.php";
require_once "connect.php"; // $connect

if ($_POST["type"] == "auth") AuthentificarionUser($connect);
if ($_POST["type"] == "reg") RegistrationUser($connect);

function AuthentificarionUser($connect) {
  $query = "SELECT * FROM `users` WHERE `login`='".$_POST["login"]."' AND `password`='".$_POST["password"]."'";
  $findUser = mysqliQuery($connect, $query, "array");

  if (count($findUser) != 0) {
    echo true;
  } else {
    echo "Пользователь не найден";
  }
}

function RegistrationUser($connect) {
  $query = "SELECT * FROM `users`";
  $allUsers = mysqliQuery($connect, $query);
  $idNewUser = count($allUsers) + 1;

  if ($connect) {
    $query = "INSERT INTO `users` (`id`, `login`, `password`) VALUES ('".$idNewUser."', '".$_POST["login"]."', '".$_POST["password"]."');";
    $response = mysqliQuery($connect, $query, "array");
    
    $query = "INSERT INTO `worker` (`id`, `name`, `fullname`, `phone`, `email`) VALUES ('".$idNewUser."', '".$_POST["name"]."', '".$_POST["fullname"]."', '".$_POST["phone"]."', '".$_POST["email"]."');";
    $response = mysqliQuery($connect, $query, "array");
    
    echo $response;
  } else {
    echo "Ошибка сервера. Регистрация неудалась.";
  }
}
