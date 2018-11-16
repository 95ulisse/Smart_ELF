//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class Value : Portable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal Value(global::System.IntPtr cPtr, bool cMemoryOwn) : base(yarpPINVOKE.Value_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Value obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~Value() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          yarpPINVOKE.delete_Value(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public new bool check(string key, string comment) {
    bool ret = yarpPINVOKE.Value_check__SWIG_0_0(swigCPtr, key, comment);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public new Value check(string key, Value fallback, string comment) {
    Value ret = new Value(yarpPINVOKE.Value_check__SWIG_0_1(swigCPtr, key, Value.getCPtr(fallback), comment), true);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public new Value check(string key, Value fallback) {
    Value ret = new Value(yarpPINVOKE.Value_check__SWIG_0_2(swigCPtr, key, Value.getCPtr(fallback)), true);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public new Bottle findGroup(string key, string comment) {
    Bottle ret = new Bottle(yarpPINVOKE.Value_findGroup__SWIG_0_0(swigCPtr, key, comment), false);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public Value() : this(yarpPINVOKE.new_Value__SWIG_0(), true) {
  }

  public Value(int x, bool isVocab) : this(yarpPINVOKE.new_Value__SWIG_1(x, isVocab), true) {
  }

  public Value(int x) : this(yarpPINVOKE.new_Value__SWIG_2(x), true) {
  }

  public Value(double x) : this(yarpPINVOKE.new_Value__SWIG_3(x), true) {
  }

  public Value(string str, bool isVocab) : this(yarpPINVOKE.new_Value__SWIG_4(str, isVocab), true) {
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
  }

  public Value(string str) : this(yarpPINVOKE.new_Value__SWIG_5(str), true) {
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
  }

  public Value(SWIGTYPE_p_void data, int length) : this(yarpPINVOKE.new_Value__SWIG_6(SWIGTYPE_p_void.getCPtr(data), length), true) {
  }

  public Value(Value alt) : this(yarpPINVOKE.new_Value__SWIG_7(Value.getCPtr(alt)), true) {
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual bool isBool() {
    bool ret = yarpPINVOKE.Value_isBool(swigCPtr);
    return ret;
  }

  public virtual bool isInt() {
    bool ret = yarpPINVOKE.Value_isInt(swigCPtr);
    return ret;
  }

  public virtual bool isInt8() {
    bool ret = yarpPINVOKE.Value_isInt8(swigCPtr);
    return ret;
  }

  public virtual bool isInt16() {
    bool ret = yarpPINVOKE.Value_isInt16(swigCPtr);
    return ret;
  }

  public virtual bool isInt32() {
    bool ret = yarpPINVOKE.Value_isInt32(swigCPtr);
    return ret;
  }

  public virtual bool isInt64() {
    bool ret = yarpPINVOKE.Value_isInt64(swigCPtr);
    return ret;
  }

  public virtual bool isDouble() {
    bool ret = yarpPINVOKE.Value_isDouble(swigCPtr);
    return ret;
  }

  public virtual bool isFloat32() {
    bool ret = yarpPINVOKE.Value_isFloat32(swigCPtr);
    return ret;
  }

  public virtual bool isFloat64() {
    bool ret = yarpPINVOKE.Value_isFloat64(swigCPtr);
    return ret;
  }

  public virtual bool isString() {
    bool ret = yarpPINVOKE.Value_isString(swigCPtr);
    return ret;
  }

  public virtual bool isList() {
    bool ret = yarpPINVOKE.Value_isList(swigCPtr);
    return ret;
  }

  public virtual bool isDict() {
    bool ret = yarpPINVOKE.Value_isDict(swigCPtr);
    return ret;
  }

  public virtual bool isVocab() {
    bool ret = yarpPINVOKE.Value_isVocab(swigCPtr);
    return ret;
  }

  public virtual bool isBlob() {
    bool ret = yarpPINVOKE.Value_isBlob(swigCPtr);
    return ret;
  }

  public virtual bool asBool() {
    bool ret = yarpPINVOKE.Value_asBool(swigCPtr);
    return ret;
  }

  public virtual int asInt() {
    int ret = yarpPINVOKE.Value_asInt(swigCPtr);
    return ret;
  }

  public virtual sbyte asInt8() {
    sbyte ret = yarpPINVOKE.Value_asInt8(swigCPtr);
    return ret;
  }

  public virtual short asInt16() {
    short ret = yarpPINVOKE.Value_asInt16(swigCPtr);
    return ret;
  }

  public virtual int asInt32() {
    int ret = yarpPINVOKE.Value_asInt32(swigCPtr);
    return ret;
  }

  public virtual long asInt64() {
    long ret = yarpPINVOKE.Value_asInt64(swigCPtr);
    return ret;
  }

  public virtual double asDouble() {
    double ret = yarpPINVOKE.Value_asDouble(swigCPtr);
    return ret;
  }

  public virtual float asFloat32() {
    float ret = yarpPINVOKE.Value_asFloat32(swigCPtr);
    return ret;
  }

  public virtual double asFloat64() {
    double ret = yarpPINVOKE.Value_asFloat64(swigCPtr);
    return ret;
  }

  public virtual int asVocab() {
    int ret = yarpPINVOKE.Value_asVocab(swigCPtr);
    return ret;
  }

  public virtual string asString() {
    string ret = yarpPINVOKE.Value_asString(swigCPtr);
    return ret;
  }

  public virtual Bottle asList() {
    global::System.IntPtr cPtr = yarpPINVOKE.Value_asList(swigCPtr);
    Bottle ret = (cPtr == global::System.IntPtr.Zero) ? null : new Bottle(cPtr, false);
    return ret;
  }

  public virtual Property asDict() {
    global::System.IntPtr cPtr = yarpPINVOKE.Value_asDict(swigCPtr);
    Property ret = (cPtr == global::System.IntPtr.Zero) ? null : new Property(cPtr, false);
    return ret;
  }

  public virtual Searchable asSearchable() {
    global::System.IntPtr cPtr = yarpPINVOKE.Value_asSearchable(swigCPtr);
    Searchable ret = (cPtr == global::System.IntPtr.Zero) ? null : new Searchable(cPtr, false);
    return ret;
  }

  public virtual string asBlob() {
    string ret = yarpPINVOKE.Value_asBlob(swigCPtr);
    return ret;
  }

  public virtual uint asBlobLength() {
    uint ret = yarpPINVOKE.Value_asBlobLength(swigCPtr);
    return ret;
  }

  public new bool read(ConnectionReader connection) {
    bool ret = yarpPINVOKE.Value_read(swigCPtr, ConnectionReader.getCPtr(connection));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public new bool write(ConnectionWriter connection) {
    bool ret = yarpPINVOKE.Value_write(swigCPtr, ConnectionWriter.getCPtr(connection));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public new bool check(string key) {
    bool ret = yarpPINVOKE.Value_check__SWIG_1(swigCPtr, key);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public new Value find(string key) {
    Value ret = new Value(yarpPINVOKE.Value_find(swigCPtr, key), false);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public new Bottle findGroup(string key) {
    Bottle ret = new Bottle(yarpPINVOKE.Value_findGroup__SWIG_1(swigCPtr, key), false);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool isEqual(Value alt) {
    bool ret = yarpPINVOKE.Value_isEqual(swigCPtr, Value.getCPtr(alt));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool notEqual(Value alt) {
    bool ret = yarpPINVOKE.Value_notEqual(swigCPtr, Value.getCPtr(alt));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void fromString(string str) {
    yarpPINVOKE.Value_fromString(swigCPtr, str);
  }

  public new string toString_c() {
    string ret = yarpPINVOKE.Value_toString_c(swigCPtr);
    return ret;
  }

  public virtual Value create() {
    global::System.IntPtr cPtr = yarpPINVOKE.Value_create(swigCPtr);
    Value ret = (cPtr == global::System.IntPtr.Zero) ? null : new Value(cPtr, false);
    return ret;
  }

  public virtual Value clone() {
    global::System.IntPtr cPtr = yarpPINVOKE.Value_clone(swigCPtr);
    Value ret = (cPtr == global::System.IntPtr.Zero) ? null : new Value(cPtr, false);
    return ret;
  }

  public virtual int getCode() {
    int ret = yarpPINVOKE.Value_getCode(swigCPtr);
    return ret;
  }

  public virtual bool isNull() {
    bool ret = yarpPINVOKE.Value_isNull(swigCPtr);
    return ret;
  }

  public virtual bool isLeaf() {
    bool ret = yarpPINVOKE.Value_isLeaf(swigCPtr);
    return ret;
  }

  public static Value makeInt(int x) {
    global::System.IntPtr cPtr = yarpPINVOKE.Value_makeInt(x);
    Value ret = (cPtr == global::System.IntPtr.Zero) ? null : new Value(cPtr, false);
    return ret;
  }

  public static Value makeInt8(sbyte x) {
    global::System.IntPtr cPtr = yarpPINVOKE.Value_makeInt8(x);
    Value ret = (cPtr == global::System.IntPtr.Zero) ? null : new Value(cPtr, false);
    return ret;
  }

  public static Value makeInt16(short x) {
    global::System.IntPtr cPtr = yarpPINVOKE.Value_makeInt16(x);
    Value ret = (cPtr == global::System.IntPtr.Zero) ? null : new Value(cPtr, false);
    return ret;
  }

  public static Value makeInt32(int x) {
    global::System.IntPtr cPtr = yarpPINVOKE.Value_makeInt32(x);
    Value ret = (cPtr == global::System.IntPtr.Zero) ? null : new Value(cPtr, false);
    return ret;
  }

  public static Value makeInt64(long x) {
    global::System.IntPtr cPtr = yarpPINVOKE.Value_makeInt64(x);
    Value ret = (cPtr == global::System.IntPtr.Zero) ? null : new Value(cPtr, false);
    return ret;
  }

  public static Value makeDouble(double x) {
    global::System.IntPtr cPtr = yarpPINVOKE.Value_makeDouble(x);
    Value ret = (cPtr == global::System.IntPtr.Zero) ? null : new Value(cPtr, false);
    return ret;
  }

  public static Value makeFloat32(float x) {
    global::System.IntPtr cPtr = yarpPINVOKE.Value_makeFloat32(x);
    Value ret = (cPtr == global::System.IntPtr.Zero) ? null : new Value(cPtr, false);
    return ret;
  }

  public static Value makeFloat64(double x) {
    global::System.IntPtr cPtr = yarpPINVOKE.Value_makeFloat64(x);
    Value ret = (cPtr == global::System.IntPtr.Zero) ? null : new Value(cPtr, false);
    return ret;
  }

  public static Value makeString(string str) {
    global::System.IntPtr cPtr = yarpPINVOKE.Value_makeString(str);
    Value ret = (cPtr == global::System.IntPtr.Zero) ? null : new Value(cPtr, false);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public static Value makeVocab(int v) {
    global::System.IntPtr cPtr = yarpPINVOKE.Value_makeVocab__SWIG_0(v);
    Value ret = (cPtr == global::System.IntPtr.Zero) ? null : new Value(cPtr, false);
    return ret;
  }

  public static Value makeVocab(string str) {
    global::System.IntPtr cPtr = yarpPINVOKE.Value_makeVocab__SWIG_1(str);
    Value ret = (cPtr == global::System.IntPtr.Zero) ? null : new Value(cPtr, false);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public static Value makeBlob(SWIGTYPE_p_void data, int length) {
    global::System.IntPtr cPtr = yarpPINVOKE.Value_makeBlob(SWIGTYPE_p_void.getCPtr(data), length);
    Value ret = (cPtr == global::System.IntPtr.Zero) ? null : new Value(cPtr, false);
    return ret;
  }

  public static Value makeList() {
    global::System.IntPtr cPtr = yarpPINVOKE.Value_makeList__SWIG_0();
    Value ret = (cPtr == global::System.IntPtr.Zero) ? null : new Value(cPtr, false);
    return ret;
  }

  public static Value makeList(string txt) {
    global::System.IntPtr cPtr = yarpPINVOKE.Value_makeList__SWIG_1(txt);
    Value ret = (cPtr == global::System.IntPtr.Zero) ? null : new Value(cPtr, false);
    return ret;
  }

  public static Value makeValue(string txt) {
    global::System.IntPtr cPtr = yarpPINVOKE.Value_makeValue(txt);
    Value ret = (cPtr == global::System.IntPtr.Zero) ? null : new Value(cPtr, false);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public static Value getNullValue() {
    Value ret = new Value(yarpPINVOKE.Value_getNullValue(), false);
    return ret;
  }

  public new string toString() {
    string ret = yarpPINVOKE.Value_toString(swigCPtr);
    return ret;
  }

}