package md5628b32eb182bcfcfe9f49f0b9ce2aba1;


public class FirstPage_AdListener
	extends com.google.android.gms.ads.AdListener
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAdClosed:()V:GetOnAdClosedHandler\n" +
			"";
		mono.android.Runtime.register ("Millionaire.FirstPage+AdListener, Millionaire", FirstPage_AdListener.class, __md_methods);
	}


	public FirstPage_AdListener ()
	{
		super ();
		if (getClass () == FirstPage_AdListener.class)
			mono.android.TypeManager.Activate ("Millionaire.FirstPage+AdListener, Millionaire", "", this, new java.lang.Object[] {  });
	}

	public FirstPage_AdListener (md5628b32eb182bcfcfe9f49f0b9ce2aba1.FirstPage p0)
	{
		super ();
		if (getClass () == FirstPage_AdListener.class)
			mono.android.TypeManager.Activate ("Millionaire.FirstPage+AdListener, Millionaire", "Millionaire.FirstPage, Millionaire", this, new java.lang.Object[] { p0 });
	}


	public void onAdClosed ()
	{
		n_onAdClosed ();
	}

	private native void n_onAdClosed ();

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
