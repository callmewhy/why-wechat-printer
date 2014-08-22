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


	//获取打印机需要打印的图片
	static function getTaskImage($print_code)
	{
		$mysql = new SaeMysql();
		$sql = "SELECT `image_url` FROM `wx_images` WHERE `print_code` = '$print_code'";
		$data = $mysql->getVar( $sql );
		$sql = "DELETE FROM `wx_images` WHERE `image_url` = '$data'";
		$mysql->runSql( $sql );
		return $data;
	}


	//根据重置打印机的打印码print_code
	static function resetPrintCode($old_code)
	{
		//获得当前打印机的数目
		$now_count = self::countPrinters();
		$new_index = mt_rand($now_count%5,$now_count-$now_count%5);
		$mysql = new SaeMysql();

		//先把原先的print_code设为0
		$sql = "UPDATE `wx_printers` SET `is_used` = '0' WHERE `print_code` = '$old_code'";
		$mysql->runSql( $sql );

		//从数据库选择生成print_code
		$sql = "SELECT `print_code` FROM `wx_printers` WHERE `is_used` = '0' LIMIT $new_index , 1";
		$new_code = $mysql->getVar( $sql );
		
		//再把生成的print_code设为1
		$sql = "UPDATE `wx_printers` SET `is_used` = '1' WHERE `print_code` = '$new_code'";
		$mysql->runSql( $sql );

		return $new_code;
	}

	//初始化打印机的打印码，参数为打印机的数目
	static function initPrinters($printers_count)
	{
		$codes = self::unique_rand(1000,9999,$printers_count);
		for ($i=0; $i<$printers_count; $i++)
		{
			$sql = "INSERT INTO `wx_printers` (`print_code` ,`is_used`) VALUES ('".$codes[$i]."', '0')";
			self::RunSaeSql($sql);
		}
	}

	//返回服务器的打印机数目
	static function countPrinters()
	{
		$mysql = new SaeMysql();
		$sql = "SELECT count(*) FROM `wx_printers`";
		$data = $mysql->getVar( $sql );
		return $data;
	}

	//生成一定数量的不重复随机数
	static function unique_rand($min, $max, $num) {
	    $count = 0;
	    $return = array();
	    while ($count < $num) {
	        $return[] = mt_rand($min, $max);
	        $return = array_flip(array_flip($return));
	        $count = count($return);
	    }
	    shuffle($return);
	    return $return;
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
	//用户取消关注公共主页之后，将用户的微信ID从数据库移除
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