package crc640390caa96ab8fa12;


public class TodoShellItemRenderer
	extends crc643f46942d9dd1fff9.ShellItemRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreateView:(Landroid/view/LayoutInflater;Landroid/view/ViewGroup;Landroid/os/Bundle;)Landroid/view/View;:GetOnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("TodosSample.Droid.Renderers.TodoShellItemRenderer, ProjetGroupe.Android", TodoShellItemRenderer.class, __md_methods);
	}


	public TodoShellItemRenderer ()
	{
		super ();
		if (getClass () == TodoShellItemRenderer.class)
			mono.android.TypeManager.Activate ("TodosSample.Droid.Renderers.TodoShellItemRenderer, ProjetGroupe.Android", "", this, new java.lang.Object[] {  });
	}


	public TodoShellItemRenderer (int p0)
	{
		super (p0);
		if (getClass () == TodoShellItemRenderer.class)
			mono.android.TypeManager.Activate ("TodosSample.Droid.Renderers.TodoShellItemRenderer, ProjetGroupe.Android", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public android.view.View onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2)
	{
		return n_onCreateView (p0, p1, p2);
	}

	private native android.view.View n_onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2);

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
