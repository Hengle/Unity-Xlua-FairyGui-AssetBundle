#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class FairyGUIGoWrapperWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(FairyGUI.GoWrapper);
			Utils.BeginObjectRegister(type, L, translator, 0, 4, 4, 4);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetWrapTarget", _m_SetWrapTarget);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CacheRenderers", _m_CacheRenderers);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Update", _m_Update);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Dispose", _m_Dispose);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "wrapTarget", _g_get_wrapTarget);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "renderingOrder", _g_get_renderingOrder);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "layer", _g_get_layer);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "supportStencil", _g_get_supportStencil);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "wrapTarget", _s_set_wrapTarget);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "renderingOrder", _s_set_renderingOrder);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "layer", _s_set_layer);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "supportStencil", _s_set_supportStencil);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					FairyGUI.GoWrapper gen_ret = new FairyGUI.GoWrapper();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<UnityEngine.GameObject>(L, 2))
				{
					UnityEngine.GameObject _go = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
					
					FairyGUI.GoWrapper gen_ret = new FairyGUI.GoWrapper(_go);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to FairyGUI.GoWrapper constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetWrapTarget(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.GoWrapper gen_to_be_invoked = (FairyGUI.GoWrapper)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.GameObject _target = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
                    bool _cloneMaterial = LuaAPI.lua_toboolean(L, 3);
                    
                    gen_to_be_invoked.SetWrapTarget( _target, _cloneMaterial );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CacheRenderers(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.GoWrapper gen_to_be_invoked = (FairyGUI.GoWrapper)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.CacheRenderers(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.GoWrapper gen_to_be_invoked = (FairyGUI.GoWrapper)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    FairyGUI.UpdateContext _context = (FairyGUI.UpdateContext)translator.GetObject(L, 2, typeof(FairyGUI.UpdateContext));
                    
                    gen_to_be_invoked.Update( _context );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Dispose(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.GoWrapper gen_to_be_invoked = (FairyGUI.GoWrapper)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Dispose(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_wrapTarget(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.GoWrapper gen_to_be_invoked = (FairyGUI.GoWrapper)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.wrapTarget);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_renderingOrder(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.GoWrapper gen_to_be_invoked = (FairyGUI.GoWrapper)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.renderingOrder);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_layer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.GoWrapper gen_to_be_invoked = (FairyGUI.GoWrapper)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.layer);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_supportStencil(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.GoWrapper gen_to_be_invoked = (FairyGUI.GoWrapper)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.supportStencil);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_wrapTarget(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.GoWrapper gen_to_be_invoked = (FairyGUI.GoWrapper)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.wrapTarget = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_renderingOrder(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.GoWrapper gen_to_be_invoked = (FairyGUI.GoWrapper)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.renderingOrder = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_layer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.GoWrapper gen_to_be_invoked = (FairyGUI.GoWrapper)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.layer = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_supportStencil(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.GoWrapper gen_to_be_invoked = (FairyGUI.GoWrapper)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.supportStencil = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
