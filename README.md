# Rokid AR TRPG Master

A Unity-based AR tabletop RPG prototype for Rokid glasses, featuring plane-based object placement, hand interactions, and virtual dice rolling.

基于 **Unity** 和 **Rokid UXR SDK** 的增强现实桌面角色扮演游戏（TRPG）原型，探索在 AR 眼镜中放置虚拟场景、操作物体和进行掷骰的交互方式。

> 项目目前处于原型阶段，主要包含基础交互脚本、演示场景和 SDK 示例。

## 功能

- **平面识别与模型放置**：通过 Rokid 平面追踪与射线交互，在识别到的平面上放置模型，并提供放置确认流程。
- **虚拟物体交互**：包含物体悬停高亮、抓取、跟随手部移动和释放的交互脚本。
- **交互生成物体**：通过射线悬停或点击 UI，在预设位置生成物体。
- **虚拟掷骰**：通过下拉菜单选择骰子类型，随机生成结果并显示，支持 `d3`、`d4`、`d6`、`d10`、`d12` 和 `d20`。

## 技术栈

| 技术 | 版本 |
| --- | --- |
| Unity Editor | 2022.3.55f1c1 |
| Rokid UXR SDK | 3.0.3 |
| Unity OpenXR Plugin | 1.13.2 |
| TextMesh Pro | 3.0.7 |
| 开发语言 | C# |

## 项目结构

```text
Rokid-AR-TRPG-Master/
└── Test/                          # Unity 项目根目录
    ├── Assets/
    │   ├── Scenes/
    │   │   ├── DemoSpatial6DoF.unity
    │   │   └── Dice.unity
    │   ├── Scripts/
    │   │   ├── ConfirmButton.cs
    │   │   ├── CubeInteraction.cs
    │   │   ├── DiceRoller.cs
    │   │   ├── DragRotateController.cs
    │   │   ├── FPS.cs
    │   │   ├── PlacementEvent.cs
    │   │   ├── PlaneTracking.cs
    │   │   └── RKPlaneLogicController.cs
    │   └── Samples/               # SDK 与其他依赖的示例资源
    ├── Packages/                  # 依赖与包管理配置
    └── ProjectSettings/           # Unity 项目设置
```

## 快速开始

### 1. 获取项目

```bash
git clone https://github.com/hxs898570462/Rokid-AR-TRPG-Master.git
```

### 2. 打开 Unity 项目

在 Unity Hub 中选择 **Add project from disk**，添加仓库中的 `Test` 文件夹。

使用 **Unity 2022.3.55f1c1** 打开项目，等待资源导入和依赖解析完成。

项目已在 `Packages/manifest.json` 中配置 Rokid 包源：

```text
https://npm.rokid.com
```

### 3. 查看演示场景

在 `Assets/Scenes/` 中打开：

- `DemoSpatial6DoF.unity`
- `Dice.unity`

结合 `Assets/Scripts/` 中的脚本检查场景对象、UI 和预制体的引用配置。

涉及平面追踪、手部交互等功能时，需要在兼容的 Rokid 设备及相应运行环境中验证。

## 主要脚本

| 脚本 | 作用 |
| --- | --- |
| `RKPlaneLogicController.cs` | 管理平面追踪、射线选点、模型放置和确认按钮创建 |
| `PlacementEvent.cs` | 处理射线悬停或点击事件，并生成预设物体 |
| `CubeInteraction.cs` | 处理物体高亮、抓取、移动跟随和释放 |
| `DiceRoller.cs` | 管理骰子类型选择、随机掷骰和结果显示 |

## 当前范围

当前实现主要用于验证 AR TRPG 的基础交互。完整的 TRPG 规则、角色与战役管理、多人同步和 AI 主持人功能尚未包含在已检查的自定义脚本中。
