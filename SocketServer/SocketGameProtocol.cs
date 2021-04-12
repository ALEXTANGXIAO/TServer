// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: SocketGameProtocol.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace SocketGameProtocol {

  /// <summary>Holder for reflection information generated from SocketGameProtocol.proto</summary>
  public static partial class SocketGameProtocolReflection {

    #region Descriptor
    /// <summary>File descriptor for SocketGameProtocol.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static SocketGameProtocolReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChhTb2NrZXRHYW1lUHJvdG9jb2wucHJvdG8SElNvY2tldEdhbWVQcm90b2Nv",
            "bCLLAgoITWFpblBhY2sSNAoLcmVxdWVzdGNvZGUYASABKA4yHy5Tb2NrZXRH",
            "YW1lUHJvdG9jb2wuUmVxdWVzdENvZGUSMgoKYWN0aW9uY29kZRgCIAEoDjIe",
            "LlNvY2tldEdhbWVQcm90b2NvbC5BY3Rpb25Db2RlEjIKCnJldHVybmNvZGUY",
            "AyABKA4yHi5Tb2NrZXRHYW1lUHJvdG9jb2wuUmV0dXJuQ29kZRIwCglsb2dp",
            "blBhY2sYBCABKAsyHS5Tb2NrZXRHYW1lUHJvdG9jb2wuTG9naW5QYWNrEgsK",
            "A3N0chgFIAEoCRIuCghyb29tcGFjaxgGIAMoCzIcLlNvY2tldEdhbWVQcm90",
            "b2NvbC5Sb29tUGFjaxIyCgpwbGF5ZXJwYWNrGAcgAygLMh4uU29ja2V0R2Ft",
            "ZVByb3RvY29sLlBsYXllclBhY2siLwoJTG9naW5QYWNrEhAKCHVzZXJuYW1l",
            "GAEgASgJEhAKCHBhc3N3b3JkGAIgASgJIksKCFJvb21QYWNrEhAKCHJvb21u",
            "YW1lGAEgASgJEg4KBm1heG51bRgCIAEoBRIOCgZjdXJudW0YAyABKAUSDQoF",
            "c3RhdGUYBCABKAUiIAoKUGxheWVyUGFjaxISCgpwbGF5ZXJuYW1lGAEgASgJ",
            "KjIKC1JlcXVlc3RDb2RlEg8KC1JlcXVlc3ROb25lEAASCAoEVXNlchABEggK",
            "BFJvb20QAiqFAQoKQWN0aW9uQ29kZRIOCgpBY3Rpb25Ob25lEAASDAoIUmVn",
            "aXN0ZXIQARIJCgVMb2dpbhACEg4KCkNyZWF0ZVJvb20QAxIMCghGaW5kUm9v",
            "bRAEEg4KClBsYXllckxpc3QQBRIMCghKb2luUm9vbRAGEggKBEV4aXQQBxII",
            "CgRDaGF0EAkqQQoKUmV0dXJuQ29kZRIOCgpSZXR1cm5Ob25lEAASCwoHU3Vj",
            "Y2VzcxABEggKBEZhaWwQAhIMCghOb25lUm9vbRADYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::SocketGameProtocol.RequestCode), typeof(global::SocketGameProtocol.ActionCode), typeof(global::SocketGameProtocol.ReturnCode), }, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::SocketGameProtocol.MainPack), global::SocketGameProtocol.MainPack.Parser, new[]{ "Requestcode", "Actioncode", "Returncode", "LoginPack", "Str", "Roompack", "Playerpack" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::SocketGameProtocol.LoginPack), global::SocketGameProtocol.LoginPack.Parser, new[]{ "Username", "Password" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::SocketGameProtocol.RoomPack), global::SocketGameProtocol.RoomPack.Parser, new[]{ "Roomname", "Maxnum", "Curnum", "State" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::SocketGameProtocol.PlayerPack), global::SocketGameProtocol.PlayerPack.Parser, new[]{ "Playername" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  public enum RequestCode {
    [pbr::OriginalName("RequestNone")] RequestNone = 0,
    /// <summary>
    ///用户
    /// </summary>
    [pbr::OriginalName("User")] User = 1,
    /// <summary>
    ///房间
    /// </summary>
    [pbr::OriginalName("Room")] Room = 2,
  }

  public enum ActionCode {
    [pbr::OriginalName("ActionNone")] ActionNone = 0,
    /// <summary>
    ///注册
    /// </summary>
    [pbr::OriginalName("Register")] Register = 1,
    /// <summary>
    ///登录
    /// </summary>
    [pbr::OriginalName("Login")] Login = 2,
    /// <summary>
    ///创建房间
    /// </summary>
    [pbr::OriginalName("CreateRoom")] CreateRoom = 3,
    /// <summary>
    ///查找房间
    /// </summary>
    [pbr::OriginalName("FindRoom")] FindRoom = 4,
    /// <summary>
    ///玩家列表
    /// </summary>
    [pbr::OriginalName("PlayerList")] PlayerList = 5,
    /// <summary>
    ///加入房间
    /// </summary>
    [pbr::OriginalName("JoinRoom")] JoinRoom = 6,
    /// <summary>
    ///离开
    /// </summary>
    [pbr::OriginalName("Exit")] Exit = 7,
    /// <summary>
    ///聊天
    /// </summary>
    [pbr::OriginalName("Chat")] Chat = 9,
  }

  public enum ReturnCode {
    [pbr::OriginalName("ReturnNone")] ReturnNone = 0,
    /// <summary>
    ///成功
    /// </summary>
    [pbr::OriginalName("Success")] Success = 1,
    /// <summary>
    ///失败
    /// </summary>
    [pbr::OriginalName("Fail")] Fail = 2,
    /// <summary>
    ///没有房间
    /// </summary>
    [pbr::OriginalName("NoneRoom")] NoneRoom = 3,
  }

  #endregion

  #region Messages
  public sealed partial class MainPack : pb::IMessage<MainPack> {
    private static readonly pb::MessageParser<MainPack> _parser = new pb::MessageParser<MainPack>(() => new MainPack());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<MainPack> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SocketGameProtocol.SocketGameProtocolReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MainPack() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MainPack(MainPack other) : this() {
      requestcode_ = other.requestcode_;
      actioncode_ = other.actioncode_;
      returncode_ = other.returncode_;
      loginPack_ = other.loginPack_ != null ? other.loginPack_.Clone() : null;
      str_ = other.str_;
      roompack_ = other.roompack_.Clone();
      playerpack_ = other.playerpack_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MainPack Clone() {
      return new MainPack(this);
    }

    /// <summary>Field number for the "requestcode" field.</summary>
    public const int RequestcodeFieldNumber = 1;
    private global::SocketGameProtocol.RequestCode requestcode_ = global::SocketGameProtocol.RequestCode.RequestNone;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::SocketGameProtocol.RequestCode Requestcode {
      get { return requestcode_; }
      set {
        requestcode_ = value;
      }
    }

    /// <summary>Field number for the "actioncode" field.</summary>
    public const int ActioncodeFieldNumber = 2;
    private global::SocketGameProtocol.ActionCode actioncode_ = global::SocketGameProtocol.ActionCode.ActionNone;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::SocketGameProtocol.ActionCode Actioncode {
      get { return actioncode_; }
      set {
        actioncode_ = value;
      }
    }

    /// <summary>Field number for the "returncode" field.</summary>
    public const int ReturncodeFieldNumber = 3;
    private global::SocketGameProtocol.ReturnCode returncode_ = global::SocketGameProtocol.ReturnCode.ReturnNone;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::SocketGameProtocol.ReturnCode Returncode {
      get { return returncode_; }
      set {
        returncode_ = value;
      }
    }

    /// <summary>Field number for the "loginPack" field.</summary>
    public const int LoginPackFieldNumber = 4;
    private global::SocketGameProtocol.LoginPack loginPack_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::SocketGameProtocol.LoginPack LoginPack {
      get { return loginPack_; }
      set {
        loginPack_ = value;
      }
    }

    /// <summary>Field number for the "str" field.</summary>
    public const int StrFieldNumber = 5;
    private string str_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Str {
      get { return str_; }
      set {
        str_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "roompack" field.</summary>
    public const int RoompackFieldNumber = 6;
    private static readonly pb::FieldCodec<global::SocketGameProtocol.RoomPack> _repeated_roompack_codec
        = pb::FieldCodec.ForMessage(50, global::SocketGameProtocol.RoomPack.Parser);
    private readonly pbc::RepeatedField<global::SocketGameProtocol.RoomPack> roompack_ = new pbc::RepeatedField<global::SocketGameProtocol.RoomPack>();
    /// <summary>
    ///房间包，repeated加上为list
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::SocketGameProtocol.RoomPack> Roompack {
      get { return roompack_; }
    }

    /// <summary>Field number for the "playerpack" field.</summary>
    public const int PlayerpackFieldNumber = 7;
    private static readonly pb::FieldCodec<global::SocketGameProtocol.PlayerPack> _repeated_playerpack_codec
        = pb::FieldCodec.ForMessage(58, global::SocketGameProtocol.PlayerPack.Parser);
    private readonly pbc::RepeatedField<global::SocketGameProtocol.PlayerPack> playerpack_ = new pbc::RepeatedField<global::SocketGameProtocol.PlayerPack>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::SocketGameProtocol.PlayerPack> Playerpack {
      get { return playerpack_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as MainPack);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(MainPack other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Requestcode != other.Requestcode) return false;
      if (Actioncode != other.Actioncode) return false;
      if (Returncode != other.Returncode) return false;
      if (!object.Equals(LoginPack, other.LoginPack)) return false;
      if (Str != other.Str) return false;
      if(!roompack_.Equals(other.roompack_)) return false;
      if(!playerpack_.Equals(other.playerpack_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Requestcode != global::SocketGameProtocol.RequestCode.RequestNone) hash ^= Requestcode.GetHashCode();
      if (Actioncode != global::SocketGameProtocol.ActionCode.ActionNone) hash ^= Actioncode.GetHashCode();
      if (Returncode != global::SocketGameProtocol.ReturnCode.ReturnNone) hash ^= Returncode.GetHashCode();
      if (loginPack_ != null) hash ^= LoginPack.GetHashCode();
      if (Str.Length != 0) hash ^= Str.GetHashCode();
      hash ^= roompack_.GetHashCode();
      hash ^= playerpack_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Requestcode != global::SocketGameProtocol.RequestCode.RequestNone) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Requestcode);
      }
      if (Actioncode != global::SocketGameProtocol.ActionCode.ActionNone) {
        output.WriteRawTag(16);
        output.WriteEnum((int) Actioncode);
      }
      if (Returncode != global::SocketGameProtocol.ReturnCode.ReturnNone) {
        output.WriteRawTag(24);
        output.WriteEnum((int) Returncode);
      }
      if (loginPack_ != null) {
        output.WriteRawTag(34);
        output.WriteMessage(LoginPack);
      }
      if (Str.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(Str);
      }
      roompack_.WriteTo(output, _repeated_roompack_codec);
      playerpack_.WriteTo(output, _repeated_playerpack_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Requestcode != global::SocketGameProtocol.RequestCode.RequestNone) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Requestcode);
      }
      if (Actioncode != global::SocketGameProtocol.ActionCode.ActionNone) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Actioncode);
      }
      if (Returncode != global::SocketGameProtocol.ReturnCode.ReturnNone) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Returncode);
      }
      if (loginPack_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(LoginPack);
      }
      if (Str.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Str);
      }
      size += roompack_.CalculateSize(_repeated_roompack_codec);
      size += playerpack_.CalculateSize(_repeated_playerpack_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(MainPack other) {
      if (other == null) {
        return;
      }
      if (other.Requestcode != global::SocketGameProtocol.RequestCode.RequestNone) {
        Requestcode = other.Requestcode;
      }
      if (other.Actioncode != global::SocketGameProtocol.ActionCode.ActionNone) {
        Actioncode = other.Actioncode;
      }
      if (other.Returncode != global::SocketGameProtocol.ReturnCode.ReturnNone) {
        Returncode = other.Returncode;
      }
      if (other.loginPack_ != null) {
        if (loginPack_ == null) {
          LoginPack = new global::SocketGameProtocol.LoginPack();
        }
        LoginPack.MergeFrom(other.LoginPack);
      }
      if (other.Str.Length != 0) {
        Str = other.Str;
      }
      roompack_.Add(other.roompack_);
      playerpack_.Add(other.playerpack_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Requestcode = (global::SocketGameProtocol.RequestCode) input.ReadEnum();
            break;
          }
          case 16: {
            Actioncode = (global::SocketGameProtocol.ActionCode) input.ReadEnum();
            break;
          }
          case 24: {
            Returncode = (global::SocketGameProtocol.ReturnCode) input.ReadEnum();
            break;
          }
          case 34: {
            if (loginPack_ == null) {
              LoginPack = new global::SocketGameProtocol.LoginPack();
            }
            input.ReadMessage(LoginPack);
            break;
          }
          case 42: {
            Str = input.ReadString();
            break;
          }
          case 50: {
            roompack_.AddEntriesFrom(input, _repeated_roompack_codec);
            break;
          }
          case 58: {
            playerpack_.AddEntriesFrom(input, _repeated_playerpack_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class LoginPack : pb::IMessage<LoginPack> {
    private static readonly pb::MessageParser<LoginPack> _parser = new pb::MessageParser<LoginPack>(() => new LoginPack());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<LoginPack> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SocketGameProtocol.SocketGameProtocolReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoginPack() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoginPack(LoginPack other) : this() {
      username_ = other.username_;
      password_ = other.password_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LoginPack Clone() {
      return new LoginPack(this);
    }

    /// <summary>Field number for the "username" field.</summary>
    public const int UsernameFieldNumber = 1;
    private string username_ = "";
    /// <summary>
    ///用户名
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Username {
      get { return username_; }
      set {
        username_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "password" field.</summary>
    public const int PasswordFieldNumber = 2;
    private string password_ = "";
    /// <summary>
    ///密码
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Password {
      get { return password_; }
      set {
        password_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as LoginPack);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(LoginPack other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Username != other.Username) return false;
      if (Password != other.Password) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Username.Length != 0) hash ^= Username.GetHashCode();
      if (Password.Length != 0) hash ^= Password.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Username.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Username);
      }
      if (Password.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Password);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Username.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Username);
      }
      if (Password.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Password);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(LoginPack other) {
      if (other == null) {
        return;
      }
      if (other.Username.Length != 0) {
        Username = other.Username;
      }
      if (other.Password.Length != 0) {
        Password = other.Password;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Username = input.ReadString();
            break;
          }
          case 18: {
            Password = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class RoomPack : pb::IMessage<RoomPack> {
    private static readonly pb::MessageParser<RoomPack> _parser = new pb::MessageParser<RoomPack>(() => new RoomPack());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<RoomPack> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SocketGameProtocol.SocketGameProtocolReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RoomPack() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RoomPack(RoomPack other) : this() {
      roomname_ = other.roomname_;
      maxnum_ = other.maxnum_;
      curnum_ = other.curnum_;
      state_ = other.state_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RoomPack Clone() {
      return new RoomPack(this);
    }

    /// <summary>Field number for the "roomname" field.</summary>
    public const int RoomnameFieldNumber = 1;
    private string roomname_ = "";
    /// <summary>
    ///房间名
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Roomname {
      get { return roomname_; }
      set {
        roomname_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "maxnum" field.</summary>
    public const int MaxnumFieldNumber = 2;
    private int maxnum_;
    /// <summary>
    ///房间最大人数
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Maxnum {
      get { return maxnum_; }
      set {
        maxnum_ = value;
      }
    }

    /// <summary>Field number for the "curnum" field.</summary>
    public const int CurnumFieldNumber = 3;
    private int curnum_;
    /// <summary>
    ///房间当前人数
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Curnum {
      get { return curnum_; }
      set {
        curnum_ = value;
      }
    }

    /// <summary>Field number for the "state" field.</summary>
    public const int StateFieldNumber = 4;
    private int state_;
    /// <summary>
    ///房间状态
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int State {
      get { return state_; }
      set {
        state_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as RoomPack);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(RoomPack other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Roomname != other.Roomname) return false;
      if (Maxnum != other.Maxnum) return false;
      if (Curnum != other.Curnum) return false;
      if (State != other.State) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Roomname.Length != 0) hash ^= Roomname.GetHashCode();
      if (Maxnum != 0) hash ^= Maxnum.GetHashCode();
      if (Curnum != 0) hash ^= Curnum.GetHashCode();
      if (State != 0) hash ^= State.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Roomname.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Roomname);
      }
      if (Maxnum != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Maxnum);
      }
      if (Curnum != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(Curnum);
      }
      if (State != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(State);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Roomname.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Roomname);
      }
      if (Maxnum != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Maxnum);
      }
      if (Curnum != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Curnum);
      }
      if (State != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(State);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(RoomPack other) {
      if (other == null) {
        return;
      }
      if (other.Roomname.Length != 0) {
        Roomname = other.Roomname;
      }
      if (other.Maxnum != 0) {
        Maxnum = other.Maxnum;
      }
      if (other.Curnum != 0) {
        Curnum = other.Curnum;
      }
      if (other.State != 0) {
        State = other.State;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Roomname = input.ReadString();
            break;
          }
          case 16: {
            Maxnum = input.ReadInt32();
            break;
          }
          case 24: {
            Curnum = input.ReadInt32();
            break;
          }
          case 32: {
            State = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  public sealed partial class PlayerPack : pb::IMessage<PlayerPack> {
    private static readonly pb::MessageParser<PlayerPack> _parser = new pb::MessageParser<PlayerPack>(() => new PlayerPack());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<PlayerPack> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SocketGameProtocol.SocketGameProtocolReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PlayerPack() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PlayerPack(PlayerPack other) : this() {
      playername_ = other.playername_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PlayerPack Clone() {
      return new PlayerPack(this);
    }

    /// <summary>Field number for the "playername" field.</summary>
    public const int PlayernameFieldNumber = 1;
    private string playername_ = "";
    /// <summary>
    ///玩家名称
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Playername {
      get { return playername_; }
      set {
        playername_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as PlayerPack);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(PlayerPack other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Playername != other.Playername) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Playername.Length != 0) hash ^= Playername.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Playername.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Playername);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Playername.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Playername);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(PlayerPack other) {
      if (other == null) {
        return;
      }
      if (other.Playername.Length != 0) {
        Playername = other.Playername;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Playername = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code