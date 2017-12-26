[TOC]

### 概述
    1. 面向人人群，本产品主要面向需要在Unity产品中接入可玩广告SDK
    2. 开发环境配置
        Xcode 7.0或更高版本
        iOS 8.0或更高版本
    3. 示例所使用的环境
        mac：macOS Sierra 10.12.6
        unity: version 2017.1.1f1 Personal
        xcode: Version 9.1 (9B55)
        cocoapods: 1.2.1

### Demo简介
下载Demo源码后导入到Unity中，打开场景SampleGame.unity
**1. 主体界面及基本配制，如下所示**
![image](/images/image01.png)
**2. Main Camera的控件文件如下：**
![image](/images/image02.png)

本示例以Main Camera为广告事件接收对象，可以使用其它GameObject作为可玩广告事件接收对象，但要保证请求广告方法与事件接收所处于同一个GameObject下。

使用多个GameObject请求广告时，只以最后一个GameObject为准。

### 导入PlayableAds.unitypackage
**1. 导入可玩插件包：Assets->Import Package -> Custom Package...**
![image](/images/image03.png)
[PlayableAds.unitypackage资源位置](/PlayableAds.unitypackage)
**2. 选择下载好的PlayableAds插件包，双击打开**
![image](/images/image04.png)
**3. 导入全部文件，如果项目中有同名目录，文件会直接复制到相应文件夹下。点击import导入。**
![image](/images/image05.png)

如果出现文件名称冲突，请手动修改文件名与类名，只要确保调用时一致就可以。

**4. 在相应GameObject(如本示例中的Main Camera)下配置脚本文件**
![image](/images/image06.png)
![image](/images/image07.png)

初始化与加载广告
将iOSDemoApp与iOSDemoAdUnit替换成你在ZPLAY官网申请的应用ID和广告位ID，否则会影响收益。
```c#
PlayableAdsBridge.LoadAd(gameObject.name, "iOSDemoApp", "iOSDemoAdUnit");
```
判断广告是否已经完成加载
```c#
PlayableAdsBridge.IsReady()
```
展示广告
```c#
PlayableAdsBridge.PresentAd();
```

实现代理方法,注意，该代理方法要与广告请求时的GameObject同属一个，如本示例的GameObject均为Main Camera。
```c#
#region PlayableAds listener
// 此时，用户已经看完整个广告了，可以下发奖励
public void PlayableAdsDidRewardUser(string msg)
{
	cbInfo.text = "PlayableAdsDidRewardUser";
}

// 广告已经加载完毕，可以展示广告了
public void PlayableAdsDidLoad(string msg)
{
	cbInfo.text = "PlayableAdsDidLoad";
}

// 广告加载失败，可根据error信息查找原因
public void DidFailToLoadWithError(string error)
{
	cbInfo.text = error;
}

// 可玩SDK其它回调信息，详情查看msg
public void PlayableAdFeedBack(string msg)
{
	Debug.Log("PlayableAdFeedBack: " + msg);
}
#endregion
```
以上是配置可玩广告插件的所有步骤，配置完成后导出iOS项目，进行可玩SDK的安装

### 安装可玩SDK
**1. 进入Unity导出的xcode项目根目录下，初始化pod，如示例中的iOSProj目录：**
![image](/images/image14.png)
**2. 初始化pod后会生成Podfile文件，在此文件下添加可玩sdk，如下：**
![image](/images/image15.png)
根据项目的不同，这个文件可能有所不同，只要确保将```pod 'PlayableAds'```添加到Podfile中即可。
注意：可玩广告SDK最低支持ios8.0，

**3. 安装可玩sdk**
```
pod install --repo-update
```
![image](/images/image16.png)
看到红线圈出的部分代表可玩广告SDK安装成功，此时可以运行项目查看运行效果了，步骤如下
**4. 验证SDK是否安装成功**
双击打开.xcworkspace文件，在xcode中安装应用到iPhone
![image](/images/image17.png)
注意：此处打开的是 **.xcworkspace** 文件，而非.xcodeproj
**5. 预览demo**
完整流程是点击“Request”开始请求广告，广告加载完成后提示“PlayableAdsDidLoad”，此时点击“Present”展示广告，广告展示完成后，点击“X”关闭广告，此时接收到“PlayableAdsDidRewardUser”消息。
![image](/images/image18.jpg)
