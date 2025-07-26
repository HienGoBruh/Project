<?php
class connect{
    //Khởi tạo thuộc tính cho lớp connect
    public $db = null;

    //Kết nối database
    public function __construct(){ //ham khoi tao
        $dsn='mysql:host=sql206.infinityfree.com;dbname=if0_39556351_delice';
        $user='if0_39556351'; $pass='pqhiHebUW4RIk6x';
        $this->db=new PDO($dsn,$user,$pass, array(PDO::MYSQL_ATTR_INIT_COMMAND
        => "SET NAMES utf8"));
    }
    //Lấy dữ liệu database
    public function getlist($select){
        $result = $this->db->query($select);
        return $result;
    }
    //Tạo phương thức câu lệnh insert, update, delete
    public function exec($query){
        $result = $this->db->exec($query);
        return $result;
    }
    public function getInstance($select){
        $results = $this->db->query($select);
        $result = $results->fetch();
        return $result;
    }
public function prepare($sql) {
    return $this->db->prepare($sql);
}
} 

?>
