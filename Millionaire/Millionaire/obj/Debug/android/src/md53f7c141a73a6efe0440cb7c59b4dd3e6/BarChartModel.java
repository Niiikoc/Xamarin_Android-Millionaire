package md53f7c141a73a6efe0440cb7c59b4dd3e6;


public class BarChartModel
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Me.ITheBK.BarChartModel, BarChart", BarChartModel.class, __md_methods);
	}


	public BarChartModel ()
	{
		super ();
		if (getClass () == BarChartModel.class)
			mono.android.TypeManager.Activate ("Me.ITheBK.BarChartModel, BarChart", "", this, new java.lang.Object[] {  });
	}

	public BarChartModel (int p0, int p1)
	{
		super ();
		if (getClass () == BarChartModel.class)
			mono.android.TypeManager.Activate ("Me.ITheBK.BarChartModel, BarChart", "System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1 });
	}

	public BarChartModel (int p0, int p1, java.lang.Object p2)
	{
		super ();
		if (getClass () == BarChartModel.class)
			mono.android.TypeManager.Activate ("Me.ITheBK.BarChartModel, BarChart", "System.Int32, mscorlib:System.Int32, mscorlib:Java.Lang.Object, Mono.Android", this, new java.lang.Object[] { p0, p1, p2 });
	}

	public BarChartModel (int p0, int p1, java.lang.String p2, java.lang.Object p3)
	{
		super ();
		if (getClass () == BarChartModel.class)
			mono.android.TypeManager.Activate ("Me.ITheBK.BarChartModel, BarChart", "System.Int32, mscorlib:System.Int32, mscorlib:System.String, mscorlib:Java.Lang.Object, Mono.Android", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
