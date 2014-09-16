<?php header("Content-type: text/html; charset=utf-8"); 
/**
 * 封装一些微信打印机项目中用到的SaeMysql操作
 * @authors Hyde Wang (wanghaiyang@139.me)
 * @date    2014-05-11 13:44:52
 * @version 1.0
 */

class SaeTool
{
	//一些数据库的参数
	//`wx_images` 	:	数据库表的名称
	//`id`			:	唯一标示
	//`user_wxid`	:	用户的微信ID
	//`image_url`	:	待打印图片的url
	//`print_code`	:	打印机的打印码

	static $result_str = 'DEBUG ALL BUG';			//上次执行的结果

	//---------- 打印机API相关 ----------//


    // 添加打印机的uid到printers表中，默认为0 - ok
    static function addPrinter($uid)
    {
        $sql = "REPLACE INTO `printers` (`uid`) VALUES ('".$uid."')";
        self::RunSaeSql($sql);
    }


    // 重置打印机的打印码print_code - ok
    static function getPrintCode($uid)
    {
        $mysql = new SaeMysql();

        // 获取当前的 print code
        $sql = "SELECT `print_code` FROM `printers` WHERE `uid` = '".$uid."'";
        $old_code = $mysql->getVar( $sql );

        // 清空所有 print code 为 old code 的数据
        $sql = "DELETE FROM `wx_images` WHERE `print_code` = '$old_code'";
        $mysql->runSql( $sql );

        // 为了避免重复，先取出所有的print code
        $sql = "SELECT `code` FROM `printers`";
        $codes = $mysql->getData( $sql );

        // 生成新的print code
        $new_code = mt_rand(1000,9999);
        $canAdd = false;

        while (!$canAdd){
            $canAdd = true;
            foreach ($codes as $codeItem){
                if ($codeItem['code'] == $new_code) {
                    $new_code = mt_rand(1000,9999);
                    $canAdd = false;
                    break;
                }
            }
        }

        $sql = "UPDATE `printers` SET `code` = '".$new_code."' WHERE `uid` = '".$uid."'";
        $mysql->runSql( $sql );
        $mysql->closeDb();
        return $new_code;
    }



    //获取打印机需要打印的图片，返回之后删除当条数据
	static function getTaskImage($print_code)
	{
		$mysql = new SaeMysql();
		$sql = "SELECT `image_url` FROM `wx_images` WHERE `print_code` = '$print_code'";
		$data = $mysql->getVar( $sql );
		$sql = "DELETE FROM `wx_images` WHERE `image_url` = '$data'";
		$mysql->runSql( $sql );
        $mysql->closeDb();
		return $data;
	}



	//---------- 微信API相关 ----------//
	//判断输入的字符串是否是消费码：即四位数字
	static function isPrintCode($target_str)
	{
		//正则判断是否为四位的数字
		if(preg_match('/^\d{4}$/',$target_str) === 1)
		{
			return true;
		}
			
		return false;
	}

	//用户发送文字，更新数据库中的print_code
    static function UpdatePrintCode($user_wxid,$print_code)
    {
        $sql = "UPDATE `wx_images` SET `print_code` = '$print_code' WHERE `user_wxid` = '$user_wxid'";
        self::RunSaeSql($sql);
    }

    // 用户发送文字，清除图片和打印码
    static function ClearPrintCode($user_wxid)
    {
        $sql = "DELETE FROM `wx_images` WHERE `user_wxid` = '$user_wxid'";
        self::RunSaeSql($sql);
        return $sql;
    }


	//用户发送图片，更新数据库中的image_url
	static function UpdateImage($user_wxid,$image_url)
	{
		// 如果已经存在，则UPDATE； 如果尚未存在，则INSERT
		$sql = "REPLACE INTO `wx_images` ( `user_wxid` , `image_url` ) VALUES ( '$user_wxid' , '$image_url' )";
		self::RunSaeSql($sql);
	}

	//用户关注公共主页之后，将用户的微信ID写入数据库
	static function InsertUser($user_wxid)
	{
		$sql = "INSERT INTO `wx_images` ( `user_wxid` ) VALUES ( '$user_wxid')";
		self::RunSaeSql($sql);
	}

	//用户取消关注公共主页之后，将用户的微信ID从数据库移除
	static function DeleteUser($user_wxid)
	{
		$sql = "DELETE FROM `wx_images` WHERE `user_wxid` = '$user_wxid'";
		self::RunSaeSql($sql);
	}

	//---------- 测试工具 ----------//
	// 只运行一遍SQL语句
	static function RunSaeSql($sql)
	{
		$mysql = new SaeMysql();
		self::$result_str = $sql;
		$mysql->runSql( $sql );
		$mysql->closeDb();
	}

	//用户发送图片之后，将用户的ID和图片的URL写入数据库
	static function Log()
	{
		return self::$result_str;
	}


}