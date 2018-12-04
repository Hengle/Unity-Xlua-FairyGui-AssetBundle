using XLua;
using System.Collections.Generic;
using System;
using FairyGUI;

public static class FairyGuiGenConfig
{
    //lua中要使用到C#库的配置，比如C#标准库，或者Unity API，第三方库等。
    [LuaCallCSharp]
    public static List<Type> LuaCallCSharp = new List<Type>() {
        typeof(EventContext),
        typeof(EventDispatcher),
        typeof(EventListener),
        typeof(InputEvent),
        typeof(DisplayObject),
        typeof(Container),
        typeof(Stage),
        typeof(FairyGUI.Controller),
        typeof(GObject),
        typeof(GGraph),
        typeof(GGroup),
        typeof(GImage),
        typeof(GLoader),
        typeof(GMovieClip),
        typeof(TextFormat),
        typeof(GTextField),
        typeof(GRichTextField),
        typeof(GTextInput),
        typeof(GComponent),
        typeof(GList),
        typeof(GRoot),
        typeof(GLabel),
        typeof(GButton),
        typeof(GComboBox),
        typeof(GProgressBar),
        typeof(GSlider),
        typeof(PopupMenu),
        typeof(ScrollPane),
        typeof(Transition),
        typeof(UIPackage),
        typeof(Window),
        typeof(GObjectPool),
        typeof(Relations),
        typeof(RelationType),
        typeof(Timers),
        typeof(GTween),
        typeof(GTweener),
        typeof(EaseType),
        typeof(TweenValue),

        typeof(LuaUIHelper),
        typeof(GLuaComponent),
        typeof(GLuaLabel),
        typeof(GLuaButton),
        typeof(GLuaProgressBar),
        typeof(GLuaSlider),
        typeof(GLuaComboBox),
        typeof(LuaWindow),
        typeof(GoWrapper)
    };

    //C#静态调用Lua的配置（包括事件的原型），仅可以配delegate，interface
    [CSharpCallLua]
    public static List<Type> CSharpCallLua = new List<Type>() {
        typeof(EventCallback0),
        typeof(EventCallback1)
    };
}