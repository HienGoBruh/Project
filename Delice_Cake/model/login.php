<?php
require_once 'model/master.php';

class ModelLogin extends MasterModel {

    public function verifyUser($username, $password) {
        return parent::checkLogin($username, $password);
    }

    public function getUserByUsername($username) {
        return parent::getUser($username);
    }
}

?>