# 2022.02.08开发日记

## 实现功能
- 导入模型、从fbx从解压纹理
- 实现cameraController，通过鼠标输入控制摄像机视角
## TODO List
- [ ] 旋转相关知识，旋转矩阵、欧拉角、四元数
> 四元数看不懂，四元数是比欧拉角还古老的概念，后来发现四元数可以解决欧拉角旋转产生的万向节问题
- [ ] Quaternion对象
- [x] 为什么需要cameraController需要挂载在camera的父节点上
> camera绕着人物移动，空节点位置和人物相同，空节点和camera之间有一定的距离，此距离就是camera旋转的半径，想象一个人拿着自拍杆转圈圈的原理，听说场景图有说这方面的知识 https://webglfundamentals.org/webgl/lessons/zh_cn/webgl-scene-graph.html
- [x] float小数点+f
> 浮点数有两种精度的，如果不指定精度的话，编译器默认会分配精度高的，以减少存放不下的情况，所以当使用浮点数但是不需要那么多位精度，且没有指定精度的时候，就加一个f标识，编译器能识别到，比如
> ```
> void test() {
>   callFunc(0.1f, 2)
> }
> 

|类型	  | 描述	范围	默认值
|  ----  | ----  |
|bool	  |布尔值	True 或 False	False
|byte	  |8 位无符号整数	0 到 255	0
|char	  |16 位 Unicode 字符	U +0000 到 U +ffff	'\0'
|decimal|	128 位精确的十进制值，28-29 有效位数	(-7.9 x 1028 到 7.9 x 1028) / 100 到 28	0.0M
|double	|64 位双精度浮点型	(+/-)5.0 x 10-324 到 (+/-)1.7 x 10308	0.0D
|float	|  32 位单精度浮点型	-3.4 x 1038 到 + 3.4 x 1038	0.0F
|int	  |  32 位有符号整数类型	-2,147,483,648 到 2,147,483,647	0
|long	  |64 位有符号整数类型	-9,223,372,036,854,775,808 到 9,223,372,036,854,775,807	0L
|sbyte	|  8 位有符号整数类型	-128 到 127	0
|short	|  16 位有符号整数类型	-32,768 到 32,767	0
|uint	  |32 位无符号整数类型	0 到 4,294,967,295	0
|ulong	|  64 位无符号整数类型	0 到 18,446,744,073,709,551,615	0
|ushort	|16 位无符号整数类型	0 到 65,535	0

- [x] 为什么使用矩阵来形容点的变换
> 我们不妨回忆一下，矩阵是怎么产生的。矩阵可以看成是一个个向量的有序组合，这说明矩阵可以类比向量；但是向量又是怎么产生的？向量则是一个个数字的有序组合，这又把我们的研究方向指向了“数字是什么”这个问题上。比如，数字1是什么？它可以代表1米，可以代表1千克，也可以代表1分钟、1摄氏度甚至1个苹果。它为什么有这么多的表示意义？答案很简单，因为在本质上，它什么都不是，它就是数字1，一个记号，一个抽象的概念。正因为它抽象，它才可以被赋予各种各样直观的意义！回到矩阵本身，我们才会明白，矩阵的作用如此之大，就是因为书本上那个很枯燥的定义——矩阵就是m行n列的一个数表！它把矩阵抽象出来，让它得到了“进化”。它是一个更一般化的概念：一个向量可以看作一个矩阵，甚至一个数都可以看成一个矩阵，等等。
> 缩放（scale）需要两个变换因素、镜像（reflection）需要两个变换因素、错切/斜切(shear mapping/skew)需要三个变换因素、旋转（rotation）需要四个变换因素，而且这些因素都和x、y相关，为了统一这个变换的数据格式，采取了矩阵这个数据形式



# 2022.02.09开发日记
## 实现功能
- 人物的基本行走（w/s/a/d控制）
- 人物行走方向随着摄像机看向角度
## TODO List
- [x] attributes使用[RequireComponent(typeof(Character))]
> 原来cocos也有这个，之前都不知道
> RequireComponent 属性自动将所需的组件添加为依赖项。
> 向 GameObject 添加使用 RequireComponent 的脚本时，会自动将需要的组件添加到 GameObject 中。 这对避免设置错误非常有用。 例如，脚本可能要求始终向同一 GameObject 添加 Rigidbody。 使用 RequireComponent 可自动完成此工作，也就不会出现设置错误。 请注意，RequireComponent 只在组件添加到 GameObject 中时检查是否缺少依赖项。GameObject 缺少新依赖项的现有组件实例将不会自动添加这些依赖项。
- [x] 人物随摄像机朝向走算法

# 2022.02.10开发日记
打球很累，偷懒了

# 2022.02.11开发日记
打球很累，偷懒了

# 2022.02.12开发日记
打球很累，偷懒了 吃饭睡觉刷抖音 两天打鱼三天晒网

# 2022.02.13开发日记
## 实现功能
- 做实验验证Translate、Rotation等的变化，等于moveBy，等于position += xxx
- 讨论了用localPosition好还是position好，localPosition是相对于父节点的位置，position是全局位置，用localPosition的话，节点层级改变后，localPosition可能会被牵扯到，也许改变，而且localPosition会被父节点的rotation影响到，而且无法直接和其他层级的节点进行计算，不过用localPosition的话可能性能更好，因为改变position到最后也是调用localPosition
- 搞清楚了人物走摄像机看向的方向怎么计算
- 用var，编译器可以自动推断类型
- GetAxis、GetAxisRaw不同

## TODO List
- [ ] unity的叉乘方向
- [ ] Vector3.ProjectOnPlane
- [ ] c# 官网看下查漏补缺 https://docs.microsoft.com/zh-cn/dotnet/csharp/tour-of-csharp/
- [ ] scene graph https://webglfundamentals.org/webgl/lessons/zh_cn/webgl-scene-graph.html
- [ ] 光怎么打都不够亮，补一下https://docs.unity3d.com/cn/2019.4/Manual/LightingOverview.html