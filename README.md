why-wechat-printer
==================
基于C#和PHP的微信打印机


## 使用方法：
源码基于SAE(Sina App Engine)开发，数据库调用等相关内容均为`SaeMysql`相关内容，如有自定义的必要可以修改相关代码。


### 玩一玩版本
运行C#客户端，按照提示玩耍即可。**F1**全屏切换。



### 自定义版本
- PHP - 后台服务器端
  - 修改代码中和SAE相关部分，满足实际开发环境需要。
  - 将php文件夹放在服务器中，假设服务器地址为：http://yoursite.com 。
  - php文件夹下有两个目录，pcapi为打印机端调用的接口，wxapi为微信端调用的接口。
  - 通过`initPrinters`函数初始化打印机的随机编号数据库。
  - 在微信公众平台设置开发者模式，url为http://yoursite.com/wxapi ，key为why。


- C# - 打印客户端
  - 修改WxPrinter中定义的`API_URL`变量，将地址改为自己的服务器地址。

- MySQL - 数据库
  数据库中有两张表
  - `wx_images` - 存储打印照片的命令
  
  |`id`|`user_wxid`|`image_url`|`print_code`|
  |----|-----------|-----------|------------|
  |编号|用户的微信ID|图片的URL地址|打印机的打印编码|
  
  
  
  - `wx_printers` - 存储打印机的打印编号（可以通过`SaeTool`中的`initPrinters`函数初始化1000条数据）
  
  |`id`|`print_code`|`is_used`|`used_time`|
  |----|------------|-----------|------------|
  |编号|打印编号    |该编号是否被使用|打印码的注册事件|



## TODO
- 有时候这SAE响应也太慢了，对响应慢的情况没做处理。
- C#访问API有时候是有缓存还是怎么着，会有点问题。



## 总之
为各位提供一个打印机的实现思路，仅做参考。

![](http://callmewhy.qiniudn.com/%E5%BE%AE%E4%BF%A1%E6%89%93%E5%8D%B0%E6%9C%BA%E8%AE%BE%E8%AE%A1%E6%80%9D%E8%B7%AF.png)

## 思路参考

### 微信的后台接口
用户把照片发给微信公共账号，在接收到的时候是有图片的url的，所以我们不用考虑图片的存储问题。
在接收到用户发送图片消息的时候，把用户的ID和图片的地址写入到数据库的wx_images表中，
在接受到用户的文字信息的时候，判断一下是不是四位数字的打印码，然后写入到刚刚那条记录里，以供打印机根据打印码获取。
至此，微信接口的任务就算是完成了。


### 打印机的后台接口
打印机在运行之后，首先要做的事情是获取打印码。
设置打印码的目的，是为了防止有人随便发送照片捣乱。所以在打印机刚运行的时候，要去服务器获取它自己的打印码。
为了防止打印码重复，新建了一个`wx_printers`表。
用random随机插入了100条数据，也就是100个随机的打印码，然后用一个状态标示符来标记这个打印码的状态是已用还是未用。
打印机运行之后会先去服务器获取一个打印码并存到本地，然后根据这个打印码不断地访问服务器，获取打印任务。
获取到打印任务之后，直接下载图片并存到本地的临时文件，然后调用打印的接口。 





--------------------

The MIT License (MIT)

Copyright (c) <year> <copyright holders>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
