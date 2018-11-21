//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class Matrix : Portable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal Matrix(global::System.IntPtr cPtr, bool cMemoryOwn) : base(yarpPINVOKE.Matrix_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Matrix obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~Matrix() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          yarpPINVOKE.delete_Matrix(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public Matrix() : this(yarpPINVOKE.new_Matrix__SWIG_0(), true) {
  }

  public Matrix(uint r, uint c) : this(yarpPINVOKE.new_Matrix__SWIG_1(r, c), true) {
  }

  public Matrix(Matrix m) : this(yarpPINVOKE.new_Matrix__SWIG_2(Matrix.getCPtr(m)), true) {
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
  }

  public uint rows() {
    uint ret = yarpPINVOKE.Matrix_rows(swigCPtr);
    return ret;
  }

  public uint cols() {
    uint ret = yarpPINVOKE.Matrix_cols(swigCPtr);
    return ret;
  }

  public void resize(uint r, uint c) {
    yarpPINVOKE.Matrix_resize(swigCPtr, r, c);
  }

  public double access(uint r, uint c) {
    double ret = yarpPINVOKE.Matrix_access__SWIG_0(swigCPtr, r, c);
    return ret;
  }

  public void zero() {
    yarpPINVOKE.Matrix_zero(swigCPtr);
  }

  public bool setRow(uint row, Vector r) {
    bool ret = yarpPINVOKE.Matrix_setRow(swigCPtr, row, Vector.getCPtr(r));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool setCol(uint col, Vector c) {
    bool ret = yarpPINVOKE.Matrix_setCol(swigCPtr, col, Vector.getCPtr(c));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public Matrix transposed() {
    Matrix ret = new Matrix(yarpPINVOKE.Matrix_transposed(swigCPtr), true);
    return ret;
  }

  public Matrix eye() {
    Matrix ret = new Matrix(yarpPINVOKE.Matrix_eye(swigCPtr), false);
    return ret;
  }

  public Matrix diagonal(Vector d) {
    Matrix ret = new Matrix(yarpPINVOKE.Matrix_diagonal(swigCPtr, Vector.getCPtr(d)), false);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public Matrix submatrix(uint r1, uint r2, uint c1, uint c2) {
    Matrix ret = new Matrix(yarpPINVOKE.Matrix_submatrix(swigCPtr, r1, r2, c1, c2), true);
    return ret;
  }

  public bool setSubmatrix(Matrix m, uint r, uint c) {
    bool ret = yarpPINVOKE.Matrix_setSubmatrix(swigCPtr, Matrix.getCPtr(m), r, c);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool setSubrow(Vector v, uint r, uint c) {
    bool ret = yarpPINVOKE.Matrix_setSubrow(swigCPtr, Vector.getCPtr(v), r, c);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool setSubcol(Vector v, uint r, uint c) {
    bool ret = yarpPINVOKE.Matrix_setSubcol(swigCPtr, Vector.getCPtr(v), r, c);
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public Vector getRow(uint r) {
    Vector ret = new Vector(yarpPINVOKE.Matrix_getRow(swigCPtr, r), true);
    return ret;
  }

  public Vector getCol(uint c) {
    Vector ret = new Vector(yarpPINVOKE.Matrix_getCol(swigCPtr, c), true);
    return ret;
  }

  public Matrix removeCols(uint first_col, uint how_many) {
    Matrix ret = new Matrix(yarpPINVOKE.Matrix_removeCols(swigCPtr, first_col, how_many), true);
    return ret;
  }

  public Matrix removeRows(uint first_row, uint how_many) {
    Matrix ret = new Matrix(yarpPINVOKE.Matrix_removeRows(swigCPtr, first_row, how_many), true);
    return ret;
  }

  public Vector subrow(uint r, uint c, uint size) {
    Vector ret = new Vector(yarpPINVOKE.Matrix_subrow(swigCPtr, r, c, size), true);
    return ret;
  }

  public Vector subcol(uint r, uint c, uint size) {
    Vector ret = new Vector(yarpPINVOKE.Matrix_subcol(swigCPtr, r, c, size), true);
    return ret;
  }

  public new string toString(int precision, int width, string endRowStr) {
    string ret = yarpPINVOKE.Matrix_toString__SWIG_0(swigCPtr, precision, width, endRowStr);
    return ret;
  }

  public new string toString(int precision, int width) {
    string ret = yarpPINVOKE.Matrix_toString__SWIG_1(swigCPtr, precision, width);
    return ret;
  }

  public new string toString(int precision) {
    string ret = yarpPINVOKE.Matrix_toString__SWIG_2(swigCPtr, precision);
    return ret;
  }

  public new string toString_c() {
    string ret = yarpPINVOKE.Matrix_toString_c(swigCPtr);
    return ret;
  }

  public SWIGTYPE_p_double data() {
    global::System.IntPtr cPtr = yarpPINVOKE.Matrix_data__SWIG_0(swigCPtr);
    SWIGTYPE_p_double ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_double(cPtr, false);
    return ret;
  }

  public bool isEqual(Matrix r) {
    bool ret = yarpPINVOKE.Matrix_isEqual(swigCPtr, Matrix.getCPtr(r));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public new bool read(ConnectionReader connection) {
    bool ret = yarpPINVOKE.Matrix_read(swigCPtr, ConnectionReader.getCPtr(connection));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public new bool write(ConnectionWriter connection) {
    bool ret = yarpPINVOKE.Matrix_write(swigCPtr, ConnectionWriter.getCPtr(connection));
    if (yarpPINVOKE.SWIGPendingException.Pending) throw yarpPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public double get(int i, int j) {
    double ret = yarpPINVOKE.Matrix_get(swigCPtr, i, j);
    return ret;
  }

  public void set(int i, int j, double v) {
    yarpPINVOKE.Matrix_set(swigCPtr, i, j, v);
  }

}