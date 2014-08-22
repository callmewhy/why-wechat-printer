why-wechat-printer
==================
基于C#和PHP的微信打印机


### 使用方法：
源码基于SAE(Sina App Engine)开发，数据库调用等相关内容均为`SaeMysql`相关内容，如有自定义的必要可以修改相关代码。


玩一玩版本
=========
运行C#客户端，按照提示玩耍即可。



自定义版本
==========
#### PHP - 后台服务器端

- 修改代码中和SAE相关部分，满足实际开发环境需要。
- 将php文件夹放在服务器中，假设服务器地址为：http://yoursite.com。
- php文件夹下有两个目录，pcapi为打印机端调用的接口，wxapi为微信端调用的接口。
- 通过`initPrinters`函数初始化打印机的随机编号数据库。
- 在微信公众平台设置开发者模式，url为http://yoursite.com/wxapi，key为why。


#### C# - 打印客户端

- 修改WxPrinter中定义的`API_URL`变量，将地址改为自己的服务器地址。



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
