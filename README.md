### PlayableAdsSDK for Unity
  1. 概述
  1. 模拟待接入广告的游戏
  2. 导入PlayableAds.unitypackage
  1. 开发环境配置
  1. 接入PlayableAds SDK
  1. 代码集成示例

## 概述
    1. 面向人人群，本产品主要面向需要在Unity产品中接入可玩广告SDK
    2. 开发环境配置
        Xcode 7.0或更高版本
        iOS 8.0或更高版本
    3. 示例所使用的环境
        mac：macOS Sierra 10.12.6
        unity: version 2017.1.1f1 Personal
        xcode: Version 9.1 (9B55)
        cocoapods: 1.2.1

## 模拟待接入广告的游戏
### 1. 主体界面如下及基本配制
![image](/images/image01.png)
### 2. Main Camera的控件文件如下：
![image](/images/image02.png)

## 导入PlayableAds.unitypackage
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

## 接入PlayableAds SDK
### 1. 进入上一步生成的xcodde项目根目录下，初始化pod
![image](/images/image14.png)
### 2. 初始化pod后会生成Podfile文件，在此文件下添加可玩sdk，如下：
![image](/images/image15.png)
### 3. 安装可玩sdk依赖
```
pod install --repo-update
```
![image](/images/image16.png)
### 4. 双击打开.xcworkspace文件，在xcode中安装应用 到iPhone
![image](/images/image17.png)
### 5. 以下是手机截图，完整流程是点击“Request”开始请求广告，广告加载完成后提示“PlayableAdsDidLoad”，此时点击“Present”展示广告，广告展示完成后，点击“X”关闭广告，此时接收到“PlayableAdsDidRewardUser”消息。
![image](/images/image18.jpg)

## 代码集成示例

### 初始化与加载广告
将iOSDemoApp与iOSDemoAdUnit替换成你在ZPLAY官网申请的应用ID和广告位ID，否则会影响收益。
```
PlayableAdsBridge.LoadAd(gameObject.name, "iOSDemoApp", "iOSDemoAdUnit");
```

### 判断广告是否已经完成加载
```
PlayableAdsBridge.IsReady()
```

### 展示广告
```
PlayableAdsBridge.PresentAd();
```

### 实现代理方法
注意，该代理方法要与广告请求时的GameObject同属一个。
```
#region PlayableAds listener
// 此时，用户已经看完整个广告了，可以下发奖励
public void PlayableAdsDidRewardUser(string msg)
{
	cbInfo.text = "PlayableAdsDidRewardUser";
}

// 广告已经加载完毕，可以展示广告了
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

