//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class PixelRgbFloat : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal PixelRgbFloat(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PixelRgbFloat obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~PixelRgbFloat() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          yarpPINVOKE.delete_PixelRgbFloat(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public float r {
    set {
      yarpPINVOKE.PixelRgbFloat_r_set(swigCPtr, value);
    } 
    get {
      float ret = yarpPINVOKE.PixelRgbFloat_r_get(swigCPtr);
      return ret;
    } 
  }

  public float g {
    set {
      yarpPINVOKE.PixelRgbFloat_g_set(swigCPtr, value);
    } 
    get {
      float ret = yarpPINVOKE.PixelRgbFloat_g_get(swigCPtr);
      return ret;
    } 
  }

  public float b {
    set {
      yarpPINVOKE.PixelRgbFloat_b_set(swigCPtr, value);
    } 
    get {
      float ret = yarpPINVOKE.PixelRgbFloat_b_get(swigCPtr);
      return ret;
    } 
  }

  public PixelRgbFloat() : this(yarpPINVOKE.new_PixelRgbFloat__SWIG_0(), true) {
  }

  public PixelRgbFloat(float n_r, float n_g, float n_b) : this(yarpPINVOKE.new_PixelRgbFloat__SWIG_1(n_r, n_g, n_b), true) {
  }

}