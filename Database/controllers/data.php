<?
require_once "helper.php";
require_once "connect.php"; // $connect

function data($connect, $type, $action) {

    switch ($action) {
        case 'post':
            postData($connect, $type);
            break;
        case 'get':
            getData($connect, $type);
            break;
    }
}

function getData($connect, $type) {
    switch ($type) {
        case 'exams':
            $query = "SELECT * FROM `tasks` WHERE `user` = ".$_GET["id"].";";
            break;
        case 'instructionandrule':
        case 'tasks':
            $query = "SELECT * FROM `".$type."`";
            break;
    }

    $data = mysqliQuery($connect, $query, "object");
    
    foreach ($data as $index => $array) {
        foreach ($array as $key => $value) {
            $dataToJson['cards'][$index][$key] = $value;
        }
    }

    $echo = $data ? json_encode($dataToJson, JSON_UNESCAPED_UNICODE) : "Данные не получены!";

    echo $echo;
}

function postData($connect, $type) {
    switch ($type) {
        case 'instructionandrule':
        case 'tasks':
            pass($connect, $type);
            break;
    }
}

function pass($connect, $type) {
    $id = $_GET["id"]; // id user
    $field = $_GET["field"]; // number task or number rule
    $value = $_GET["value"]; // id task or id rule
    
    // for only tasks
    $balls = $_GET["balls"]; // balls in task
    $award = $_GET["award"]; // award in task

    // find for id(user) и id(task or rule) 
    $query = "SELECT * FROM ".$type." WHERE `user` = ".$id." AND ".$field." = ".$value.";";
    $isFind = mysqliQuery($connect, $query, "array");

    if (count($isFind) == 0) { // not find
        switch ($type) {
            case 'tasks':
                $query = "SELECT * FROM `tasks`";
                $allTasks = mysqliQuery($connect, $query, "array");
                $idNewTask = count($allTasks);

                $query = "INSERT INTO ".$type." (`id`, ".$field.", `user`, `pass`, `balls`, `award`) VALUES (".$idNewTask.", ".$value.", ".$id.", 1, ".$balls.", ".$award.");";
                break;

            case 'instructionandrule':
                $query = "SELECT * FROM `instructionandrule`";
                $allRules = mysqliQuery($connect, $query, "array");
                $idNewRule = count($allRules) + 1;

                $query = "INSERT INTO ".$type." (`id`, `user`, ".$field.", `pass`) VALUES (".$idNewRule.", ".$id.", ".$value.", '1');";

                break;
        }

    } else { // finded
        $query = "UPDATE ".$type." SET pass=1, award=".$award.", balls=".$balls." WHERE `user` = ".$id." AND ".$field." = ".$value.";";
    }
    echo $query;

    $response = mysqliQuery($connect, $query, "array");
}

$action = $_GET["action"];
$type = $_GET["type"];
data($connect, $type, $action);
