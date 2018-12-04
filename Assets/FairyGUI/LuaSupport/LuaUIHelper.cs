using System;
using System.Collections.Generic;
using FairyGUI.Utils;
using XLua;

namespace FairyGUI
{
	/// <summary>
	/// 
	/// </summary>
	public sealed class LuaUIHelper
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="url"></param>
		/// <param name="luaClass"></param>
		public static void SetExtension(string url, System.Type baseType, LuaFunction extendFunction)
		{
			UIObjectFactory.SetPackageItemExtension(url, () => {
				GComponent gcom = (GComponent)Activator.CreateInstance(baseType);
				gcom.data = extendFunction;
				return gcom;
			});
		}

		[BlackListAttribute]
		public static LuaTable ConnectLua(GComponent gcom)
		{
			LuaTable _peerTable = null;
			LuaFunction extendFunction = gcom.data as LuaFunction;
			if (extendFunction!=null)
			{
				gcom.data = null;
				_peerTable = extendFunction.Func<GComponent,LuaTable>(gcom);
			}

			return _peerTable;
		}
	}

	public class GLuaComponent : GComponent
	{
		LuaTable _peerTable;

		[BlackListAttribute]
		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			_peerTable = LuaUIHelper.ConnectLua(this);
		}

		public override void Dispose()
		{
			base.Dispose();

			if (_peerTable != null)
				_peerTable.Dispose();
		}
	}

	public class GLuaLabel : GLabel
	{
		LuaTable _peerTable;

		[BlackListAttribute]
		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			_peerTable = LuaUIHelper.ConnectLua(this);
		}

		public override void Dispose()
		{
			base.Dispose();

			if (_peerTable != null)
				_peerTable.Dispose();
		}
	}

	public class GLuaButton : GButton
	{
		LuaTable _peerTable;

		[BlackListAttribute]
		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			_peerTable = LuaUIHelper.ConnectLua(this);
		}

		public override void Dispose()
		{
			base.Dispose();

			if (_peerTable != null)
				_peerTable.Dispose();
		}
	}

	public class GLuaProgressBar : GProgressBar
	{
		LuaTable _peerTable;

		[BlackListAttribute]
		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			_peerTable = LuaUIHelper.ConnectLua(this);
		}

		public override void Dispose()
		{
			base.Dispose();

			if (_peerTable != null)
				_peerTable.Dispose();
		}
	}

	public class GLuaSlider : GSlider
	{
		LuaTable _peerTable;

		[BlackListAttribute]
		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			_peerTable = LuaUIHelper.ConnectLua(this);
		}

		public override void Dispose()
		{
			base.Dispose();

			if (_peerTable != null)
				_peerTable.Dispose();
		}
	}

	public class GLuaComboBox : GComboBox
	{
		LuaTable _peerTable;

		[BlackListAttribute]
		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			_peerTable = LuaUIHelper.ConnectLua(this);
		}

		public override void Dispose()
		{
			base.Dispose();

			if (_peerTable != null)
				_peerTable.Dispose();
		}
	}

	public class LuaWindow : Window
	{
		LuaTable _peerTable;
		LuaFunction _OnInit;
		LuaFunction _DoHideAnimation;
		LuaFunction _DoShowAnimation;
		LuaFunction _OnShown;
		LuaFunction _OnHide;

		public void ConnectLua(LuaTable peerTable)
		{
			_peerTable = peerTable;
			_OnInit = peerTable.Get<LuaFunction>("OnInit");
			_DoHideAnimation = peerTable.Get<LuaFunction>("DoHideAnimation");
			_DoShowAnimation = peerTable.Get<LuaFunction>("DoShowAnimation");
			_OnShown = peerTable.Get<LuaFunction>("OnShown");
			_OnHide = peerTable.Get<LuaFunction>("OnHide");
		}

		public override void Dispose()
		{
			base.Dispose();

			if (_peerTable != null)
				_peerTable.Dispose();
			if (_OnInit != null)
				_OnInit.Dispose();
			if (_DoHideAnimation != null)
				_DoHideAnimation.Dispose();
			if (_DoShowAnimation != null)
				_DoShowAnimation.Dispose();
			if (_OnShown != null)
				_OnShown.Dispose();
			if (_OnHide != null)
				_OnHide.Dispose();
		}

		protected override void OnInit()
		{
			if (_OnInit != null)
			{
				_OnInit.Action<LuaWindow>(this);
			}
		}

		protected override void DoHideAnimation()
		{
			if (_DoHideAnimation != null)
			{
				_DoHideAnimation.Action<LuaWindow>(this);
			}
			else
				base.DoHideAnimation();
		}

		protected override void DoShowAnimation()
		{
			if (_DoShowAnimation != null)
			{
				_DoShowAnimation.Action<LuaWindow>(this);
			}
			else
				base.DoShowAnimation();
		}

		protected override void OnShown()
		{
			base.OnShown();

			if (_OnShown != null)
			{
				_OnShown.Action<LuaWindow>(this);
			}
		}

		protected override void OnHide()
		{
			base.OnHide();

			if (_OnHide != null)
			{
				_OnHide.Action<LuaWindow>(this);
			}
		}
	}
}