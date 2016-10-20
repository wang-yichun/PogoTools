# PogoTools
为 Unity 制造的小工具,便于提高开发效率  
Designed by Ethan

## 功能
- 转换 UnityEngine.Color 到 #ffffff(string) 的色彩表示;
- 具有可定位调用位置的彩色带标签 Debug 信息;

## 使用方法
- 将本工程作为子工程放置在 主工程根目录/Submodules 目录下;
  - 1.使用 xamarin 进行打包 dll:
    - 使用 xamarin 打开 sln;
    - 选择 Release 模式;
    - Build;
  - 2.使用嵌入Unity的功能进行打包:
    - 将本工程VariousAssets目录下的文件拷贝到主工程 Assets/VariousAssets 目录下;
    - 打开 Unity, 会出现 PogoRock 菜单;
    - 点击 RogoRock/Rebuild PogoTools, 就会开始打包;
    - 打包生成的 PogoTools.dll 文件位于 Assets/VariousAssets/PogoRock/PogoTools/PogoTools.dll
- 使用功能时,请加入名字空间PogoTools;

## 常用功能
- PRDebug.Log();
- PRDebug.LogTag();
- ...
