<?php header("Content-type: text/html; charset=utf-8"); 

/**
 * 微信打印机的打印机调用接口，用来处理用户发送的图片等所有信息
 * @authors Hyde Wang (wanghaiyang@139.me)
 * @date    2014-05-11 13:44:52
 * @version 1.0
 */


include "../sae_tool.php";


// 根据ACTION判断执行的操作
switch ($_GET['action'])
{

	// 获取一个随机的打印码
	case "get_task":
		$print_code = $_POST['print_code'];
		$img_url = SaeTool::getTaskImage($print_code);
		echo $img_url;
		break;

	// 获取一个随机的打印码
	case "reset_code":
		$old_code = $_POST['print_code'];
		$new_code = SaeTool::resetPrintCode($old_code);
		echo $new_code;
		break;

	default:
		echo "ACTION ERROR";
}