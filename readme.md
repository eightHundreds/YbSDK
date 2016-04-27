[TOC]

#前言
该SDK要求.Net 4.0以上
依赖第三方库:RestSharp, Version=105.2.3.0
IIS要求多少?我也不知道,有装.Net 4.0的应该都能用



#配置

先在app.config和web.config中的`configuration`节点中添加section如下

```
<configuration>
  <configSections>
    <sectionGroup name="YbApp">
      <section name="YbWebConnect" type="System.Configuration.NameValueSectionHandler,System, Version=4.0.0.0, Culture=neutral,PublicKeyToken=b77a5c561934e089"/>
      <section name="YbLight" type="System.Configuration.NameValueSectionHandler,System, Version=4.0.0.0, Culture=neutral,PublicKeyToken=b77a5c561934e089"/>
      <section name="YbInSite" type="System.Configuration.NameValueSectionHandler,System, Version=4.0.0.0, Culture=neutral,PublicKeyToken=b77a5c561934e089"/>
    </sectionGroup>
  </configSections>

  <YbApp>
    <YbWebConnect>
      <add key="AppId" value=""/>
      <add key="Callback" value=""/>
      <add key="Type" value="web"/>
      <add key="AppSecret" value=""/>
    </YbWebConnect>
    <YbLight>
      <add key="AppId" value=""/>
      <add key="Callback" value=""/>
      <add key="AppSecret" value=""/>
    </YbLight>
    <YbInSite>
      <add key="AppId" value=""/>
      <add key="AppSecret" value=""/>
    </YbInSite>
  </YbApp>
</configuration>
```
易班应用分为3中,网站接入,站内应用,轻应用.
有时候会出现这种情况:同一个网站在易班开放平台申请多种模式的应用,比如我想要我的网站能在易班app客户端使用,也可以在浏览器中进行第三方登入,我就可以申请我的应用为网站接入和轻应用


从配置中可以看出,该SDK可以配置多种模式的易班应用


#易班API

本SDK实现了下列接口
- 授权接口
- 用户接口
- 好友分组接口
- 消息接口
- 分享评论接口
- 网薪支付接口
- 校级接口
- 群话题接口

分别对应于YbSDK.Api下的

- OauthApi
- UserApi
- FriendApi
- MsgApi
- ShareApi
- PayApi
- SchoolApi
- GroupApi


可以直接实例化出这些类使用,但我也封装了个`YbClient`,YbClient包含了这些api成员,可只用YbClient实现所有功能



在YbClient中封装了各个Api,除了OauthApi
```
public class YbClient
{
   

    #region Apis
    public ShareApi share { get; set; }
    public FriendApi friend { get; set; }
    public GroupApi group { get; set; }
    public MsgApi msg { get; set; }
    public PayApi pay { get; set; }
    public SchoolApi school { get; set; }
    public UserApi user { get; set; }

    #endregion

```


各个api调用后的返回结果都与<font color='red' >**官方文档一摸一样**</font>



#接入网站授权案例


```

//假设在点击页面某个链接后跳转到这个方法中
protected void Page_Load(object sender, EventArgs e)
{
   //生成一个随机字符串
   string state = Guid.NewGuid().ToString().Replace("-", "");
   //保存到Session
   context.Session["state"]
   
   //创建网站接入配置对象
   YbConfig ybConfig = new YbConfig(ConfigType.YbWebConnect);
   //实例化授权接口
   OauthApi ybOauth = new OauthApi(ybConfig);
   
   //生成易班授权页面链接
   string url = ybOauth.GetAuthorizeUrl(state);
   //跳转
   Response.Redirect(url);
}

//当用户授权后跳转到这个页面
protected void Page_Load(object sender, EventArgs e)
{
   string code = Request["code"];
   string state = Request["state"];
   
   YbConfig ybConfig = new YbConfig(ConfigType.YbWebConnect);
   OauthApi ybOauth = new OauthApi(ybConfig);
   
   if(state==context.Session["state"].ToString())
   {
     var accessToken=ybOauth.GetAccessToken(code);
     //使用获得的accessToken实例化YbClient,同时也要传入易班配置
     YbClient client=new YbClient(accessToken,ybConfig);
     //实例化后就直接api成员使用了
     UserMe me = client.user.GetMe();
   } 
}

//调用返回的类型成员与官网api文档一摸一样
public class AccessToken
{
  /// <summary>
  /// 授权凭证
  /// </summary>
  public string access_token { get; set; }
  /// <summary>
  /// 授权用户id
  /// </summary>
  public int userid { get; set; }
  /// <summary>
  /// 截止有效期
  /// </summary>
  public int expires { get; set; }
}
```


#轻应用,站内应用授权案例

```

//假设打开易班轻/站内应用会自动跳转页面并执行这个方法
protected void Page_Load(object sender, EventArgs e)
{
  //获取加密的授权校验码
  string verify = Request["verify_request"];
  
  YbConfig ybConfig =new YbConfig(ConfigType.YbLight);
  OauthApi ybOauth = new OauthApi(ybConfig);
  VisitOauth oauth=ybOauth.CheckAuthor(verify);
  
  if(oauth.IsAuthorized==true){
     //该用户以授权该应用
     //do someting
  }
}

```

上面提到api返回结果与官方文档一摸一样,但唯有VisitOauth比官方文档多了一个IsAuthorized.用于判断该用户是授权给该应用



#项目目录结构

```
YbSDK
|- Api  各类api
   |- BaseApi    api基类
   |- OauthApi   授权
   |- FriendApi  好友分组
   |- GroupApi   群话题
   |- MsgApi     消息
   |- PayApi     网薪支付
   |- SchoolApi  校级
   |- ShareApi   分享
   |- UserApi    用户
   |- ApiContext 上下文,内有一些配置信息和AccessToken
   
|- Exceptions
   |-YbException 易班异常类
   
|- Model  模型类,用来装返回数据的,一个cs文件可能有多个类
   |- ErrorModels.cs    错误信息
   |- FriendModels.cs   好友
   |- GroupModels.cs    群话题
   |- OAuthModels.cs    授权
   |- SchoolModels.cs   校级
   |- ShareModels.cs    分享
   |- UserModel.cs      用户

|- Config
   |- YbConfig 易班配置类,会自动从配置文件中读取相关配置
 
|- YbClient 封装各个api,方便使用


```

#关于代码


`易班不知如何称呼的开发者`建议要添加`关键位置行间注释`
此SDK跟本没有复杂的设计,所以基本上看懂一个api的方法就能看懂全部的方法
下面就拿一个最复杂的方法举例.该方法是GroupApi中的GetGroupMembers
```
/// <summary>
/// 获取指定机构群/公共群成员列表
/// </summary>
/// <param name="groupId">群ID</param>
/// <param name="page">页码（默认1）</param>
/// <param name="count">每页数据量（默认15，最大30）</param>
/// <returns></returns>
public GroupMembers GetGroupMembers(int groupId, int page = 1, int count = 15)
{
    //很多的方法都有设置默认参数,默认值为官方api文档所设定
    
    //对参数的检测
    if (count > 30)
    {
        throw new YbException("每页数据量不可超过30");
    }
    
    //创建请求对象,CreateRequest方法在BaseApi类中实现
    var request = CreateRequest(RestSharp.Method.GET, "group/group_member");
    
    //设置请求参数,access_token等数据在api初始化的时候保存到context中,context也是在BaseApi中
    request.AddParameter("access_token", context.Token.access_token, RestSharp.ParameterType.QueryString);
    request.AddParameter("group_id", groupId, RestSharp.ParameterType.QueryString);
    request.AddParameter("page", page, RestSharp.ParameterType.QueryString);
    request.AddParameter("count", count, RestSharp.ParameterType.QueryString);

    //获得响应对象
    var response = restClient.Execute(request);

    //检测该响应结果中是存在"status":"error"  这个字符串,如果有则说明获取数据失败,抛异常
    if (CheckError(response))
    {
        throw GenerateError(response);
    }

    //下面的结构不是每个方法都会出现的,仅当返回json为特殊结构时候(见注1,一定要看!)才会写下面这段
    GroupMembers result = null;
    try
    {
        //尝试反序列化json字符串
        result = Deserialize<GroupMembers>(response.Content);
    }
    catch (System.InvalidOperationException)
    {
        //如果抛出InvalidOperationException异常说明返回数据的info是空的
        result = new GroupMembers()
        {
            status = "success",
            info = new GroupMembers.Info()
        };
        return result;
    }
    return result;
}

```

**注1**

``` JSON
{
  "status":"success",
  "info":{
    "list":[
      {
        "member_uid":"群成员用户ID",
        "member_nick":"群成员用户昵称",
        "member_head":"群成员用户头像",
        "member_remark":"当前用户附加的好友备注"
      },
      ......
    ]
  }
}
```
group/group_member接口返回的是上面这种json,当list为空的时候返回的是
``` JSON
{
  "status":"success",
  "info":{
  }
}
```
所以这种格式的JSON字符串反序列它会抛出InvalidOperationException



#后记

本SDK由 中国矿业大学<font color='#5BCE33'>学生在线</font>后端组八百 设计开发.
哪里用的不舒服欢迎来校门口堵我.

[学生在线](http://online.cumt.edu.cn)
![Alt text](http://online.cumt.edu.cn/flyingstudio2014/Content/images/logo.png)
在线为学生




