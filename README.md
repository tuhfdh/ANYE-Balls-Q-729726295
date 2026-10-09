# ANYE Balls · 暗夜二改本子

> **《球球大作战》**桌面辅助工具 · 当前版本 **6.0.5**

交流 / 反馈 / 更新：**Q 群 729726295**（感谢各位群友一直以来的赞助）

---

## 目录

- [项目简介](#项目简介)
- [功能一览](#功能一览)
- [环境要求](#环境要求)
- [编译与运行](#编译与运行)
- [使用流程](#使用流程)
- [项目结构](#项目结构)
- [第三方依赖](#第三方依赖)
- [常见问题](#常见问题)
- [免责声明](#免责声明)

---

## 项目简介

ANYE Balls 是一个基于 **.NET 6 WinForms** 的桌面端辅助工具。它运行在 Windows 上，通过两条通道与游戏交互：

| 通道 | 实现方式 | 用途 |
| --- | --- | --- |
| **ADB 通道** | `sharpadbclient` + `Resources/adb.exe` | 连接雷电模拟器，向游戏目录推送 / 删除资源文件（皮肤、活动贴图等） |
| **内存通道** | `kernel32` 的 `OpenProcess` / `ReadProcessMemory` / `WriteProcessMemory` | 定位模拟器进程，按特征码搜索并改写游戏内存数据 |

界面层使用 AntdUI / SunnyUI / ReaLTaiizor 三套 UI 库混搭，输入模拟与悬浮绘制走 `user32` 的原生接口（`mouse_event`、`keybd_event`、分层透明窗口）。

> **关于编码**：`.cs` 源文件为 **GBK / GB2312** 编码，用 VS Code 等编辑器打开时请手动切换编码，否则中文注释会显示为乱码。

---

## 功能一览

功能按主界面左侧树形菜单组织：

### 基本功能
- 选择当前模拟器进程、首次初始化_游戏大厅、二次初始化数据
- **吐球键 / 分身键** 自定义
- **遥杆大小** 调节（默认 `1.60`）
- **合球初始化**、合球全局延迟（技战室延迟[稳定] 等预设）
- 初始化视野/内存、初始化摇杆/分身

### 内存功能
由 `MainForm` 顶部的特征码数组（`quanjuaob`、`biansuaob`、`nianheaob`、`tuqiuaob`、`yaoganyanchiaob` …）驱动，包含：

| 功能 | 说明 |
| --- | --- |
| 内存三角-模式1 / 模式2 | 两种三角合球方案 |
| 内存四分侧合 | 四分身侧向合球 |
| 内存中分侧合 | 中央分身侧向合球 |
| 内存后仰侧合 | 后仰姿态侧合 |
| 内存半旋 / 内存旋转 | 旋转类合球 |
| 内存蛇手 | 蛇形走位 |
| 内存合球 | 通用自动合球 |
| 全局 / 粘合 / 遥杆 / 变速 / 回弹 | 各维度参数微调 |

### 辅助功能
- **宏功能** — 键位宏录制与回放
- **黑屏图色 / 黑屏绘制** — 分层透明窗口悬浮绘制
- **卡点功能** — 定点卡位
- **皮肤功能** — 通过 ADB 替换游戏内贴图资源（`com.ztgame.bob` 资源目录）
- **其他功能** — 杂项开关

### 其他
- 配置 **导入 / 导出**
- 运行日志面板
- **热更新**：检测到新版本时自动下载，旧版本保留，新版本放入桌面 `ANYE Balls` 文件夹
- **QQ 群验证登录**：内置浏览器跳转加群验证

---

## 环境要求

| 项目 | 要求 |
| --- | --- |
| 操作系统 | Windows 10 / 11 x64 |
| 运行时 | .NET 6 Desktop Runtime（`net6.0-windows`） |
| 开发环境 | Visual Studio 2022（含 .NET 桌面开发工作负载）或 .NET 6 SDK |
| 模拟器 | ADB 端口通常为 `127.0.0.1:16384` / `127.0.0.1:5555` / `emulator-5554` |
| 游戏 | 《球球大作战》（包名 `com.ztgame.bob`） |
| 权限 | **必须以管理员身份运行**（读写模拟器进程内存） |
| 其他 | `Resources/adb.exe` 已随仓库附带，无需单独安装 adb |

---

## 编译与运行

### 1. 克隆仓库

```bash
git clone https://github.com/tuhfdh/ANYE-Balls-Q-729726295.git
cd ANYE-Balls-Q-729726295
```

### 2. 编译

用 Visual Studio 2022 打开 `ANYE Balls.sln`，还原 NuGet 包后生成；或使用命令行：

```bash
dotnet restore
dotnet build -c Release
```

> ⚠️ 仓库通过 `.gitignore` 排除了 `bin/`、`obj/`、`.vs/`，克隆后需要自行还原与编译。

### 3. 运行

以**管理员身份**启动生成的 `ANYE Balls.exe`。

---

## 使用流程

界面上的初始化顺序有依赖关系，建议按下列步骤操作：

1. 在雷电模拟器中启动《球球大作战》并**进入游戏大厅**
2. 点击 **选择当前模拟器进程**，选中 `LdVBoxHeadless`
3. 点击 **首次初始化_游戏大厅**（首次使用必须执行）
4. 点击 **二次初始化数据**，或按需点击 **初始化视野/内存** 与 **初始化摇杆/分身**
5. 按需点击 **合球初始化**，再在左侧树形菜单中开启对应功能
6. 调节 **吐球键 / 分身键 / 遥杆大小 / 合球全局延迟** 等参数，满意后点 **导出配置** 保存

皮肤类功能会调用 `Resources` 下的 `.bat` 脚本，通过 adb 向模拟器推送资源文件：

- `dhlqcq.bat` / `dhlqcq1.bat` — 推送活动与特效贴图（`adb push`）
- `hycq.bat` — 还原 / 删除对应贴图（`adb shell rm`）
- `activityconfig.bat` / `shopconfig.bat` — 修改游戏内配置文件的权限

> 脚本中的设备序列号（`127.0.0.1:16384`、`127.0.0.1:5555`、`emulator-5554`）覆盖了雷电多开常见端口，若你的模拟器端口不同，请自行修改。

---

## 项目结构

```
ANYE Balls 729726295/
├── ANYE Balls.sln              解决方案
├── ANYE Balls.csproj           项目文件（net6.0-windows，WinExe）
├── app.manifest                应用清单（DPI / 权限声明）
├── Gemini.ico                  程序图标
│
├── Program.cs                  入口点
├── MainForm.cs                 主窗体：特征码定义、初始化、热更新（约 155 KB）
├── API.cs                      Win32 / user32 / kernel32 P/Invoke 声明集合
├── Memory.cs                   进程内存读写封装
├── Struct.cs                   结构体与枚举（POINT / RECT / 访问权限等）
├── Json.cs                     JSON 读写辅助
│
├── fuzhugongneng.cs            辅助功能模块
├── honggongneng.cs             宏功能
├── heipinghuizhi.cs            黑屏绘制
├── heipinghuizhi2.cs           黑屏绘制（第二套）
├── heipingkadian.cs            黑屏卡点
├── neicungongneng.cs           内存功能总面板
├── neicunheqiu.cs              内存合球
├── ncbanxuan.cs                半旋
├── ncxuanzhuan.cs              旋转
├── ncsheshou.cs                蛇手
├── ncsanjiao1.cs / ncsanjiao2.cs   三角-模式1 / 模式2
├── ncsifencehe.cs              四分侧合
├── nczhongfencehe.cs           中分侧合
├── nchouyangcehe.cs            后仰侧合
├── pifugongneng.cs             皮肤功能
├── QQVerificationLogin.cs      QQ 群验证登录
│
├── Properties/                 程序集属性与资源
└── Resources/                  adb.exe、贴图资源、功能脚本（.bat）
```

---

## 第三方依赖

| 包 | 版本 | 用途 |
| --- | --- | --- |
| [AntdUI](https://www.nuget.org/packages/AntdUI) | 1.3.0 | 主界面组件 |
| [SunnyUI](https://www.nuget.org/packages/SunnyUI) | 3.6.6 | 界面组件 |
| [ReaLTaiizor](https://www.nuget.org/packages/ReaLTaiizor) | 3.8.0.5 | 窗口边框 / 主题 |
| [sharpadbclient](https://www.nuget.org/packages/sharpadbclient) | 2.3.23 | ADB 客户端 |
| [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json) | 13.0.3 | 配置读写 |

---

## 常见问题

**Q：提示找不到模拟器进程？**
MuMu12 模拟器可能不适配（尤其是安卓 15 内核的模拟器）；另外本程序**必须以管理员身份运行**——权限不足时无法枚举 / 打开模拟器进程。

**Q：初始化失败或功能开启后没反应？**
内存功能依赖 `MainForm.cs` 顶部的**特征码**。游戏每次大版本更新都可能改变内存布局，届时特征码会失效，需要重新搜索并更新特征码数组。

**Q：新版本怎么更新？**
程序内置热更新：检测到新版本会自动下载，**旧版本保留**，新版本会放到桌面 `ANYE Balls` 文件夹中。修改版本号请改 `MainForm.cs` 里的 `CurrentAppVersion`。

**Q：皮肤功能推送失败？**
先确认 `adb devices` 能列出你的模拟器；再检查 `Resources/*.bat` 里的设备序列号是否与你的模拟器一致（雷电多开时端口会变化）。

**Q：源码中文注释是乱码？**
`.cs` 文件为 GBK 编码，请在编辑器中切换编码为 GB2312 / GBK。

---

## 免责声明

- 本项目**仅供编程学习与技术交流**使用，请于下载后 24 小时内自行删除，**请勿用于任何商业用途**。
- 本项目会读写第三方进程内存并修改游戏客户端资源文件，**这可能违反游戏的用户协议**，并可能导致**账号被永久封禁**，由此产生的一切后果由使用者自行承担。
- 使用本工具即表示你已了解并接受上述风险；作者不对任何账号损失、数据损坏或法律纠纷负责。
- 若本项目无意中侵犯了任何权利人的权益，请联系 Q 群 **729726295**，将及时处理。
