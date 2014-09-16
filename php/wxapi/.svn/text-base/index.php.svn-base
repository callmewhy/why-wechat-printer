<?php
/**
 * 微信打印机的微信调用接口，用来处理用户发送的图片等所有信息
 * @authors Hyde Wang (wanghaiyang@139.me)
 * @date    2014-05-11 13:44:52
 * @version 1.0
 */

include "../wechat.class.php";
include "../sae_tool.php";

$options = array(
    'token'=>'why' //填写你设定的key
);


//实例化WeChat工具
$weObj = new Wechat($options);

//验证来自微信
$weObj->valid();

//获取接收到的微信消息
$weObj = $weObj->getRev();

//发送图片的用户微信ID
$fromUserName = $weObj->getRevFrom();  

//接受到的微信的类型
$revType = $weObj->getRevType();


$welcomeMsg = "欢迎使用微信打印机！\n请按照以下步骤打印照片\n1.发送图片\n2.发送打印码\n稍等片刻后照片就打印好了\n快来发送图片试试吧\n提示：输入任意文字取消打印";
 

switch($revType) {

    case Wechat::MSGTYPE_TEXT:

        //接收到的微信的内容
        $revContent = $weObj->getRevContent(); 

        //如果是打印码，则写入数据库
        if(SaeTool::isPrintCode($revContent))
        {
            //如果发送的是打印码，则更新数据库的打印码
            SaeTool::UpdatePrintCode($fromUserName,$revContent);
            $weObj->text("打印指令已经发出！请等候打印完成")->reply();
        }else{
            SaeTool::ClearPrintCode($fromUserName);
            //如果不是，则提示一下
            $weObj->text($welcomeMsg)->reply();
        }
        break;


    case Wechat::MSGTYPE_IMAGE:

        //如果发送的是图片，则更新数据库的图片URL
        SaeTool::UpdateImage($fromUserName,$weObj->getRevPic());
        $weObj->text("照片已经收到，请输入打印机的打印码，开始打印吧！")->reply();

        break;


    case Wechat::MSGTYPE_EVENT:

        //获取推送的事件
        $event = $weObj->getRevEvent();

        //如果取消订阅，则从数据库移除
        if($event['event'] == "unsubscribe")
        {
            SaeTool::DeleteUser($fromUserName);
        }

        break;

    default:
        $weObj->text($welcomeMsg)->reply();

}


$weObj->text($welcomeMsg)->reply();
