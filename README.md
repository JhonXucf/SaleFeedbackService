# SaleFeedbackService

#### 介绍
售后服务Worker Service

#### 软件架构
软件架构说明
软件使用.netCore 3.1开发
1、SalesFeedBackInfrasturcture数据实体和基础类库
2、AppCommondHelper实用工具类库包含管道通信、Udp\Tcp通信、文件改变监控、Cmd命令辅助、使用UAC启动另一个线程并展示、Log
3、AppSettingsHelper展示界面，界面图标元素来自Iconfont;
   维护基础数据，和Worker Service进行管道通信来展示需要保养维护的设备；
   查看APP产生的log日志，支持关键字查询；
   设置Worker Service的基础配置及是否启动服务等；
4、SaleFeedbackService提供TCP和UDP网络通信服务，可以接受数据并log下来然后再AppSettingsHelper中展示;
   在UDP服务中，检测需要保养的设备，使用了MemeryCache缓存和管道通信。


#### 安装教程

1.  xxxx
2.  xxxx
3.  xxxx

#### 使用说明

1. 使用管理员权限运行AppSettingsHelper展示界面，保存服务配置，安装服务，维护设备信息。

#### 参与贡献

1.  Fork 本仓库
2.  新建 Feat_xxx 分支
3.  提交代码
4.  新建 Pull Request
