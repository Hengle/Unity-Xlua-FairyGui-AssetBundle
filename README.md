<h2>下面说明项目从无到有的搭建过程</h2>
<h2>项目支持Unity、Xlua、FairyGui、AssetBundle打包，资源热更新，共七个方面：</h2>
   <h3><a href="#n1">1、新建Unity空项目</a></h3>
   <h3><a href="#n2">2、结合Xlua并配置</a></h3>
   <h3><a href="#n3">3、结合FairyGui并配置</a></h3>
   <h3><a href="#n4">4、AssetBundle打包</a></h3>
   <h3><a href="#n5">5、IIS服务器配置与资源下载代码</a></h3>   
   <h3><a href="#n6">6、FairyGui使用动态资源</a></h3>
   <h3><a href="#n7">7、HotFix代码更新</a></h3>

<h2 name="n1">1、新建空Unity项目</h2>
   <h3>1.1 起个项目名UnityFramework</h3>
   <img src="https://github.com/terribleness/Unity-Xlua-FairyGui-AssetBundle/blob/master/document/QQ%E6%88%AA%E5%9B%BE20181204142922.png"/>
   
<h2 name="n2">2、结合Xlua</h2>
   <h3>2.1 到 https://github.com/Tencent/xLua/releases 下载xlua发布版xlua_v2.1.12.zip，解压后看到如图：</h3>
   <img src="https://github.com/terribleness/Unity-Xlua-FairyGui-AssetBundle/blob/master/document/QQ%E6%88%AA%E5%9B%BE20181204143454.png"/>
   
   <h3>2.2 拷贝上图所有文件到UnityFramework根目录下，如图：</h3>
   <img src="https://github.com/terribleness/Unity-Xlua-FairyGui-AssetBundle/blob/master/document/QQ%E6%88%AA%E5%9B%BE20181204144058.png"/>
   
   <h3>2.3 在Unity中打开UnityFramework项目，可以看到菜单栏中有了Xlua菜单项</h3> 
   <h3>2.4 并在Assets根目录中新建Editor、Lua、Resources、Scenes、Scripts这5个空目录，之后会使用。如图：</h3>   
   <img src="https://github.com/terribleness/Unity-Xlua-FairyGui-AssetBundle/blob/master/document/QQ%E6%88%AA%E5%9B%BE20181204145630.png"/>
   
<h2 name="n3">3、结合FairyGui并配置</h2>
   <h3>3.1 到 https://github.com/fairygui/FairyGUI-unity/releases 下载FairyGui发布版FairyGUI-u2017-3_2_0.unitypackage</h3>
   <h3>3.2 然后直接拖拽FairyGUI-u2017-3_1_0.unitypackage到Unity界面的Assets目录下，会弹出导入框，点击import即可。如图：</h3>
   <img src="https://github.com/terribleness/Unity-Xlua-FairyGui-AssetBundle/blob/master/document/QQ%E6%88%AA%E5%9B%BE20181204151027.png"/>
   
   
