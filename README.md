asp.net.SaySay
==============

我的ASP.NET作业,使用mongodb作为数据库,实现的一个发言的平台,SaySay意为 说说.

这个作业和我之前的 [JSP的作业](https://github.com/WenerLove/java.blog)
有点类似,登录界面完全一样的,为了简洁,登录和注册都在同一个界面.

URL 是使用的跳转映射的,包括的动作有

* /by/user 只显示该用户发表的
* /search/keywords 搜索包含该关键词的
* /login /register /logout 分别为 登录,注册,登出

截图
----

![](https://raw.github.com/WenerLove/asp.net.SaySay/master/screenshot_index.png "主页截图")

![](https://raw.github.com/WenerLove/asp.net.SaySay/master/screenshot_loggedin.png "登录后的截图")

![](https://raw.github.com/WenerLove/asp.net.SaySay/master/screenshot_login_and_register.png "注册和登录界面截图")

使用的有
--------

* [MongoDB](http://mongodb.org)
* [BootStrap](http://getbootstrap.com/), [cyborg 主题](http://bootswatch.com/cyborg/)
* JQ
* animate.css
* [font awesome](http://fontawesome.io/)
* [less](http://lesscss.org/)

注意
----

* test.aspx 是用于生成测试数据的