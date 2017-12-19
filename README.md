## Demo开发环境
mac：macOS Sierra 10.12.6
unity: version 2017.1.1f1 Personal
xcode: Version 9.1 (9B55)
cocoapods: 1.2.1
## 一. Unity示例程序，模拟待接入可玩广告的游戏
### 1. 主体界面如下及基本配制
![image](/images/image01.png)
### 2. Main Camera的控件文件如下：
![image](/images/image02.png)
## 二. 配置可玩广告
### 1. 导入可玩插件包：Assets->Import Package -> Custom Package...
![image](/images/image03.png)
### 2. 选择下载好的PlayableAds插件包，双击打开
![image](/images/image04.png)
### 3. 导入全部文件，如果项目中有同名目录，文件会直接复制到相应文件夹下。点击import导入。
![image](/images/image05.png)
### 4. 在相应GameObject下配置脚本文件
![image](/images/image06.png)
![image](/images/image07.png)
### 5. 配置Unity到ios平台
![image](/images/image08.png)
### 6. 添加包名信息
![image](/images/image09.png)
### 7. 点击build导出xcode项目
![image](/images/image10.png)
### 8. 选择xcode项目生成路径
![image](/images/image11.png)
### 9. 等待build，直到提示"Build Successful"
![image](/images/image12.png)
![image](/images/image13.png)
### 10. 进入上一步生成的xocde项目根目录下，初始化pod
![image](/images/image14.png)
### 11. 初始化pod后会生成Podfile文件，在此文件下添加可玩sdk，如下：
![image](/images/image15.png)
### 12. 安装可玩sdk依赖
![image](/images/image16.png)
### 13. 双击打开.xcworkspace文件，在xcode中安装应用到iPhone
![image](/images/image17.png)
### 14. 以下是手机截图，完整流程是点击“Request”开始请求广告，广告加载完成后提示“PlayableAdsDidLoad”，此时点击“Present”展示广告，广告展示完成后，点击“X”关闭广告，此时接收到“PlayableAdsDidRewardUser”消息。
![image](/images/image18.jpg)
